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
using Blockchain;

namespace BlockControl
{
    public partial class BlockControl: UserControl
    {
        private Block block;

        public BlockControl()
        {
            InitializeComponent();
            //MediumSeaGreen
            //Salmon
            BackColor = Color.MediumSeaGreen;
        }

        public Block Block
        {
            set
            {
                block = value;
                publishData();
            }

            get
            {
                return block;
            }
        }

        public string BlockNumber
        {
            set { block.BlockNumber = value; textNumber.Text = value; }
            get { return block.BlockNumber; }
        }

        public string Data
        {
            set { block.Data = value; textData.Text = value; }
            get { return block.Data; }
        }

        public string PrevBlockHash
        {
            set { block.PrevBlockHash = value; textPrevBlock.Text = value; }
            get { return block.PrevBlockHash; }
        }

        public void recalculate()
        {
            //Block.BlockNumber = textNumber.Text;
            //Block.Data = textData.Text;
            //Block.PrevBlockHash = textPrevBlock.Text;

            block.Difficulty = 2; /*two 0 bytes -- 4 leading 0-s*/
            block.recalculate();

            publishData();
        }

        private void publishData()
        {
            textNumber.Text = block.BlockNumber;
            textNonce.Text = block.LastNonce.ToString();
            textData.Text = block.Data;
            textPrevBlock.Text = block.PrevBlockHash;
            textPow.Text = block.Pow;
        }

        public void check()
        {
            if (block.Check() == false)
            {

            }
        }

        private void textData_TextChanged(object sender, EventArgs e)
        {
            block.Data = textData.Text;
        }
    }
}
