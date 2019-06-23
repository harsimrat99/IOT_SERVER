using System.ComponentModel;

namespace IOT_SERVER
{
    public struct Message
    {
        public string COMMAND { get; set; }
        public string ARGUMENTS { get; set; }
        public string OPTIONS { get; set; }

        public const byte DEFAULT_DELIM = 124;

        public byte[] DELIMMITER;

        public Message(string command, string args, string op)  {

            COMMAND = command;

            ARGUMENTS = args;

            OPTIONS = op;

            DELIMMITER = new byte[1];

            DELIMMITER[0] = DEFAULT_DELIM;
        }

        public override string ToString()
        {
            return COMMAND + "\\" + DELIMMITER[0] + "\\" + ARGUMENTS + "\\" + DELIMMITER[0] + "\\" + OPTIONS;
        }

    }
}