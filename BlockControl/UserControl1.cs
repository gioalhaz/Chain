using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace BlockControl
{
    public partial class BlockControl: UserControl
    {
        private bool internalSet = false;
        private string data;

        public BlockControl()
        {
            InitializeComponent();
        }

        public string BlockNumber { set; get; }

        public int LastNonce { set; get; }

        public string PrevBlockHash { set; get; }

        public string Pow { get; private set; }

        public string Data
        {
            set { textData.Text = value; } // it will fire event where data field would be set
            get { return data; }
        }

        public void recalculate()
        {
            StringBuilder str = new StringBuilder();

            str.Append(BlockNumber).Append(Data).Append(PrevBlockHash);
            calculatePow(str.ToString(), 2 /*two 0 bytes -- 4 leading 0-s*/);

            textNonce.Text = LastNonce.ToString();
            textPow.Text = Pow;
        }

        private void calculatePow(string blockData, int zeroCount)
        {
            int nonce = 0;
            byte[] goodHash = null;

            SHA256 sha256 = SHA256Managed.Create();
            do {
                nonce++;

                var bytes = Encoding.UTF8.GetBytes(blockData + nonce.ToString());

                goodHash = sha256.ComputeHash(bytes);

                for (int i = 0; i < zeroCount; i++)
                {
                    if (goodHash[i] != 0)
                    {
                        goodHash = null;
                        break;
                    }
                }

            } while(goodHash == null);

            StringBuilder hashString = new StringBuilder();
            foreach (byte x in goodHash)
            {
                hashString.Append(String.Format("{0:x2}", x));
            }

            Pow = hashString.ToString();
            LastNonce = nonce;
        }

        private void textData_TextChanged(object sender, EventArgs e)
        {
            data = textData.Text;
        }
    }
}
