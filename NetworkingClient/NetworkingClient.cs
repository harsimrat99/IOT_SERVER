using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;

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

        //private NetworkStream netStream;

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int memset(byte[] b1, byte val, int length);

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


        protected int Init (ProtoType type, String server, int port, int buffSize) {

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

            return 1;

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

                throw new SocketException(se.ErrorCode);

                return -1;

            }

            Console.WriteLine("Socket closed succesfully.");

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

        public int Write(String msg) {

            Message newMsg = new Message(Command.SEND, msg.Substring(0, 1 + msg.IndexOf("|")), msg.Substring(1+ msg.IndexOf("|")));

            MessageBuilder mb = new MessageBuilder();

            this.Write(mb.GetBytes(newMsg));

            return 1;


        }

        public int Write(byte[] msg) {

            int sentLength = msg.Length;

            try {

                if (this._type == ProtoType.TCP) sentLength = socket.Send(msg, SocketFlags.None);

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

                return -1;

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
                      
                        break;
                    }

                case Command.CLOSE:
                    {
                        ServerDisconnectedEvent.Invoke(this, EventArgs.Empty); ;

                        break;
                    }

                case Command.POST:
                    {

                        switch (message.ARGUMENTS) {


                            case Argument.ON: {

                                    ClientRecvEventArgs args = new ClientRecvEventArgs();

                                    args.endp = socket.RemoteEndPoint;

                                    args.message = "ON";

                                    ClientReceiveEvent.Invoke(this, args);

                                    break;

                                }



                            case Argument.OFF: {

                                    ClientRecvEventArgs args = new ClientRecvEventArgs();

                                    args.endp = socket.RemoteEndPoint;

                                    args.message = "OFF";

                                    ClientReceiveEvent.Invoke(this, args);

                                    break;

                                }

                            default:

                                ClientRecvEventArgs e = new ClientRecvEventArgs();

                                e.endp = socket.RemoteEndPoint;

                                e.message = message.ARGUMENTS;

                                ClientReceiveEvent.Invoke(this, e);

                                break;


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
        
    }
}
