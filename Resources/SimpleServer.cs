using System;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using IOT_SERVER;
using System.Runtime.InteropServices;

public class SimpleServer : NetworkingServer
{     
    private Hashtable  ClientsList;

    private ArrayList ClientsToBeRemoved = new ArrayList(5);

    private int i = 0;

    private object MyLock = new object();

    private byte[] ClosingMessage = { ((byte)'e'), ((byte)'o'), ((byte)'f') };

    public SimpleServer(int port, int listeners)
	{

        Listeners = listeners;

        ClientsList = new Hashtable(Listeners);

        Port = port;
        
    }

    public  SimpleServer(int port) {

        Port = port;

        Listeners = DEFAULT_LISTENERS;

        ClientsList = new Hashtable(Listeners);

    }

    [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern int memcmp(byte[] b1, byte[] b2, long count);

    public override string Init()
    {
        

        try
        {            

            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Server.Bind(new IPEndPoint(IPAddress.Any, Port));

            Server.ReceiveTimeout = DEFAULT_TIMEOUT_RECEIVE;

            Server.Listen(Listeners);    
                       

        }

        catch (SocketException e)
        {

            Console.WriteLine(e.Message);

            return "PROB";

        }

        recvBuffer = new byte[DEFAULT_BUFFER_SIZE];

        return "SUCCESFULLY INITIALISED AT PORT " + Port.ToString();

    }

    private void Cleanup()
    {
        lock (MyLock)
        {

            for (int i = 0; i < ClientsToBeRemoved.Count; i++)
            {
                ((Socket)ClientsList[((CloseConnectionEventArgs)ClientsToBeRemoved[i]).Key]).SendTimeout = 10;

                ((Socket)ClientsList[((CloseConnectionEventArgs)ClientsToBeRemoved[i]).Key]).Send(ClosingMessage);

                ((Socket)ClientsList[((CloseConnectionEventArgs)ClientsToBeRemoved[i]).Key]).Close();

                ClientsList.Remove(((CloseConnectionEventArgs)ClientsToBeRemoved[i]).Key);

                base.OnCloseConnection(((CloseConnectionEventArgs)ClientsToBeRemoved[i]));

            }
        }
        ClientsToBeRemoved.Clear();
    }

    public override void Accept() {

        if (Server.Poll(DEFAULT_POLL_MICROS, SelectMode.SelectRead))
        {
            ++i;

            ClientsList.Add(i, Server.Accept());

            ((Socket)ClientsList[i]).ReceiveTimeout = DEFAULT_TIMEOUT_RECEIVE;

            AcceptEventArgs ae = new AcceptEventArgs
            {
                endp = ((Socket)ClientsList[i]).RemoteEndPoint,

                Name = i.ToString()
            };

            base.OnAcceptEvent(ae);
            
        }
        
    }

    public override void Close() {

        foreach (DictionaryEntry gg in ClientsList)

            if (((Socket)gg.Value) != null)

            {

                ((Socket)gg.Value).Shutdown(SocketShutdown.Both);

                ((Socket)gg.Value).Close();

            }

        Server.Close();        

    }

    public String GetMessage()
    {

        lock (MyLock)
        {

            foreach (DictionaryEntry Client in ClientsList)
            {

                if (((Socket)Client.Value).Available > 0)
                {
                    
                    recvBuffer = new byte[DEFAULT_BUFFER_SIZE];

                    int bytesReceived = ((Socket)Client.Value).Receive(recvBuffer, recvBuffer.Length, SocketFlags.None);

                    if (bytesReceived == 3 && (memcmp(recvBuffer, ClosingMessage, 3) == 0))
                    {

                        CloseConnectionEventArgs args = new CloseConnectionEventArgs();

                        args.endp = ((Socket)Client.Value).RemoteEndPoint;

                        args.Key = (int) (Client.Key);

                        ClientsToBeRemoved.Add((args));

                    }

                    else if (bytesReceived > 0) return ((Socket)Client.Value).RemoteEndPoint.ToString() + " : " + System.Text.Encoding.ASCII.GetString(recvBuffer);

                    else return null;
                   
                }

            }

            Cleanup();

        }

        return null;

    }

    public int SendMessage(int key, byte[] buff)
    {

        try
        {

            ((Socket)ClientsList[key]).Send(buff, buff.Length, SocketFlags.None);

        }

        catch (Exception e)
        {

            Console.WriteLine(e.Message);

        }

        return 1;

    }

    public override void RemoveClient(int key)
    {
        lock (MyLock)
        {
            this.ClientsToBeRemoved.Add(new CloseConnectionEventArgs { Key = key });
        }
    }
}

