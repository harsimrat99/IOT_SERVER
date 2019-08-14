using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace IOT_SERVER
{
    class Listener
    {

        private byte[] Data = new byte[512];

        private const string DEFAULT_ADDR = "127.0.0.1";

        private const string DEFAULT_GREETING = "HTTP/1.1 200 OK\r\n\r\n<!DOCTYPE HTML>\r\n<BODY>\r\nHello world!\r\n<marquee>123</marquee>\r\n</BODY>\r\n</HTML>";

        private byte[] DEFAULT_GREETING_BYTES = Encoding.ASCII.GetBytes(DEFAULT_GREETING);

        private IPEndPoint localEndpoint;

        private TcpListener listener;

        public int Port { get; private set; }

        public string Address { get; private set; }

        public Listener(int port)
        {

            Port = port;

            Address = DEFAULT_ADDR;

            localEndpoint = new IPEndPoint(IPAddress.Parse(Address), Port);

            listener = new TcpListener(IPAddress.Any, Port);

            listener.Start();

        }

        public void HandleClient()
        {

            if (!listener.Pending()) return;

            TcpClient client = null;

            NetworkStream stream = null;

            try
            {
                client = listener.AcceptTcpClient();

                stream = client.GetStream();

                stream.Read(Data, 0, Data.Length);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (client == null) return;

            Console.WriteLine("Receieved: ");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("{0}", Encoding.ASCII.GetString(Data, 0, Data.Length));

            Console.ResetColor();

            Console.WriteLine(" from ");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(client.Client.RemoteEndPoint.ToString());

            Console.ResetColor();

            try
            {

                if (stream.CanWrite && !(stream == null)) stream.Write(DEFAULT_GREETING_BYTES, 0, DEFAULT_GREETING_BYTES.Length);
            }

            catch (Exception) { }

            Array.Clear(Data, 0, Data.Length);

            client.Close();

        }

        public void Close()
        {

            listener.Stop();
        }

    }
}
