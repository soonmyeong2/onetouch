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
        private static string[] info = new string[2];
        private static int[] mbti = new int[4];
        private static int[] life = new int[7];
        public want()
        {
            InitializeComponent();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((radioButton1.Checked == false && radioButton2.Checked == false) || (radioButton3.Checked == false && radioButton4.Checked == false) ||
                  (radioButton5.Checked == false && radioButton6.Checked == false) || (radioButton7.Checked == false && radioButton8.Checked == false) ||
                  (radioButton13.Checked == false && radioButton15.Checked == false && radioButton16.Checked == false) || (radioButton11.Checked == false && radioButton12.Checked == false) ||
                  (radioButton9.Checked == false && radioButton10.Checked == false && radioButton14.Checked == false) || (radioButton17.Checked == false && radioButton18.Checked == false && radioButton19.Checked == false) ||
                  (radioButton20.Checked == false && radioButton21.Checked == false && radioButton22.Checked == false) || (radioButton24.Checked == false && radioButton25.Checked == false)  ||
                  textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("선택하지 않은 사항이 있습니다!!");
            }
            else
            {
                info[0] = textBox1.Text;
                info[1] = textBox2.Text;
                if (radioButton1.Checked == true)
                    mbti[0] = 0;
                else
                    mbti[0] = 1;
                if (radioButton4.Checked == true)
                    mbti[1] = 0;
                else
                    mbti[1] = 1;
                if (radioButton6.Checked == true)
                    mbti[2] = 0;
                else
                    mbti[2] = 1;
                if (radioButton8.Checked == true)
                    mbti[3] = 0;
                else
                    mbti[3] = 1;

                if (radioButton16.Checked == true)
                    life[0] = 0;
                else if (radioButton15.Checked == true)
                    life[0] = 1;
                else
                    life[0] = 2;
                life[1] = (radioButton12.Checked) ? 0 : 1;
                if (radioButton10.Checked == true)
                    life[2] = 0;
                else if (radioButton9.Checked == true)
                    life[2] = 1;
                else
                    life[2] = 2;
                if (radioButton19.Checked == true)
                    life[3] = 0;
                else if (radioButton18.Checked == true)
                    life[3] = 1;
                else
                    life[3] = 2;
                if (radioButton22.Checked == true)
                    life[4] = 0;
                else if (radioButton21.Checked == true)
                    life[4] = 1;
                else
                    life[4] = 2;
                life[5] = (radioButton25.Checked) ? 0 : 1;

                mewant want1 = new mewant();
                want1.ShowDialog();
                this.Close();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
