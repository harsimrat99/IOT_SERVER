using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT_SERVER
{
    public class Encoder
    {        

        private const String ASCII = "ascii";

        private const String UTF_7 = "utf7";

        private byte Delimmiter { get; set; }
        public  int MAX_LENGTH {  get; private set ; }

        public const short DEFAULT_LENGTH_BUFFER = 50;

        public const byte DEFAULT_DELIM = (byte) 36; //"$"

        private Encoding encoding;

        //Encoding class

        public Encoder(int maxsz, String s) {

            MAX_LENGTH = maxsz;

            Delimmiter = DEFAULT_DELIM;

            if (s == ASCII) encoding = Encoding.ASCII;

            else if (s == UTF_7) encoding = Encoding.UTF7;

            else throw new ArgumentException("Invalid encoding argument.");

        }

        public byte[] Encode(byte[] message) {

            if (message.Length >= MAX_LENGTH) throw new FormatException("Message is larger than or equal to the maxmimum size of the readBuffer.");

            byte[] data = encoding.GetBytes(DateTime.Now.ToString("MM/dd/yyyy$HH:mm"));            

            byte[] encoded = new byte[message.Length + sizeof(byte) + data.Length];

            message.CopyTo(encoded, 0);

            encoded[message.Length] = Delimmiter;

            data.CopyTo(encoded, message.Length + 1);                        

            return encoded;

        }

        public void SetDelimmiter(byte delim) {

            this.Delimmiter = delim;
        }

    }

}
