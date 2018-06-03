using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oneTouch
{
    public partial class want : Form
    {
        public want()
        {
            InitializeComponent();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mewant want1 = new mewant();
            want1.ShowDialog();
            this.Close();
        }
    }
}
