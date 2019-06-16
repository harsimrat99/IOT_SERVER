using System;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using IOT_SERVER;

public class SimpleServer : NetworkingServer
{     
    private Hashtable  ClientList;

    private int i = 0;   

    public  SimpleServer(int port, int listeners)
	{

        Listeners = listeners;

        ClientList = new Hashtable(Listeners);

        Port = port;
        
    }

    public  SimpleServer(int port) {

        Port = port;

        Listeners = DEFAULT_LISTENERS;

        ClientList = new Hashtable(Listeners);

    }

    public override string Init()
    {
        

        try
        {

            Console.WriteLine("Trying to Listen on port {0}.", Port);

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

        finally
        {

            Console.WriteLine("System listening on port {0}.", Port);

        }

        recvBuffer = new byte[DEFAULT_BUFFER_SIZE];

        return "SUCCESFULL INITIALISED AT PORT " + Port.ToString();


    }

    public override void Accept() {

        if (Server.Poll(DEFAULT_POLL_MICROS, SelectMode.SelectRead))
        {
            ++i;

            ClientList.Add(i, Server.Accept());

            ((Socket)ClientList[i]).ReceiveTimeout = DEFAULT_TIMEOUT_RECEIVE;

            AcceptEventArgs ae = new AcceptEventArgs
            {
                endp = ((Socket)ClientList[i]).RemoteEndPoint,

                Name = i.ToString()
            };

            base.OnAcceptEvent(ae);
            
        }
        
    }

    public override void Close() {

        foreach (object gg in ClientList)

            if (((Socket)gg) != null)

            {

                ((Socket)gg).Shutdown(SocketShutdown.Both);

                ((Socket)gg).Close();

            }

        Server.Close();        

    }

    public String GetMessage()
    {

        foreach (DictionaryEntry Client in ClientList)
        {

            if (((Socket)Client.Value).Available > 0)
            {

                try
                {
                    recvBuffer = new byte[DEFAULT_BUFFER_SIZE];

                    int bytesReceived = ((Socket)Client.Value).Receive(recvBuffer, recvBuffer.Length, SocketFlags.None);

                    if (bytesReceived > 0)
                    {
                        return ((Socket)Client.Value).RemoteEndPoint.ToString() + " : " + System.Text.Encoding.ASCII.GetString(recvBuffer);
                    }

                    else return null;

                }

                catch (Exception)
                {                    

                    if (((Socket)Client.Value) == null)
                    {

                        return "PROBLEM";

                    }

                }

            }

        }

        return null;

    }

    public int SendMessage(int key, byte[] buff)
    {


        try
        {

            ((Socket)ClientList[key]).Send(buff, buff.Length, SocketFlags.None);

        }

        catch (Exception e)
        {

            Console.WriteLine(e.Message);

        }


        return 1;

    }


}

