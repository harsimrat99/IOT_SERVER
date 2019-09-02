using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Timers;

namespace IOT_SERVER
{ 

    public class NetworkingClient
    {
        /*
         *  Client Model : connect ->  send/receive -> close
         *  
         *  Server Model:  bind -> listen -> accept -> send/receive -> close
         * 
         */

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int memset(byte[] b1, byte val, int length);

        private Timer keepAliveTimer;

        private IPEndPoint currentEndpoint;

        private Socket socket;

        private IPHostEntry host;

        private ProtoType _type;

        private Message message;

        private int bufferLength;

        private byte[] readBuffer;

        private byte[] recvPacket;

        private int bytesReceived;

        private int port;

        private int timeOut = 0;

        public const int B_SIZE_DEAFULT = 200;

        public const short PORT_DEFAULT = 8080;

        public const int TIMEOUT_DEFAULT = 3000;

        public const int DEFAULT_RETRIES = 3;

        public const int DEFAULT_KEEPALIVE_MILLIS = 900 * 1000;

        public event EventHandler <ClientRecvEventArgs> ClientReceiveEvent;

        public event EventHandler ServerDisconnectedEvent;

        public class ClientRecvEventArgs : EventArgs {

            public string message;

            public EndPoint endp;

        }

        public enum ProtoType {

            TCP, UDP

        }

        public  NetworkingClient(ProtoType type, String server, int port, int buffSize) {

            Init(type, server, port, buffSize);

        }

        public NetworkingClient(ProtoType type, String server, int port) {

            Init(type, server, port, B_SIZE_DEAFULT);

        }

        protected int Init(ProtoType type, String server, int port, int buffSize) {

            this.port = port;

            Console.WriteLine(server);

            host = Dns.Resolve(server);

            for (int l = 0; l < host.AddressList.Length; l++) {

                Console.WriteLine(host.AddressList[l]);

            }

            currentEndpoint = new IPEndPoint(host.AddressList[0], port);

            _type = type;

            bufferLength = buffSize;

            recvPacket = new byte[bufferLength];

            switch (_type) {

                case ProtoType.TCP:

                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    break;

                case ProtoType.UDP:

                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                    break;

            }

            socket.Blocking = true;

            socket.SendTimeout = TIMEOUT_DEFAULT;

            socket.ReceiveTimeout = TIMEOUT_DEFAULT;

            socket.SendBufferSize = bufferLength;

            readBuffer = new byte[this.bufferLength];

            message = new Message("", "", "");

            this.keepAliveTimer = new Timer();

            this.keepAliveTimer.Interval = DEFAULT_KEEPALIVE_MILLIS;

            this.keepAliveTimer.Enabled = true;

            this.keepAliveTimer.Elapsed += KeepAliveTimer_Elapsed;

            return 1;

        }

        private void KeepAliveTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Write(new byte[] { 1, 0, 1 });             

        }

        public bool IsConnected() {

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

                return -1;


            }

            Console.WriteLine("Connected succesfully.");

            return 1;

        }

        public int Disconnect() {

            try
            {

                Message close = new Message();

                MessageBuilder mb = new MessageBuilder();

                close = mb.CreateMessage(Command.CLOSE, Argument.NULLARGS, Option.NULLPARAM);

                socket.Send(mb.GetBytes(close));

                socket.Close();               

            }

            catch (SocketException se) {

                Console.WriteLine(se.ErrorCode);

                return -1;

            }

            Console.WriteLine("Socket closed succesfully.");

            this.keepAliveTimer.Enabled = false;

            return 1;

        }

        public int Available() {

            return socket.Available;

        }

        public IPAddress Ip() {           

            try { return IPAddress.Parse(((IPEndPoint)socket.RemoteEndPoint).Address.ToString()); }

            catch (Exception) {

                return null;
            }

        }
      
        public int Write(byte[] msg) {

            int sentLength = msg.Length;

            try {

                if (this._type == ProtoType.TCP) sentLength = socket.Send(msg, sentLength, SocketFlags.None);

                else if (this._type == ProtoType.UDP) {

                    int tries = 0;

                    bool received = false;

                    do
                    {

                        socket.SendTo(msg, (EndPoint)currentEndpoint);

                        Console.WriteLine("Sent {0} bytes to the server.\n", msg.Length);

                        EndPoint endp = (EndPoint)currentEndpoint;

                        try {

                            socket.ReceiveFrom(recvPacket, ref endp);

                            received = true;

                        }
                        catch (SocketException se) {                            

                            if (se.ErrorCode == 10060) Console.WriteLine("Timeout reached. Try {0} / {1}\n", ++tries, DEFAULT_RETRIES);

                            else Console.WriteLine("Socket exception thrown: {0}\n", se.ErrorCode);

                        }



                    } while (tries < DEFAULT_RETRIES && !received);

                    if (received) {

                        Console.WriteLine("Received {0} bytes from {1} : {2}\n", recvPacket.Length, currentEndpoint.Address, recvPacket);

                    }


                }

            }

            catch (SocketException se) {

                Console.WriteLine(se.Message);

            }

            return sentLength;

        }

        public int Read() {

            if (!(socket.Available > 0)) return -1;

            memset(readBuffer, 0, bytesReceived);

            bytesReceived = socket.Receive(readBuffer, bufferLength, SocketFlags.None);

            message = MessageParser.GetMessage(readBuffer);

            switch (message.COMMAND)
            {

                case Command.SEND:
                    {
                        Console.WriteLine("SEND received");

                        break;
                    }

                case Command.CLOSE:
                    {
                        Console.WriteLine("CLOSE received");

                        //not a good idea to close the system from an external event that is first invoked internally for the same purpose. What!?
                        ServerDisconnectedEvent.Invoke(this, EventArgs.Empty); ;

                        break;
                    }

                case Command.POST:
                    {

                        Console.WriteLine("POST received");

                        switch (message.ARGUMENTS) {

                            case Argument.SELF: {

                                    switch (message.OPTIONS) {

                                        case Option.NULLPARAM:
                                            {                                                
                                                break;
                                            }

                                        default: {

                                                ClientRecvEventArgs e = new ClientRecvEventArgs();

                                                e.endp = socket.RemoteEndPoint;

                                                e.message = message.OPTIONS;

                                                ClientReceiveEvent.Invoke(this, e);

                                                break;
                                            }

                                    }

                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine("Empty post command no arguments");

                                    break;

                                }
                        }

                        break;

                    }

                default:
                    {

                        Console.WriteLine("Command not parsed." + message.ToString());

                        break;
                    }
            }

            return bytesReceived;
        }

        public byte[] ReadRaw() {                        

            byte[] rec = new byte[100];

            bytesReceived = socket.Receive(rec, 100, SocketFlags.None);

            return rec;

        }
    }
}
