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
        private Color OkColor = Color.MediumSeaGreen;
        private Color ErrorColor = Color.Salmon;

        private Block block;

        public BlockControl()
        {
            InitializeComponent();
            BackColor = OkColor;
        }

        public Block Block
        {
            set
            {
                block = value;
                if (block != null)
                    block.NeedRecalculationDelegate = NeedRecalculationDelegate;

                refreshControls();
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
            block.Difficulty = 2; /*two 0 bytes -- 4 leading 0-s*/
            block.recalculate();

            refreshControls();
        }

        public void refreshControls()
        {
            if (block == null)
            {
                textNumber.Text = "";
                textNonce.Text = "";
                labelTimeSpan.Text = "";
                textData.Text = "";
                textPrevBlock.Text = "";
                textPow.Text = "";

                BackColor = ErrorColor;
            }
            else
            {
                textNumber.Text = block.BlockNumber ?? "";
                textNonce.Text = block.LastNonce.ToString();
                labelTimeSpan.Text = block.LastPowTime.ToString(@"hh\:mm\:ss\.fff");
                textData.Text = block.Data ?? "";
                textPrevBlock.Text = block.PrevBlockHash ?? "";
                textPow.Text = block.Pow ?? "";

                BackColor = block.NeedRecalculation ? ErrorColor : OkColor;
            }

            toolTips.SetToolTip(textPow, textPow.Text);
            toolTips.SetToolTip(textPrevBlock, textPrevBlock.Text);
        }

        public void check()
        {
            if (block.Check() == false)
            {
                BackColor = ErrorColor;
            }
            else
            {
                BackColor = OkColor;
            }
        }

        public void NeedRecalculationDelegate(Block block)
        {
            BackColor = block.NeedRecalculation ? ErrorColor : OkColor;
        }

        private void textData_TextChanged(object sender, EventArgs e)
        {
            block.Data = textData.Text;
        }
    }
}
