using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using IOT_SERVER;

public class SimpleServer
{

    //IOT_SERVER.Encoder myEncoder = new IOT_SERVER.Encoder();

    private const int BUFFSIZE_DEFAULT = 32;

    private const int DEFAULT_PORT = 8080;

    private const int DEFAULT_LISTENERS = 5;

    private const int DEAFULT_BUFF_SIZE = 100;

    private int Port { get; set; }

    private int Listeners { get; set; }

    protected byte[] recvBuffer;

    private Socket server = null;
        
    private Socket Client = null;
    
    private int i = 0;

    public const int DEFAULT_SERVER_PORT = 80;

    public const int DEFAULT_TIMEOUT_RECEIVE = 1000;    

    public  SimpleServer(int port, int listeners)
	{

        Listeners = listeners;

        Port = port;
        
    }


    public  SimpleServer(int port) {

        Port = port;

        Listeners = DEFAULT_LISTENERS;

    }

     public string Init() {
        

        try
        {

            Console.WriteLine("Trying to Listen on port {0}.", Port);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(new IPEndPoint(IPAddress.Any, Port));

            server.ReceiveTimeout = DEFAULT_TIMEOUT_RECEIVE;

            server.Listen(1);            

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

        recvBuffer = new byte[DEAFULT_BUFF_SIZE];

        return "SUCCESFULL INITIALISED AT PORT " + Port.ToString();


    }

    public IPEndPoint StartAccepting() {

        Client = server.Accept();

        Client.ReceiveTimeout = 100;

        Console.WriteLine("Trial {0}", i);        

        Console.WriteLine("Done Accepting");

        Console.WriteLine("Handling Client at {0}.", (IPEndPoint)(Client.RemoteEndPoint));

        return (IPEndPoint) Client.RemoteEndPoint;

    }

    public String GetMessage() {

        int bytesReceived = 0;

        i++;            

            try
            {

            bytesReceived = Client.Receive(recvBuffer, recvBuffer.Length, SocketFlags.None);

            if (bytesReceived > 0)
            {
                return  Client.RemoteEndPoint.ToString() + ". Received : " + System.Text.Encoding.ASCII.GetString(recvBuffer);
            }

            else return null;

            }

            catch (SocketException)
            {
                
                if (Client == null) {

                    Console.WriteLine("Error Eroor!!");

                    return "PROBLEM: ";

                }                              

            }      
        
            


        return null;

    }

    public int SendMessage(byte[] buff) {


        if (Client == null) return -1;        

        try {

            Client.Send(buff, buff.Length, SocketFlags.None);

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
    
   

}
