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
    public partial class mewant2 : Form
    {
        private static int[] life2 = new int[6];
        public mewant2()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((radioButton5.Checked == false && radioButton13.Checked == false && radioButton15.Checked == false && radioButton16.Checked == false) ||
                (radioButton6.Checked == false && radioButton11.Checked == false && radioButton12.Checked == false) ||
                (radioButton7.Checked == false && radioButton9.Checked == false && radioButton10.Checked == false && radioButton14.Checked == false) ||
                (radioButton8.Checked == false && radioButton17.Checked == false && radioButton18.Checked == false && radioButton19.Checked == false) ||
                (radioButton20.Checked == false && radioButton21.Checked == false && radioButton22.Checked == false && radioButton23.Checked == false) ||
                (radioButton24.Checked == false && radioButton25.Checked == false && radioButton26.Checked == false)
                )
            {
                MessageBox.Show("선택하지 않은 사항이 있습니다!!");
            }
            else
            {
                //수면 시간대 체크
                if (radioButton16.Checked == true)
                    life2[0] = 0;
                else if (radioButton15.Checked == true)
                    life2[0] = 1;
                else if (radioButton13.Checked == true)
                    life2[0] = 2;
                else
                    life2[0] = 3;
                //흡연체크
                if (radioButton12.Checked == true)
                    life2[1] = 0;
                else if (radioButton11.Checked == true)
                    life2[1] = 1;
                else
                    life2[1] = 2;
                //음주 체크
                if (radioButton10.Checked == true)
                    life2[2] = 0;
                else if (radioButton14.Checked == true)
                    life2[2] = 1;
                else if (radioButton9.Checked == true)
                    life2[2] = 2;
                else
                    life2[2] = 3;
                //청결도 체크
                if (radioButton19.Checked == true)
                    life2[3] = 0;
                else if (radioButton18.Checked == true)
                    life2[3] = 1;
                else if (radioButton17.Checked == true)
                    life2[3] = 2;
                else
                    life2[3] = 3;
                //규칙 체크
                if (radioButton22.Checked == true)
                    life2[4] = 0;
                else if (radioButton21.Checked == true)
                    life2[4] = 1;
                else if (radioButton20.Checked == true)
                    life2[4] = 2;
                else
                    life2[4] = 3;
                //물품 공유 체크
                if (radioButton25.Checked == true)
                    life2[5] = 0;
                else if (radioButton26.Checked == true)
                    life2[5] = 1;
                else
                    life2[5] = 2;
                this.Close();
            }
        }
    }
}
