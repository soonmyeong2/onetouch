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
    public partial class _main : System.Windows.Forms.Form
    {
        public _main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void _main_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Create sign = new Create();
            sign.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client sign = new Client();
            sign.ShowDialog();
        }
    }
}
