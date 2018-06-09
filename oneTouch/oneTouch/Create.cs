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
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql1 = "Provider=tbprov.Tbprov.6;User ID=hr;Password=tibero;   Data Source=tibero;Persist Security Info=True";
            OleDbConnection conn1 = new OleDbConnection(sql1);
            conn1.Open();
            int count = 0;

            OleDbCommand cmd1 = new OleDbCommand("select * from users", conn1);
            OleDbDataReader read = cmd1.ExecuteReader();


            while (read.Read())
            {
                string id = read.GetValue(0).ToString();
                if (ID_box.Text == id)
                {
                    MessageBox.Show("중복된 아이디 입니다!!");
                    count = 1;
                }
            }
            read.Close();
            conn1.Close();
            if (count == 0)
            {
                if (ID_box.Text == "" || PW_box.Text == "" || NAME_box.Text == "" || (radioButton1.Checked == false && radioButton2.Checked == false)|| textBox1.Text=="" || 
                    textBox2.Text==""|| textBox3.Text=="")
                {
                    MessageBox.Show("가입에 실패하였습니다. 입력되지 않은 값이 존재합니다!!");
                }
                else
                {
                    string sql = "Provider=tbprov.Tbprov.6;User ID=hr;Password=tibero;   Data Source=tibero;Persist Security Info=True";
                    OleDbConnection conn = new OleDbConnection(sql);

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into users (user_id,pw,name,man_age,man_sex,phone) values (?,?,?,?,?,?)";
                    cmd.Parameters.AddWithValue("@user_id", ID_box.Text);
                    cmd.Parameters.AddWithValue("@pw", PW_box.Text);
                    cmd.Parameters.AddWithValue("@name", NAME_box.Text);
                    DateTime dt = dateTimePicker1.Value;
                    cmd.Parameters.AddWithValue("@man_age", (System.DateTime.Now.Year + 1) - dt.Year);
         
                    if (radioButton1.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@man_sex", 0);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@man_sex", 1);
                    }
                    cmd.Parameters.AddWithValue("@phone", textBox1.Text+ textBox2.Text+ textBox3.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                   MessageBox.Show("가입이 완료되었습니다!!");
                    conn.Close();
                    this.Close();
                }
            }
        }

        private void Create_Load(object sender, EventArgs e)
        {
            textBox1.Text = "010";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
