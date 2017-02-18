using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public class Block
    {
        public int Difficulty { set; get; }

        public string BlockNumber { set; get; }

        public int LastNonce { set; get; }

        public string PrevBlockHash { set; get; }

        public string Data { set; get; }

        public string Pow { get; private set; }

        public void recalculate()
        {
            StringBuilder str = new StringBuilder();

            str.Append(BlockNumber).Append(Data).Append(PrevBlockHash);
            calculatePow(str.ToString(), Difficulty/2);
        }

        private void calculatePow(string blockData, int zeroCount)
        {
            int nonce = 0;
            byte[] goodHash = null;

            SHA256 sha256 = SHA256Managed.Create();
            do
            {
                nonce++;

                var bytes = Encoding.UTF8.GetBytes(blockData + nonce.ToString());

                // Bitcoin hashcash means double hash
                bytes = sha256.ComputeHash(bytes);
                goodHash = sha256.ComputeHash(bytes);

                for (int i = 0; i < zeroCount; i++)
                {
                    if (goodHash[i] != 0)
                    {
                        goodHash = null;
                        break;
                    }
                }

            } while (goodHash == null);

            StringBuilder hashString = new StringBuilder();
            foreach (byte x in goodHash)
            {
                hashString.Append(String.Format("{0:x2}", x));
            }

            Pow = hashString.ToString();
            LastNonce = nonce;
        }

        public bool CheckPow()
        {
            bool result = true;
             
            var chars = Pow.ToCharArray();
            for (int i = 0; i < Difficulty; i++)
            {
                if (chars[i] != '0')
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
