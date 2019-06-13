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

    private int i = 0;

    private Socket server = null;
        
    private Socket Client = null;

    private ArrayList ClientList;

    public  SimpleServer(int port, int listeners)
	{

        Listeners = listeners;

        ClientList = new ArrayList(Listeners);

        Port = port;
        
    }


    public  SimpleServer(int port) {

        Port = port;

        Listeners = DEFAULT_LISTENERS;

        ClientList = new ArrayList(Listeners);

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

    public IPEndPoint Accept() {

        if (server.Poll(DEFAULT_POLL_MICROS, SelectMode.SelectRead))
        {

            var index = ClientList.Add(server.Accept());

            ((Socket)ClientList[index]).ReceiveTimeout = DEFAULT_TIMEOUT_RECEIVE;            

            Console.WriteLine("Trial {0}", ++this.i);

            Console.WriteLine("Done Accepting");

            Console.WriteLine("Handling Client at {0}.", ((Socket)ClientList[index]).RemoteEndPoint);

            return (IPEndPoint)((Socket)ClientList[index]).RemoteEndPoint;

        }

        //Console.WriteLine("No acceptance." + ClientList.Count.ToString());

        return null;

    }

    public String GetMessage() {

        int bytesReceived = 0;

        for (int j = 0; j < ClientList.Count; j++)
        {
            
            if (((Socket)ClientList[j]).Available > 0) { 

                try
                {                    
                    recvBuffer = new byte[DEFAULT_BUFFER_SIZE];

                    bytesReceived = ((Socket)ClientList[j]).Receive(recvBuffer, recvBuffer.Length, SocketFlags.None);

                    if (bytesReceived > 0)
                    {
                        return ((Socket)ClientList[j]).RemoteEndPoint.ToString() + " : " + System.Text.Encoding.ASCII.GetString(recvBuffer);
                    }

                    else return null;

                }

                catch (SocketException)
                {

                    if ((Socket)ClientList[j] == null)
                    {
                        
                        return "PROBLEM: ";

                    }

                }

            }

            Console.WriteLine("available nothing for this one ");

        }

        return null;

    }

    public int SendMessage(byte[] buff) {


        //if (Client == null) return -1;        

        try {

            ((Socket)ClientList[ClientList.Count-1]).Send(buff, buff.Length, SocketFlags.None);

        }

        catch (Exception e) {            

            Console.WriteLine(e.Message);

            Environment.Exit(0);
        }


        return 1;

    }

    public void Close() {

        if (Client != null) Client.Close();

        server.Close();        

    }

    public ref ArrayList GetClients()
    {
        return  ref  ClientList;
    }

}

