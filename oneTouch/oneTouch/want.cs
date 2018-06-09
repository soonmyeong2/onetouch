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
    public partial class want : Form
    {
        private static string id, name, age;
        private static string[] info = new string[2];
        private static string[] mbti = new string[4];
        private static string[] life = new string[7];
        public want()
        {
            InitializeComponent();
        }
        public void set_id(string st)
        {
            id = st;
        }
        public void set_info(string f_name, string f_age)
        {
            name = f_name;
            age = f_age;
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
                   (radioButton20.Checked == false && radioButton21.Checked == false && radioButton22.Checked == false) || (radioButton24.Checked == false && radioButton25.Checked == false) ||
                   (textBox1.Text == "" || textBox2.Text == "")) 
            {
                MessageBox.Show("선택하지 않은 사항이 있습니다!!");
            }
            else
            {
                info[0] = textBox1.Text;
                info[1] = textBox2.Text;
                if (radioButton1.Checked == true)
                    mbti[0] = "0";
                else
                    mbti[0] = "1";
                if (radioButton4.Checked == true)
                    mbti[1] = "0";
                else
                    mbti[1] = "1";
                if (radioButton6.Checked == true)
                    mbti[2] = "0";
                else
                    mbti[2] = "1";
                if (radioButton8.Checked == true)
                    mbti[3] = "0";
                else
                    mbti[3] = "1";

                if (radioButton16.Checked == true)
                    life[0] = "0";
                else if (radioButton15.Checked == true)
                    life[0] = "1";
                else
                    life[0] = "2";
                life[1] = (radioButton12.Checked) ? "0" : "1";
                if (radioButton10.Checked == true)
                    life[2] = "0";
                else if (radioButton9.Checked == true)
                    life[2] = "1";
                else
                    life[2] = "2";
                if (radioButton19.Checked == true)
                    life[3] = "0";
                else if (radioButton18.Checked == true)
                    life[3] = "1";
                else
                    life[3] = "2";
                if (radioButton22.Checked == true)
                    life[4] = "0";
                else if (radioButton21.Checked == true)
                    life[4] = "1";
                else
                    life[4] = "2";
                life[5] = (radioButton25.Checked) ? "0" : "1";


                //여기 추가
                
                string sql = "Provider=tbprov.Tbprov.6;User ID=hr;Password=tibero;   Data Source=tibero;Persist Security Info=True";
                OleDbConnection conn = new OleDbConnection(sql);

                OleDbCommand cmd1 = new OleDbCommand("select * from character", conn);
                conn.Open();
                OleDbDataReader read = cmd1.ExecuteReader();
             
                string mbti_id="";
                while (read.Read())
                {
                    int count = 0;
                    for (int j = 1; j < 5; j++)
                    {
                        if (read.GetValue(j).ToString() == mbti[j - 1])
                        {
                            count++;
                            if(count==4)
                                mbti_id = read.GetValue(0).ToString();
                        }
                    }
                }
                read.Close();
                conn.Close();

                OleDbCommand cmd2 = new OleDbCommand("select * from life", conn);
                conn.Open();
                OleDbDataReader read2 = cmd2.ExecuteReader();

                string life_id = "";
                while (read2.Read())
                {
                    int count = 0;
                    for (int i = 1; i < 7; i++)
                    {
                        if (read2.GetValue(i).ToString() == life[i - 1])
                        {
                            count++;
                            if(count==6)
                            life_id = read2.GetValue(0).ToString();
                        }
                    }
                   
                
                }
                read2.Close();
                conn.Close();

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update users set name=?,man_age=?,character_id=?,life_id=? where user_id=?";
                cmd.Parameters.AddWithValue("@name", info[0]);
                cmd.Parameters.AddWithValue("@man_age", info[1]);
                cmd.Parameters.AddWithValue("@character_id", mbti_id);
                cmd.Parameters.AddWithValue("@life_id", life_id);
                cmd.Parameters.AddWithValue("@user_id", int.Parse(id));
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                {
                    MessageBox.Show("수정되었습니다!");
                    
                }
                conn.Close();
                //여기까지
                mewant want1 = new mewant();
                want1.set_id(id);
                want1.ShowDialog();
                this.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void want_Load(object sender, EventArgs e)
        {
            textBox1.Text = name;
            textBox2.Text = age;
        }
    }
}
