using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chain
{
    public partial class Form1 : Form
    {
        private Blockchain.Blockchain chain = new Blockchain.Blockchain();

        public Form1()
        {
            InitializeComponent();
            upDownDifficulty.Value = Blockchain.Blockchain.DEFAULT_DIFFICALTY;
            upDownBlockCount.Value = 5;

            InitBlockchain();
        }

        public void NeedRecalculationCallback(Blockchain.Block block)
        {
            chain.checkLinks();
            refreshBlockControls();
        }

        private void InitBlockchain()
        {
            chain.Init((int)upDownBlockCount.Value, (int)upDownDifficulty.Value);

            foreach (var block in chain.Chain)
            {
                var blockControl = new BlockControl.BlockControl();
                blockControl.Block = block;
                blockControl.NeedRecalculationDelegate = NeedRecalculationCallback;
                flowLayoutPanel1.Controls.Add(blockControl);
            }
        }

        private void refreshBlockControls()
        {
            foreach (var control in flowLayoutPanel1.Controls)
            {
                ((BlockControl.BlockControl)control).refreshControls();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            chain.Difficulty = (int)upDownDifficulty.Value;
            chain.recalculate();

            refreshBlockControls();

            Cursor.Current = Cursors.Default;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            int blockCount = (int)upDownBlockCount.Value;
            if (blockCount > 0)
            {
                flowLayoutPanel1.Controls.Clear();
                InitBlockchain();
            }

            Cursor.Current = Cursors.Default;
        }
    }
}
