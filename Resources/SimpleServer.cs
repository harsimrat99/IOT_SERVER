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

    private int Port { get; set; }

    private Socket Socket = null;

    public SimpleServer(int port)
	{

        Port = port;

        try {



        }

        catch (Exception e) {


        }

	}



}
