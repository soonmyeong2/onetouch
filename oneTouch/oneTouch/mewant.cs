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
    public partial class mewant : Form
    {
        private static string[] roominfo = new string[5];
        private static char[] mbtiinfo = new char[4];
        private static string[] age_range = new string[2];
        private static int[] religion = new int[2];
        public mewant()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //textBox1.Text = trackBar1.Value.ToString();
        }

        private void mewant_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            //trackBar1.Value = Convert.ToInt32(textBox1.Text);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //textBox2.Text = trackBar2.Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //trackBar2.Value = Convert.ToInt32(textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox5.Text == "" || textBox2.Text == "" || textBox1.Text == "" || textBox3.Text == "" ||
                (radioButton10.Checked == false && radioButton9.Checked == false) || (radioButton4.Checked == false && radioButton3.Checked == false)
                || (radioButton2.Checked == false && radioButton1.Checked == false) || (radioButton8.Checked == false && radioButton7.Checked == false) ||
                textBox4.Text == "" || textBox6.Text == "" )
            {
                MessageBox.Show("선택하지 않은 사항이 있습니다!!");
            }
            else
            {
                roominfo[0] = comboBox1.Text;
                roominfo[1] = textBox5.Text;
                roominfo[2] = textBox2.Text;
                roominfo[3] = textBox1.Text;
                roominfo[4] = textBox3.Text;

                mbtiinfo[0] = radioButton10.Checked ? 'e' : 'i';
                mbtiinfo[1] = radioButton4.Checked ? 's' : 'n';
                mbtiinfo[2] = radioButton2.Checked ? 't' : 'f';
                mbtiinfo[3] = radioButton8.Checked ? 'j' : 'p';

                age_range[0] = textBox4.Text;
                age_range[1] = textBox6.Text;


                mewant2 want2 = new mewant2();
                want2.ShowDialog();
                this.Close();
            }
        }
    }
}
