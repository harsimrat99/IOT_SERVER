using System;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using IOT_SERVER;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;

public class SimpleServer : NetworkingServer
{
    private const int DEFAULT_NO_RESPONSE_CLOSE_SEC = 30 * 60;

    private const int DEFAULT_NOT_ACTIVE_TIME_SEC = 7 * 60;

    private const int DEFAULT_CLEAN_INTERVAL = 5 * 60 * 1000;

    private Hashtable  ClientsList;

    private ArrayList ClientsToServiced = new ArrayList(5);

    private int i = 0;

    private object MyLock = new object();

    private Timer Cleaner;

    private Message message = new Message("", "", "");

    private MessageBuilder builder = new MessageBuilder();

    private DateTime startup = DateTime.Now;

    public SimpleServer(int port, int listeners)
	{

        Listeners = listeners;

        ClientsList = new Hashtable(Listeners);

        Port = port;
        
    }

    public  SimpleServer(int port) {

        Port = port;

        Listeners = DEFAULT_LISTENERS;

        ClientsList = new Hashtable(Listeners);

    }

    [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern int memset(byte[] b1, byte val, int length);

    public override string Init()
    {
        

        try
        {            

            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Server.Bind(new IPEndPoint(IPAddress.Any, Port));

            Server.ReceiveTimeout = DEFAULT_TIMEOUT_RECEIVE;

            Server.Listen(Listeners);            
                       
            recvBuffer = new byte[DEFAULT_BUFFER_SIZE]; ;

        }

        catch (SocketException e)
        {

            Console.WriteLine(e.Message);

            return "PROBLEM INITIALISING SERVER";

        }

        recvBuffer = new byte[DEFAULT_BUFFER_SIZE];

        this.Cleaner = new Timer();

        this.Cleaner.Interval = DEFAULT_CLEAN_INTERVAL;

        this.Cleaner.Enabled = true;

        this.Cleaner.Elapsed += Clean;

        return "SUCCESFULLY INITIALISED AT PORT " + Port.ToString();

    }

    public override void Accept() {

        if (Server.Poll(DEFAULT_POLL_MICROS, SelectMode.SelectRead))
        {
            ++i;            

            Random r = new Random();

            int secret = Math.Abs(r.Next() * i *  (int) (DateTime.Now - startup).TotalSeconds);

            Client c = new Client
            {
                lastActiveMillis = DateTime.Now,

                socket = Server.Accept(),

                key = secret
            };

            ClientsList.Add(secret, c);

            ((Client)ClientsList[secret]).socket.ReceiveTimeout = DEFAULT_TIMEOUT_RECEIVE;

            AcceptEventArgs ae = new AcceptEventArgs
            {
                endp = ((Client)ClientsList[secret]).socket.RemoteEndPoint,

                Name = secret.ToString()
            };

            base.OnAcceptEvent(ae);
            
        }
        
    }

    public override void Close() {

        RemoveAllClients();

        Server.Close();        

    }

    public void GetMessage()
    {

        lock (MyLock)
        {

            foreach (DictionaryEntry Client in ClientsList)
            {

                if (((Client)Client.Value).socket.Available > 0)
                {

                    ((Client)Client.Value).lastActiveMillis = DateTime.Now;

                    ReceiveMessageEventArgs args = new ReceiveMessageEventArgs();

                    args.endp = ((Client)Client.Value).socket.RemoteEndPoint;

                    args.key = (int) (Client.Key);

                    ClientsToServiced.Add((args));
                   
                }

            }

            ParseMessages();

        }


    }

    private void ParseMessages() {

        if (ClientsToServiced.Count == 0) return;

        int bytesReceived = DEFAULT_BUFFER_SIZE;

        for (int i = 0; i < ClientsToServiced.Count; i++)
        {

            memset(recvBuffer, 0, bytesReceived);

            bytesReceived = ((Client)ClientsList[((ReceiveMessageEventArgs)ClientsToServiced[i]).key]).socket.Receive(recvBuffer, recvBuffer.Length, SocketFlags.None);

            message = MessageParser.GetMessage(recvBuffer);

            switch (message.COMMAND) {

                case Command.SEND:
                    {
                        int key = Int32.Parse(message.ARGUMENTS);

                        if (ClientsList.Contains(key)) SendMessage(key, ((ReceiveMessageEventArgs)ClientsToServiced[i]).endp + " : " + (message.OPTIONS));

                        break;
                    }

                case Command.CLOSE:
                    {

                        RemoveClient(((ReceiveMessageEventArgs)ClientsToServiced[i]).key);

                        base.OnCloseConnection(new CloseConnectionEventArgs { Key = ((ReceiveMessageEventArgs)ClientsToServiced[i]).key });

                        break;
                    }

                case Command.POST:
                    {

                        switch (message.ARGUMENTS) {


                            case Argument.NULLARGS:

                                break;

                            case Argument.SERVER:

                                ((ReceiveMessageEventArgs)ClientsToServiced[i]).message = message.OPTIONS;

                                base.OnReceiveMessage(((ReceiveMessageEventArgs)ClientsToServiced[i]));

                                break;

                            case Argument.ON:

                                break;

                            case Argument.OFF:

                                break;

                            default:

                                break;

                        }

                        break;
                        //
                    }

                case Command.ECHOBACK: {

                        switch (message.ARGUMENTS)
                        {
                            case Argument.SERVER:
                                {
                                    switch (message.OPTIONS)
                                    {

                                        case Option.KEY:
                                            {
                                                Message m;

                                                m = builder.CreateMessage(Command.POST, Argument.SELF, ((ReceiveMessageEventArgs)ClientsToServiced[i]).key.ToString());

                                                int key = ((ReceiveMessageEventArgs)ClientsToServiced[i]).key;

                                                SendMessage(key, builder.GetBytes(m));

                                                break;
                                            }

                                    }

                                    break;
                                }                                

                        }


                        break;

                }

                default: {

                        ((ReceiveMessageEventArgs)ClientsToServiced[i]).message = "Command not parsed" + message.OPTIONS;

                        base.OnReceiveMessage(((ReceiveMessageEventArgs)ClientsToServiced[i]));

                        break;
                }
            }


        }

        ClientsToServiced.Clear();

    }

    public int SendMessage(int key, string message) {

        this.message.COMMAND = Command.POST;
        this.message.ARGUMENTS = Argument.SELF;
        this.message.OPTIONS = message;

        SendMessage(key, builder.GetBytes(this.message));

        return -1;
    }

    public int SendMessage(int key, byte[] buff)
    {

        try
        {

            ((Client)ClientsList[key]).socket.Send(buff, buff.Length, SocketFlags.None);

        }

        catch (Exception e)
        {

            Console.WriteLine(e.Message);

        }

        return 1;

    }

    public override void RemoveClient(int key)
    {
        lock (MyLock)
        {

            Message close = new Message(Command.CLOSE, Argument.NULLARGS, Option.NULLPARAM);

            MessageBuilder mb = new MessageBuilder();

            try { this.SendMessage(key, mb.GetBytes(close)); }

            catch (Exception) { }

            ((Client)ClientsList[key]).socket.Close();

            ClientsList.Remove((int) key);
        }

        base.OnCloseConnection(new CloseConnectionEventArgs { Key = key});
    }

    public void RemoveAllClients()
    {
        Message close = new Message(Command.CLOSE, Argument.NULLARGS, Option.NULLPARAM);

        MessageBuilder mb = new MessageBuilder();

        foreach (DictionaryEntry client in ClientsList)

        {
            try { this.SendMessage(((int)client.Key), mb.GetBytes(close)); }

            catch (Exception) { }

            ((Client)client.Value).socket.Close();

            base.OnCloseConnection(new CloseConnectionEventArgs { Key = ((int)client.Key) });

        }

        ClientsList.Clear();
    }

    private void Clean(object s, EventArgs e) {        

        lock (MyLock) {

            foreach (DictionaryEntry value in ClientsList) {

                

                if ( (DateTime.Now - ((Client)value.Value).lastActiveMillis).TotalSeconds > DEFAULT_NO_RESPONSE_CLOSE_SEC) {

                    ClientsToServiced.Add(value.Key);

                }

               else if ((DateTime.Now - ((Client)value.Value).lastActiveMillis).TotalSeconds > DEFAULT_NOT_ACTIVE_TIME_SEC)
                {

                    ReceiveMessageEventArgs args = new ReceiveMessageEventArgs { key = (int)value.Key, message = "CHANGE_ACTIVE_TO_FALSE" };

                    base.OnReceiveMessage(args);

                }

            }
        

            for (int i = 0; i < ClientsToServiced.Count; i++) {

                RemoveClient((int)ClientsToServiced[i]);

            }

            ClientsToServiced.Clear();

        }

    }

}



