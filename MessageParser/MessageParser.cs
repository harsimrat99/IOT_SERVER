using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT_SERVER
{
    public class MessageParser
    {        

        public static Message GetMessage(byte[] message)
        {
            Message msg = new Message("", "", "");

            try
            {
                int index = Array.IndexOf(message, (byte)Message.DEFAULT_DELIM);

                int last = index;

                msg.COMMAND = Encoding.ASCII.GetString(message, 0, index);

                //Console.WriteLine(msg.COMMAND);

                index = Array.IndexOf(message, (byte)Message.DEFAULT_DELIM, index + 1) - index - 1;

                msg.ARGUMENTS = Encoding.ASCII.GetString(message, last + 1, index);

                //Console.WriteLine(msg.ARGUMENTS);

                last += index + 1;

                //Console.WriteLine(last);

                index = Array.IndexOf(message, (byte)Message.DEFAULT_DELIM, last + 1) - last - 1;

                msg.OPTIONS = Encoding.ASCII.GetString(message, last + 1, index);

                //Console.WriteLine(msg.OPTIONS);
            }

            catch (Exception) {

                return msg;

            }

            return msg;

        }        
    }
}
