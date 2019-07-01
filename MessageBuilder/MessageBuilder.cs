using System.Text;

namespace IOT_SERVER
{
   public class MessageBuilder
    {
        public MessageBuilder() { }

        public Message CreateMessage(string command, string args, string param)
        {

            Message msg = new Message(command, args, param);

            return msg;

        }

        public Message CreateMessage(string message)
        {

            Message msg = new Message("","","");

            int index = message.IndexOf(Message.DEAFULT_DELIM_STRING);

            if (index < 0) throw new System.Exception("Could not create message. Input string corrupted.");

            msg.COMMAND = message.Substring(0, index).ToUpper();

            int prev = index;

            index = message.IndexOf(Message.DEAFULT_DELIM_STRING, index + 1);

            if (index < 0) throw new System.Exception("Could not create message. Input string corrupted.");

            msg.ARGUMENTS = message.Substring(prev + 1, index - prev - 1).ToUpper();

            msg.OPTIONS = message.Substring(index + 1);            

            return msg;
        }


        public byte[] GetBytes(Message m)
        {

            int first = m.COMMAND.Length, second = m.ARGUMENTS.Length, third = m.OPTIONS.Length;

            int size = first + second + third + 3;

            byte[] buffer = new byte[size];

            Encoding.ASCII.GetBytes(m.COMMAND).CopyTo(buffer, 0);

            buffer[first] =  m.DELIMMITER[0];

            Encoding.ASCII.GetBytes(m.ARGUMENTS).CopyTo(buffer, first + 1);

            buffer[first + second + 1] = m.DELIMMITER[0];

            Encoding.ASCII.GetBytes(m.OPTIONS).CopyTo(buffer, first + second + 2);

            buffer[size - 1] = m.DELIMMITER[0];

            return buffer;
        }

    }

}