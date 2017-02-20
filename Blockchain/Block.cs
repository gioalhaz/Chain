using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public delegate void NeedRecalculationDelegate(Block block);

    public class Block
    {
        private int difficalty = 0;
        private string blockNumber;
        private string prevBlockHash;
        private string data;

        public NeedRecalculationDelegate NeedRecalculationDelegate { set; private get; }

        public bool NeedRecalculation { set; get; }

        // Count of leading '0' characters
        public int Difficulty { set { difficalty = value; SetNeedRecalculationOn(); } get { return difficalty; } }

        public string BlockNumber { set { blockNumber = value; SetNeedRecalculationOn(); } get { return blockNumber; } }

        public int LastNonce { private set; get; }

        public TimeSpan LastPowTime { private set; get; }

        public string PrevBlockHash { set { prevBlockHash = value; SetNeedRecalculationOn(); } get { return prevBlockHash; } }

        public string Data { set { data = value; SetNeedRecalculationOn(); } get { return data; } }

        public string Pow { private set; get; }

        public void recalculate()
        {
            StringBuilder str = new StringBuilder();
            str.Append(BlockNumber).Append(Data).Append(PrevBlockHash);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            calculatePow(str.ToString(), Difficulty);

            stopWatch.Stop();

            LastPowTime = stopWatch.Elapsed;
            NeedRecalculation = false;
        }

        private void SetNeedRecalculationOn()
        {
            NeedRecalculation = true;
            NeedRecalculationDelegate?.Invoke(this);
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

                /*each value is in 4 bits*/
                for (int i = 0; i < zeroCount; i++)
                {
                    var value = goodHash[i/2] & ((i % 2 == 0) ? 0xF0 : 0x0F);
                    if (value != 0)
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

        private bool checkHash()
        {
            StringBuilder str = new StringBuilder();
            str.Append(BlockNumber).Append(Data).Append(PrevBlockHash).Append(LastNonce);

            SHA256 sha256 = SHA256Managed.Create();
            var bytes = Encoding.UTF8.GetBytes(str.ToString());

            // Bitcoin hashcash means double hash
            bytes = sha256.ComputeHash(bytes);
            var hash = sha256.ComputeHash(bytes);

            StringBuilder hashString = new StringBuilder();
            foreach (byte x in hash)
            {
                hashString.Append(String.Format("{0:x2}", x));
            }

            return hashString.ToString().CompareTo(Pow) == 0;
        }

        // Check POW string
        public bool CheckPow()
        {
            if (Pow == null || Pow.Length == 0)
                return false;

            bool result = true;

            // Check for leading 0s, then compare hash
            if (Pow.IndexOf("".PadLeft(Difficulty, '0'), 0, Difficulty) != 0
                || checkHash() == false)
                return false;

            return result;
        }

        public bool Check()
        {
            return CheckPow();
        }
    }
}
