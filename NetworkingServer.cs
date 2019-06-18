using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IOT_SERVER
{
    public abstract class NetworkingServer
    {        
        protected const int DEFAULT_LISTENERS = 5;

        protected const int DEFAULT_BUFFER_SIZE = 100;

        protected const int DEFAULT_TIMEOUT_RECEIVE = 1000;

        //5 milli seconds
        protected const int DEFAULT_POLL_MICROS = 50000;

        protected byte[] recvBuffer;

        protected int Port { get; set; }

        protected int Listeners { get; set; }

        protected Socket Server = null;

        public event EventHandler<AcceptEventArgs> AcceptEvent;

        public event EventHandler <CloseConnectionEventArgs> ConnectionClosed;

        public const int DEFAULT_SERVER_PORT = 8080;

        public abstract string Init();

        public abstract void Close();

        public abstract void Accept();

        public class AcceptEventArgs : EventArgs
        {

            public EndPoint endp;

            public string Name;

        }

        public class CloseConnectionEventArgs : EventArgs {

            public EndPoint endp;

            public string Name;

        }

        protected void OnAcceptEvent(AcceptEventArgs ae)
        {

            AcceptEvent.Invoke(this, ae);

        }

        protected void OnCloseConnection(CloseConnectionEventArgs e) {

            ConnectionClosed.Invoke(this,e);

        }

    }

}
