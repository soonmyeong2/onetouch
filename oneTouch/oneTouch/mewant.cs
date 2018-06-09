using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
        private static string[] mbtiinfo = new string[4];
        private static string[] age_range = new string[2];
        private static string id;
        public mewant()
        {
            InitializeComponent();
        }
        public void set_id(string st)
        {
            id = st;
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
                (radioButton10.Checked == false && radioButton9.Checked == false && radioButton5.Checked == false) || (radioButton4.Checked == false && radioButton3.Checked == false && radioButton12.Checked == false)
                || (radioButton2.Checked == false && radioButton1.Checked == false && radioButton6.Checked == false) || (radioButton8.Checked == false && radioButton7.Checked == false && radioButton11.Checked == false) ||
                textBox4.Text == "" || textBox6.Text == "" )
            {
                MessageBox.Show("선택하지 않은 사항이 있습니다!!");
            }
            else
            {
                roominfo[0] = comboBox1.SelectedIndex.ToString();
                roominfo[1] = textBox5.Text;
                roominfo[2] = textBox2.Text;
                roominfo[3] = textBox1.Text;
                roominfo[4] = textBox3.Text;

                if (radioButton10.Checked == true)
                    mbtiinfo[0] = "0";
                else if (radioButton9.Checked == true)
                    mbtiinfo[0] = "1";
                else
                    mbtiinfo[0] = "2";
                if (radioButton2.Checked == true)
                    mbtiinfo[1] = "0";
                else if (radioButton1.Checked == true)
                    mbtiinfo[1] = "1";
                else
                    mbtiinfo[1] = "2";
                if (radioButton8.Checked == true)
                    mbtiinfo[2] = "0";
                else if (radioButton7.Checked == true)
                    mbtiinfo[2] = "1";
                else
                    mbtiinfo[2] = "2";
                if (radioButton4.Checked == true)
                    mbtiinfo[3] = "0";
                else if (radioButton3.Checked == true)
                    mbtiinfo[3] = "1";
                else
                    mbtiinfo[3] = "2";
               
                age_range[0] = textBox4.Text;
                age_range[1] = textBox6.Text;

                string sql = "Provider=tbprov.Tbprov.6;User ID=hr;Password=tibero;   Data Source=tibero;Persist Security Info=True";
                OleDbConnection conn = new OleDbConnection(sql);

                OleDbCommand cmd1 = new OleDbCommand("select * from like_character", conn);
                conn.Open();
                OleDbDataReader read = cmd1.ExecuteReader();

                string mbti_id = "";
                while (read.Read())
                {
                    int count = 0;
                    for (int j = 1; j < 5; j++)
                    {
                        if (read.GetValue(j).ToString() == mbtiinfo[j - 1])
                        {
                            count++;
                            if (count == 4)
                                mbti_id = read.GetValue(0).ToString();
                        }
                    }
                }
                read.Close();
                conn.Close();

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update users set location=?,roomsize_min=?,roomsize_max=?,monthlyrent_min=?,monthlyrent_max=?, like_character_id=?,man_age_min=?,man_age_max=? where user_id=?";
                cmd.Parameters.AddWithValue("@location", roominfo[0]);
                cmd.Parameters.AddWithValue("@roomsize_min", roominfo[1]);
                cmd.Parameters.AddWithValue("@roomsize_max", roominfo[2]);
                cmd.Parameters.AddWithValue("@monthlyrent_min", roominfo[3]);
                cmd.Parameters.AddWithValue("@monthlyrent_max", roominfo[4]);
                cmd.Parameters.AddWithValue("@like_character_id", mbti_id);
                cmd.Parameters.AddWithValue("@man_age_min", age_range[0]);
                cmd.Parameters.AddWithValue("@man_age_max", age_range[1]);
                cmd.Parameters.AddWithValue("@user_id", id);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                {
                    MessageBox.Show("수정되었습니다!");
                   
                }
                conn.Close();
                mewant2 want2 = new mewant2();
                want2.set_id(id);
                want2.ShowDialog();
                this.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
