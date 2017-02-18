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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            block01.BlockNumber = "1";
            block01.PrevBlockHash = "0000000000000000000000000000000000000000000000000000000000000000";

            block01.recalculate();
        }

    }
}
