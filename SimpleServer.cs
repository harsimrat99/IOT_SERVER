using System;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using IOT_SERVER;
using System.Runtime.InteropServices;
using System.Text;

public class SimpleServer : NetworkingServer
{     
    private Hashtable  ClientsList;

    private ArrayList ClientsToServiced = new ArrayList(5);

    private int i = 0;

    private object MyLock = new object();
  
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
    private static extern int memcmp(byte[] b1, byte[] b2, long count);
    [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern int memset(byte[] b1, byte val, int length);

    public override string Init()
    {
        

        try
        {            

            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Server.Bind(new IPEndPoint(IPAddress.Any, Port));

            Server.ReceiveTimeout = DEFAULT_TIMEOUT_RECEIVE;

            Server.Listen(Listeners);    
                       
            recvBuffer = new byte[DEFAULT_BUFFER_SIZE]; ;

        }

        catch (SocketException e)
        {

            Console.WriteLine(e.Message);

            return "PROB";

        }

        recvBuffer = new byte[DEFAULT_BUFFER_SIZE];

        return "SUCCESFULLY INITIALISED AT PORT " + Port.ToString();

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

                    ReceiveMessageEventArgs args = new ReceiveMessageEventArgs();

                    args.endp = ((Socket)Client.Value).RemoteEndPoint;

                    args.key = (int) (Client.Key);

                    ClientsToServiced.Add((args));
                   
                }

            }

            ParseMessages();

        }

        return null;

    }

    private void ParseMessages() {

        if (ClientsToServiced.Count == 0) return;

        int bytesReceived = DEFAULT_BUFFER_SIZE;

        Message message = new Message("","","");

        for (int i = 0; i < ClientsToServiced.Count; i++)
        {

            memset(recvBuffer, 0, bytesReceived);

            bytesReceived = ((Socket)ClientsList[((ReceiveMessageEventArgs)ClientsToServiced[i]).key]).Receive(recvBuffer, recvBuffer.Length, SocketFlags.None);

            message = MessageParser.GetMessage(recvBuffer);

            switch (message.COMMAND) {

                case Command.SEND:
                    {
                        int key = Int32.Parse(message.ARGUMENTS);

                        if (ClientsList.Contains(key)) SendMessage(key, Encoding.ASCII.GetBytes(message.OPTIONS));

                        break;
                    }

                case Command.CLOSE:
                    {
                        ((Socket)ClientsList[((ReceiveMessageEventArgs)ClientsToServiced[i]).key]).Close();

                        ClientsList.Remove(((ReceiveMessageEventArgs)ClientsToServiced[i]).key);

                        base.OnCloseConnection(new CloseConnectionEventArgs { Key = ((ReceiveMessageEventArgs)ClientsToServiced[i]).key });

                        break;
                    }

                case Command.POST:
                    {
                        ((Socket)ClientsList[((ReceiveMessageEventArgs)ClientsToServiced[i]).key]).Close();

                        ClientsList.Remove(((ReceiveMessageEventArgs)ClientsToServiced[i]).key);

                        base.OnCloseConnection(new CloseConnectionEventArgs { Key = ((ReceiveMessageEventArgs)ClientsToServiced[i]).key });

                        break;
                    }

                default: {

                        Console.WriteLine("Command not parsed." + message.ToString());                        

                        break;
                    }
            }


        }

        ClientsToServiced.Clear();

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
            ClientsList.Remove((int)key);
        }

        base.OnCloseConnection(new CloseConnectionEventArgs { Key = key});
    }
}

