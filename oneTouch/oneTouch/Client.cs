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
    public partial class Client : Form
    {
        string id;

        public Client()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.BeginUpdate();

            listView1.Columns.Add("ID");
            listView1.Columns.Add("이름");
            listView1.Columns.Add("나이");

            tabPage1.Text = @"룸메이트 찾기";
            tabPage2.Text = @"메세지 함";
            MessageBox.Show(id);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void set_id(string st)
        {
            id = st;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            want want1 = new want();
            want1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;

            switch(selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    // 구조체 생성
                    for (int i = 0; i < 5; i++)
                    {
                        ListViewItem item1 = new ListViewItem("Something"+i);
                        item1.SubItems.Add("SubItem1a");
                        item1.SubItems.Add("SubItem1b");
                        listView1.Items.AddRange(new ListViewItem[] { item1 });
                        //쿼리문
                    }
                    break;
                case 2:
                    //쿼리문
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Client_Load(object sender, EventArgs e)
        {
            
        }
        
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                    id = listView1.GetItemAt(e.X, e.Y).Text;
                }
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void 메세지보내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(id);
            msgbox want1 = new msgbox();
            want1.ShowDialog();
        }

        private void 상세보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("이름 :" );
            info want1 = new info();
            want1.ShowDialog();
        }
    }
}
