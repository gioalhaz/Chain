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

            InitBlockchain();
        }

        private void InitBlockchain()
        {
            chain.Init(5, (int)upDownDifficulty.Value);

            foreach (var block in chain.Chain)
            {
                var blockControl = new BlockControl.BlockControl();
                blockControl.Block = block;
                flowLayoutPanel1.Controls.Add(blockControl);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            chain.Difficulty = (int)upDownDifficulty.Value;
            chain.recalculate();
            foreach (var control in flowLayoutPanel1.Controls)
            {
                ((BlockControl.BlockControl)control).refreshControls();
            }

            Cursor.Current = Cursors.Default;
        }

    }
}
