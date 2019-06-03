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

    private const int DEAFULT_LISTENERS = 5;

    private const int DEAFULT_BUFF_SIZE = 100;

    private int Port { get; set; }

    protected byte[] recvBuffer;

    private Socket Socket = null, Client = null;

    public SimpleServer(int port, int listeners)
	{

        init(port, listeners);

    }


    public  SimpleServer(int port) {

        init(port, DEAFULT_LISTENERS);

    }

    protected void init(int port, int listeners) {

        Port = port;

        try
        {

            Console.WriteLine("Trying to Listen on port {0}.", Port);

            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Socket.Bind(new IPEndPoint(IPAddress.Any, Port));

            Socket.Blocking = false;

            Socket.Listen(listeners);

        }

        catch (SocketException e)
        {

            Console.WriteLine(e.Message);

            return;

        }

        finally
        {

            Console.WriteLine("System listening on port {0}.", Port);

        }

        recvBuffer = new byte[DEAFULT_BUFF_SIZE];



    }

    public String GetMessage() {

        int bytesReceived;

        try
        {

            Client = Socket.Accept();

            Console.WriteLine("Handling Client at {0}.", Client.RemoteEndPoint);

            if (Client.Available > 0)
            {

                bytesReceived = Client.Receive(recvBuffer, recvBuffer.Length, SocketFlags.None);

                return Encoding.ASCII.GetString(recvBuffer);

            }

            else return null;

        }

        catch (SocketException se) {

            Console.WriteLine(se.Message);

            if (Client == null) return null;

            else Client.Close();

            return null;

        }
    }
    
}
