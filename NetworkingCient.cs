using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace IOT_SERVER
{
    class NetworkingClient
    {
        /*
         *  Client Model : connect ->  send/receive -> close
         *  
         *  Server Model:  bind -> listen -> accept -> send/receive -> close
         * 
         */

        private NetworkStream netStream;

        private IPEndPoint currentEndpoint;

        protected private Socket socket;

        private IPHostEntry host;

        private ProtoType _type;        

        private int port;

        private int bufferLength;

        private int timeOut;

        private byte[] buffer;

        protected private const int B_SIZE_DEAFULT = 200;

        protected private const short PORT_DEFAULT = 8080;

        protected private const int TIMEOUT_DEFAULT = 10000;

        public enum ProtoType {

            TCP, UDP

        }

        public  NetworkingClient(ProtoType type, String server, int port, int buffSize) {

            Init(type, server, port, buffSize);

        }

        public NetworkingClient(ProtoType type, String server, int port) {

            Init(type, server, port, B_SIZE_DEAFULT);

        }


        protected int Init (ProtoType type, String server, int port, int buffSize) {

            this.port = port;

            host = Dns.GetHostEntry(server);

            currentEndpoint = new IPEndPoint(host.AddressList[0], port);

            _type = type;

            bufferLength = buffSize;

            switch (_type) {

                case ProtoType.TCP:

                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    break;

                case ProtoType.UDP:

                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Udp);

                    break;     

            }            

            socket.NoDelay = true;

            socket.Blocking = true;

            socket.SendTimeout = TIMEOUT_DEFAULT;

            socket.ReceiveTimeout = TIMEOUT_DEFAULT;

            socket.SendBufferSize = bufferLength;

            return 1;

        }

        public bool isConnected() {

            return socket.Connected;

        }

        public int Timeout {

            get {

                return timeOut;

            }

            set {

                socket.SendTimeout = value;

                socket.ReceiveTimeout = value;

            }

        }

        public int Connect() {

            try
            {
                Console.WriteLine("Attempting to connect to {0} on port  {1}", currentEndpoint.Address, currentEndpoint.Port);

                socket.Connect(currentEndpoint);
            }

            catch (SocketException se)
            {

                Console.WriteLine("Connection Error: {0}", se.ErrorCode.ToString());

                throw new SocketException(se.ErrorCode);


            }

            Console.WriteLine("Connected succesfully.");

            return 1;

        }

        public int Disconnect() {

            try
            {

                Console.WriteLine("Attempting socket closure.");

                socket.Close();

            }

            catch (SocketException se) {

                Console.WriteLine(se.ErrorCode);

                throw new SocketException(se.ErrorCode);

            }

            Console.WriteLine("Socket closed succesfully.");

            return 1;

        }

        public int Available() {

            return socket.Available;

        }

        public IPAddress Ip() {

            Console.WriteLine(IPAddress.Parse(((IPEndPoint)socket.RemoteEndPoint).Address.ToString()));

            return IPAddress.Parse(((IPEndPoint)socket.RemoteEndPoint).Address.ToString());

        }

        public int Write(String msg) {

            return 1;

        }

        public int Write(int msg) {

            return 1;

        }
        

    }
}
