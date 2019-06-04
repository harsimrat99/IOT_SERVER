using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;


public class SimpleServer
{

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

            server.Listen(100);

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

    public String GetMessage() {

        int bytesReceived;

            i++;

            try
            {

                Console.WriteLine("Trial {0}", i);

                Client = server.Accept();

                Console.WriteLine("Done Accepting");

                Console.WriteLine("Handling Client at {0}.", (IPEndPoint) (Client.RemoteEndPoint));
                 
                bytesReceived = Client.Receive(recvBuffer, recvBuffer.Length, SocketFlags.None);

                Console.WriteLine( "Got stuff!");

                return "THING" + Client.RemoteEndPoint.ToString() + Encoding.ASCII.GetString(recvBuffer);
                             

            }

            catch (SocketException se)
            {

                Console.WriteLine(se.Message);

                if (Client == null) {

                    Console.WriteLine("Error Eroor!!");

                return "PROBLEM: " + se.Message;

                }

                else Client.Close();               

            }        

        return null;

    }

    public void Close() {               

        server.Close();        

    }
    
   

}
