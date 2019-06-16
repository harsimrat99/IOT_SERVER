using System;
using System.Collections;
using System.Linq;

using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;


public class SimpleServer
{

    //IOT_SERVER.Encoder myEncoder = new IOT_SERVER.Encoder();

    public const int DEFAULT_SERVER_PORT = 8080;        

    private const int DEFAULT_LISTENERS = 5;

    private const int DEFAULT_BUFFER_SIZE = 100;    

    private const int DEFAULT_TIMEOUT_RECEIVE = 1000;

    //5 milli seconds
    private const int DEFAULT_POLL_MICROS = 50000;

    private byte[] recvBuffer;

    private int Port { get; set; }

    private int Listeners { get; set; }    

    private Socket server = null;       

    private Hashtable  ClientList;

    private int i = 0;

    public event EventHandler <AcceptEventArgs> AcceptEvent;

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

     public string Init() {
        

        try
        {

            Console.WriteLine("Trying to Listen on port {0}.", Port);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(new IPEndPoint(IPAddress.Any, Port));

            server.ReceiveTimeout = DEFAULT_TIMEOUT_RECEIVE;

            server.Listen(Listeners);    
                       

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

    public void Accept() {

        if (server.Poll(DEFAULT_POLL_MICROS, SelectMode.SelectRead))
        {
            ++i;

            ClientList.Add(i, server.Accept());

            ((Socket)ClientList[i]).ReceiveTimeout = DEFAULT_TIMEOUT_RECEIVE;

            AcceptEventArgs ae = new AcceptEventArgs();

            ae.endp = ((Socket)ClientList[i]).RemoteEndPoint;

            ae.Name = i.ToString();
            
            AcceptEvent.Invoke(this, ae);
            
        }
        
    }

    public String GetMessage() {

        int bytesReceived = 0;

        foreach (Socket Client in ClientList)
        {
            
            if (((Socket)Client).Available > 0) { 

                try
                {                    
                    recvBuffer = new byte[DEFAULT_BUFFER_SIZE];

                    bytesReceived = ((Socket)Client).Receive(recvBuffer, recvBuffer.Length, SocketFlags.None);

                    if (bytesReceived > 0)
                    {
                        return ((Socket)Client).RemoteEndPoint.ToString() + " : " + System.Text.Encoding.ASCII.GetString(recvBuffer);
                    }

                    else return null;

                }

                catch (SocketException)
                {

                    if (((Socket)Client) == null)
                    {
                        
                        return "PROBLEM";

                    }

                }

            }            

        }

        return null;

    }

    public int SendMessage(int key, byte[] buff) {
      

        try {

            ((Socket)ClientList[key]).Send(buff, buff.Length, SocketFlags.None);

        }

        catch (Exception e) {            

            Console.WriteLine(e.Message);

        }


        return 1;

    }

    public void Close() {

        foreach (object gg in ClientList)

            if (((Socket)gg) != null)

            {

                ((Socket)gg).Shutdown(SocketShutdown.Both);

                ((Socket)gg).Close();

            }

        server.Close();        

    }


    public class AcceptEventArgs : EventArgs {

        public EndPoint endp;

        public string Name;

    }

}

