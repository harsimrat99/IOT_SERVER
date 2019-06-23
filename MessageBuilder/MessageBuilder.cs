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