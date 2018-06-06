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
            string sql = "Provider=tbprov.Tbprov.6;User ID=hr;Password=tibero;   Data Source=tibero;Persist Security Info=True";
            OleDbConnection conn = new OleDbConnection(sql);
            conn.Open();


            OleDbCommand cmd = new OleDbCommand("select * from users", conn);
            OleDbDataReader read = cmd.ExecuteReader();

            int count = 0;
            while (read.Read())
            {
                string id = read.GetValue(0).ToString();
                string pw = read.GetValue(1).ToString();
                if (textBox1.Text == id && textBox2.Text == pw)
                {
                    count = 1;
                    Console.WriteLine("로그인 성공!!");

                    Client sign = new Client();
                    sign.PassUserID = textBox1.Text;
                    sign.ShowDialog();
                }
            }
            if (count == 0)
                MessageBox.Show("아이디나 비밀번호가 올바르지 않습니다.");
            
            read.Close();
            conn.Close();
        }
    }
}
