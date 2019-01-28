using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


public struct user
{
    public string user_id, name, man_age, man_age_min, man_age_max, man_sex, location, monthlyrent_min, monthlyrent_max, roomsize_min, roomsize_max, sleep, smoke, drink, tidy, rule, sharing, like_sleep, like_smoke, like_drink, like_tidy, like_rule, like_sharing, MBTI_1, MBTI_2, MBTI_3, MBTI_4, like_MBTI_1, like_MBTI_2, like_MBTI_3, like_MBTI_4;


    public user(string user_id, string name, string man_age, string man_age_min, string man_age_max, string man_sex, string location, string monthlyrent_min, string monthlyrent_max, string roomsize_min, string roomsize_max, string sleep, string smoke, string drink, string tidy, string rule, string sharing, string like_sleep, string like_smoke, string like_drink, string like_tidy, string like_rule, string like_sharing, string MBTI_1, string MBTI_2, string MBTI_3, string MBTI_4, string like_MBTI_1, string like_MBTI_2, string like_MBTI_3, string like_MBTI_4)
    {
        this.user_id = user_id;
        this.name = name;
        this.man_age = man_age;
        this.man_age_min = man_age_min;
        this.man_age_max = man_age_max;
        this.man_sex = man_sex;
        this.location = location;
        this.monthlyrent_min = monthlyrent_min;
        this.monthlyrent_max = monthlyrent_max;
        this.roomsize_min = roomsize_min;
        this.roomsize_max = roomsize_max;
        this.sleep = sleep;
        this.smoke = smoke;
        this.drink = drink;
        this.tidy = tidy;
        this.rule = rule;
        this.sharing = sharing;
        this.like_sleep = like_sleep;
        this.like_smoke = like_smoke;
        this.like_drink = like_drink;
        this.like_tidy = like_tidy;
        this.like_rule = like_rule;
        this.like_sharing = like_sharing;
        this.MBTI_1 = MBTI_1;
        this.MBTI_2 = MBTI_2;
        this.MBTI_3 = MBTI_3;
        this.MBTI_4 = MBTI_4;
        this.like_MBTI_1 = like_MBTI_1;
        this.like_MBTI_2 = like_MBTI_2;
        this.like_MBTI_3 = like_MBTI_3;
        this.like_MBTI_4 = like_MBTI_4;

    }
}

public struct message
{
    public string s_id, s_name, r_id, phone, type;
    public message(string s_id, string s_name, string r_id, string phone, string type)
    {
        this.s_id = s_id;
        this.s_name = s_name;
        this.r_id = r_id;
        this.phone = phone;
        this.type = type;
    }
}


namespace oneTouch
{


    public partial class Client : Form
    {
        //선택 인덱스
        int selectedIndex;
        string find_id;
        //로그인한 유저의 정보
        public string user_id;
        string name, phone, man_age, man_age_min, man_age_max, man_sex, location, monthlyrent_min, monthlyrent_max, roomsize_min, roomsize_max, sleep, smoke, drink, tidy, rule, sharing, like_sleep, like_smoke, like_drink, like_tidy, like_rule, like_sharing, MBTI_1, MBTI_2, MBTI_3, MBTI_4, like_MBTI_1, like_MBTI_2, like_MBTI_3, like_MBTI_4;

        private void 연락처전송ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s_id = user_id, s_name = name, r_id = find_id, s_phone = phone, type = selectedIndex.ToString();
            string sql = "insert into messages values (" + s_id + ",'" + s_name + "'," + r_id + ",'" + phone + "'," + type + ");";

            conn1.Open();
            
            OleDbCommand cmd = new OleDbCommand(sql, conn1);
            OleDbDataReader read = cmd.ExecuteReader();

            read.Close();
            conn1.Close();

            MessageBox.Show("전송완료");
        }

        //내가 원하는 룸메 아이디, 정보 리스트
        List<string> roomateId = new List<string>();

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn1.Close();
        }

        List<user> roomate = new List<user>();
        //나를 원하는 룸메 아이디, 정보 리스트
        List<string> roomateId2 = new List<string>();
        List<user> roomate2 = new List<user>();
        //서로 원하는 룸메 아이디, 정보 리스트
        List<string> roomateId3 = new List<string>();
        List<user> roomate3 = new List<user>();
        // 메세지 큐
        List<message> messagebox = new List<message>();

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        OleDbConnection conn1;
        public int signal=0;

        public void ReplaceInfo()
        {
            //연결
            string sql1 = "Provider=tbprov.Tbprov.6;User ID=HR;Password=tibero;   Data Source=tibero;Persist Security Info=True";
            conn1 = new OleDbConnection(sql1);
            conn1.Open();
            //set 로그인 유저의 info 변수들.
            string sql;
            sql = "select name, phone, man_age, man_age_min, man_age_max, man_sex, location, monthlyrent_min, monthlyrent_max, roomsize_min, roomsize_max, ul.sleep, ul.smoke, ul.drink, ul.tidy, ul.rule, ul.sharing, ull.sleep, ull.smoke, ull.drink, ull.tidy, ull.rule, ull.sharing, uc.MBTI_1, uc.MBTI_2, uc.MBTI_3, uc.MBTI_4, ulc.MBTI_1, ulc.MBTI_2, ulc.MBTI_3, ulc.MBTI_4 from users u, life ul, like_life ull, character uc, like_character ulc where user_id = " + user_id + " and u.life_id = ul.id and u.like_life_id = ull.id and u.character_id = uc.id and u.like_character_id = ulc.id;";

            OleDbCommand cmd1 = new OleDbCommand(sql, conn1);
            OleDbDataReader read = cmd1.ExecuteReader();

            while (read.Read())
            {
                name = read.GetValue(0).ToString();
                phone = read.GetValue(1).ToString();
                man_age = read.GetValue(2).ToString();
                man_age_min = read.GetValue(3).ToString();
                man_age_max = read.GetValue(4).ToString();
                man_sex = read.GetValue(5).ToString();
                location = read.GetValue(6).ToString();
                monthlyrent_min = read.GetValue(7).ToString();
                monthlyrent_max = read.GetValue(8).ToString();
                roomsize_min = read.GetValue(9).ToString();
                roomsize_max = read.GetValue(10).ToString();
                sleep = read.GetValue(11).ToString();
                smoke = read.GetValue(12).ToString();
                drink = read.GetValue(13).ToString();
                tidy = read.GetValue(14).ToString();
                rule = read.GetValue(15).ToString();
                sharing = read.GetValue(16).ToString();
                like_sleep = read.GetValue(17).ToString();
                like_smoke = read.GetValue(18).ToString();
                like_drink = read.GetValue(19).ToString();
                like_tidy = read.GetValue(20).ToString();
                like_rule = read.GetValue(21).ToString();
                like_sharing = read.GetValue(22).ToString();
                MBTI_1 = read.GetValue(23).ToString();
                MBTI_2 = read.GetValue(24).ToString();
                MBTI_3 = read.GetValue(25).ToString();
                MBTI_4 = read.GetValue(26).ToString();
                like_MBTI_1 = read.GetValue(27).ToString();
                like_MBTI_2 = read.GetValue(28).ToString();
                like_MBTI_3 = read.GetValue(29).ToString();
                like_MBTI_4 = read.GetValue(30).ToString();
            }

            read.Close();
            conn1.Close();
        }

        public string GetLocation(int num)
        {
            switch(num)
            {
                case 0:
                    return "경기도";
                case 1:
                    return "충청남도";
                case 2:
                    return "충청북도";
                case 3:
                    return "경상남도";
                case 4:
                    return "경상북도";
                case 5:
                    return "전라남도";
                case 6:
                    return "전라북도";
                case 7:
                    return "강원도";
                case 8:
                    return "제주도";
                default:
                    return "알수 없음";
            }
        }
        public string GetCharacter(int a, int b, int c, int d)
        {
            string result = "";
            switch (a)
            {
                case 0:
                    result += "E";
                    break;
                case 1:
                    result += "I";
                    break;
            }
            switch (b)
            {
                case 0:
                    result += "S";
                    break;
                case 1:
                    result += "N";
                    break;
            }
            switch (c)
            {
                case 0:
                    result += "T";
                    break;
                case 1:
                    result += "F";
                    break;
            }
            switch (d)
            {
                case 0:
                    result += "J";
                    break;
                case 1:
                    result += "P";
                    break;
            }
            return result;
        }

        public string GetSleep(int num)
        {
            switch (num)
            {
                case 0:
                    return "아침형";
                case 1:
                    return "새벽형";
                case 2:
                    return "밤낮이 뒤바뀜";
                default:
                    return "알수 없음";
            }
        }

        public string GetSmoke(int num)
        {
            switch (num)
            {
                case 0:
                    return "흡연자";
                case 1:
                    return "비흡연자";
                default:
                    return "알수 없음";
            }
        }

        public string GetDrink(int num)
        {
            switch (num)
            {
                case 0:
                    return "안 마신다";
                case 1:
                    return "가끔 마신다";
                case 2:
                    return "자주 마신다";
                default:
                    return "알수 없음";
            }
        }

        public string GetTidy(int num)
        {
            switch (num)
            {
                case 0:
                    return "깔끔하다";
                case 1:
                    return "보통이다";
                case 2:
                    return "상관없다";
                default:
                    return "알수 없음";
            }
        }

        public string GetType(int num)
        {
            switch (num)
            {
                case 0:
                    return "나를 원하는 분";
                case 1:
                    return "내가 필요한 분";
                case 2:
                    return "서로 조건이 맞는 분";
                default:
                    return "알수 없음";
            }
        }

        public string GetRule(int num)
        {
            switch (num)
            {
                case 0:
                    return "규칙적";
                case 1:
                    return "다소 규칙적";
                case 2:
                    return "불규칙적";
                default:
                    return "알수 없음";
            }
        }

        public string GetSharing(int num)
        {
            switch (num)
            {
                case 0:
                    return "꺼려진다";
                case 1:
                    return "상관없다";
                default:
                    return "알수 없음";
            }
        }

        public string PassUserID
        {
            get { return this.user_id; }
            set { this.user_id = value; }
        }

        public Client()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.BeginUpdate();

            listView2.View = View.Details;
            listView2.BeginUpdate();

            listView1.Columns.Add("ID    ");
            listView1.Columns.Add("이름     ");
            listView1.Columns.Add("나이       ");

            listView2.Columns.Add("보낸 사람  ");
            listView2.Columns.Add("전화번호          ");
            listView2.Columns.Add("유형           ");

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            
            tabPage1.Text = @"룸메이트 찾기";
            tabPage2.Text = @"연락처 함";

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void set_id(string st)
        {
            user_id = st;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            want want1 = new want();
            want1.set_id(user_id);
            want1.set_info(name, man_age);
            conn1.Close();
            want1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReplaceInfo();
            selectedIndex = comboBox1.SelectedIndex;
            listView1.Items.Clear();

            switch (selectedIndex)
            {
                case 0:
                    {
                        //내가 원하는 룸메이트 추천
                        roomateId.Clear();
                        roomate.Clear();
                        conn1.Open();
                        string sql;

                        sql = "select user_id from users where man_age between " + man_age_min + " and "
                                + man_age_max + " AND man_sex=" + man_sex + " AND location=" + location
                                + " AND ((monthlyrent_min between " + monthlyrent_min + " and " + monthlyrent_max
                                + ") OR (monthlyrent_max between " + monthlyrent_min + " and " + monthlyrent_max
                                + ")) AND ((roomsize_min between " + roomsize_min + " and " + roomsize_max
                                + ") OR (roomsize_max between " + roomsize_min + " and " + roomsize_max
                                + ")) AND life_id in (select id from life where sleep = (case when " + like_sleep
                                + " = 3 then sleep else " + like_sleep + " end) and smoke = (case when " + like_smoke
                                + " = 2 then smoke else " + like_smoke + " end) and drink = (case when " + like_drink
                                + " = 3 then drink else " + like_drink + " end) and tidy = (case when " + like_tidy
                                + " = 3 then tidy else " + like_tidy + " end) and rule = (case when " + like_rule
                                + " = 3 then rule else " + like_rule + " end) and sharing = (case when " + like_sharing
                                + " = 2 then sharing else " + like_sharing + " end)) AND character_id in (select id from character where MBTI_1 = (case when "
                                + like_MBTI_1 + " = 2 then MBTI_1 else " + like_MBTI_1 + " end) and MBTI_2 = (case when "
                                + like_MBTI_2 + " = 2 then MBTI_2 else " + like_MBTI_2 + " end) and MBTI_3 = (case when "
                                + like_MBTI_3 + " = 2 then MBTI_3 else " + like_MBTI_3 + " end) and MBTI_4 = (case when "
                                + like_MBTI_4 + " = 2 then MBTI_4 else " + like_MBTI_4 + " end));";

                        OleDbCommand cmd1 = new OleDbCommand(sql, conn1);
                        OleDbDataReader read = cmd1.ExecuteReader();

                        while (read.Read())
                        {
                            if(read.GetValue(0).ToString() != user_id)
                                roomateId.Add(read.GetValue(0).ToString());
                        }

                        for (int i = 0; i < roomateId.Count(); i++)
                        {
                            sql = "select user_id, name, man_age, man_age_min, man_age_max, man_sex, location, monthlyrent_min, monthlyrent_max, roomsize_min, roomsize_max, ul.sleep, ul.smoke, ul.drink, ul.tidy, ul.rule, ul.sharing, ull.sleep, ull.smoke, ull.drink, ull.tidy, ull.rule, ull.sharing, uc.MBTI_1, uc.MBTI_2, uc.MBTI_3, uc.MBTI_4, ulc.MBTI_1, ulc.MBTI_2, ulc.MBTI_3, ulc.MBTI_4 from users u, life ul, like_life ull, character uc, like_character ulc where user_id = " + roomateId[i] + " and u.life_id = ul.id and u.like_life_id = ull.id and u.character_id = uc.id and u.like_character_id = ulc.id;";
                            cmd1 = new OleDbCommand(sql, conn1);
                            read = cmd1.ExecuteReader();
                            while (read.Read())
                            {
                                user rm = new user(read.GetValue(0).ToString(), read.GetValue(1).ToString(), read.GetValue(2).ToString(), read.GetValue(3).ToString(), read.GetValue(4).ToString(), read.GetValue(5).ToString(), read.GetValue(6).ToString(), read.GetValue(7).ToString(), read.GetValue(8).ToString(), read.GetValue(9).ToString(), read.GetValue(10).ToString(), read.GetValue(11).ToString(), read.GetValue(12).ToString(), read.GetValue(13).ToString(), read.GetValue(14).ToString(), read.GetValue(15).ToString(), read.GetValue(16).ToString(), read.GetValue(17).ToString(), read.GetValue(18).ToString(), read.GetValue(19).ToString(), read.GetValue(20).ToString(), read.GetValue(21).ToString(), read.GetValue(22).ToString(), read.GetValue(23).ToString(), read.GetValue(24).ToString(), read.GetValue(25).ToString(), read.GetValue(26).ToString(), read.GetValue(27).ToString(), read.GetValue(28).ToString(), read.GetValue(29).ToString(), read.GetValue(30).ToString());
                                roomate.Add(rm);
                            }
                        }
                        read.Close();
                        conn1.Close();

                        for (int i = 0; i < roomateId.Count(); i++)
                        {
                            ListViewItem item1 = new ListViewItem(roomateId[i].ToString());
                            item1.SubItems.Add(roomate[i].name.ToString());
                            item1.SubItems.Add(roomate[i].man_age.ToString());
                            listView1.Items.AddRange(new ListViewItem[] { item1 });
                        }
                        break;
                    }
                case 1:
                    {
                        //나를 원하는 룸메이트 추천
                        // 구조체 생성
                        roomateId2.Clear();
                        roomate2.Clear();
                        conn1.Open();
                        string sql;


                        sql = "select user_id from users where man_age_min <= "
                          + man_age + " and man_age_max >= " + man_age + " AND man_sex= " + man_sex +
                          " AND location = " + location + " AND ((monthlyrent_min between " + monthlyrent_min +
                          " and " + monthlyrent_max + ") OR (monthlyrent_max between " + monthlyrent_min +
                          " and " + monthlyrent_max + ")) AND ((roomsize_min between " + roomsize_min +
                          " and " + roomsize_max + " ) OR (roomsize_max between " + roomsize_min +
                          " and " + roomsize_max + ")) AND like_life_id in (select id from like_life where (case when sleep = 3 then " +
                          sleep + " else sleep end) = " + sleep + " and (case when smoke = 2 then " + smoke + " else smoke end) = " +
                          smoke + " and(case when drink = 3 then " + drink + " else drink end) = " + drink +
                          " and (case when tidy = 3 then " + tidy + " else tidy end) =" +
                          tidy + " and (case when rule = 3 then " + rule + " else rule end) = " + rule +
                          " and (case when sharing = 2 then " + sharing + "  else sharing end) = " +
                          sharing + ") AND like_character_id in (select id from like_character where(case when MBTI_1 = 2 then " +
                        MBTI_1 + " else MBTI_1 end) = " + MBTI_1 + " and (case when MBTI_2 = 2 then " + MBTI_2 +
                           "  else MBTI_2 end) = " + MBTI_2 + " and (case when MBTI_3 = 2 then " + MBTI_3 +
                           " else MBTI_3 end) = " + MBTI_3 + " and (case when MBTI_4 = 2 then " + MBTI_4 +
                           " else MBTI_4 end) = " + MBTI_4 + ");";

                        OleDbCommand cmd1 = new OleDbCommand(sql, conn1);
                        OleDbDataReader read = cmd1.ExecuteReader();

                        while (read.Read())
                        {
                            if (read.GetValue(0).ToString() != user_id)
                                roomateId2.Add(read.GetValue(0).ToString());
                        }

                        for (int i = 0; i < roomateId2.Count(); i++)
                        {
                            sql = "select user_id, name, man_age, man_age_min, man_age_max, man_sex, location, monthlyrent_min, monthlyrent_max, roomsize_min, roomsize_max, ul.sleep, ul.smoke, ul.drink, ul.tidy, ul.rule, ul.sharing, ull.sleep, ull.smoke, ull.drink, ull.tidy, ull.rule, ull.sharing, uc.MBTI_1, uc.MBTI_2, uc.MBTI_3, uc.MBTI_4, ulc.MBTI_1, ulc.MBTI_2, ulc.MBTI_3, ulc.MBTI_4 from users u, life ul, like_life ull, character uc, like_character ulc where user_id = " + roomateId2[i] + " and u.life_id = ul.id and u.like_life_id = ull.id and u.character_id = uc.id and u.like_character_id = ulc.id;";
                            cmd1 = new OleDbCommand(sql, conn1);
                            read = cmd1.ExecuteReader();
                            while (read.Read())
                            {
                                user rm = new user(read.GetValue(0).ToString(), read.GetValue(1).ToString(), read.GetValue(2).ToString(), read.GetValue(3).ToString(), read.GetValue(4).ToString(), read.GetValue(5).ToString(), read.GetValue(6).ToString(), read.GetValue(7).ToString(), read.GetValue(8).ToString(), read.GetValue(9).ToString(), read.GetValue(10).ToString(), read.GetValue(11).ToString(), read.GetValue(12).ToString(), read.GetValue(13).ToString(), read.GetValue(14).ToString(), read.GetValue(15).ToString(), read.GetValue(16).ToString(), read.GetValue(17).ToString(), read.GetValue(18).ToString(), read.GetValue(19).ToString(), read.GetValue(20).ToString(), read.GetValue(21).ToString(), read.GetValue(22).ToString(), read.GetValue(23).ToString(), read.GetValue(24).ToString(), read.GetValue(25).ToString(), read.GetValue(26).ToString(), read.GetValue(27).ToString(), read.GetValue(28).ToString(), read.GetValue(29).ToString(), read.GetValue(30).ToString());
                                roomate2.Add(rm);
                            }
                        }

                        read.Close();
                        conn1.Close();

                        for (int i = 0; i < roomateId2.Count(); i++)
                        {
                            ListViewItem item1 = new ListViewItem(roomateId2[i].ToString());
                            item1.SubItems.Add(roomate2[i].name.ToString());
                            item1.SubItems.Add(roomate2[i].man_age.ToString());
                            listView1.Items.AddRange(new ListViewItem[] { item1 });
                        }
                        break;
                    }
                case 2:
                    {
                        //서로 원하는 룸메이트 추천
                        //쿼리문
                        //일단 내가 원하는 룸메이트 추천
                        roomateId.Clear();
                        roomate.Clear();
                        roomateId2.Clear();
                        roomate2.Clear();
                        roomateId3.Clear();
                        roomate3.Clear();
                        conn1.Open();
                        string sql;

                        sql = "select user_id from users where man_age between " + man_age_min + " and "
                                + man_age_max + " AND man_sex=" + man_sex + " AND location=" + location
                                + " AND ((monthlyrent_min between " + monthlyrent_min + " and " + monthlyrent_max
                                + ") OR (monthlyrent_max between " + monthlyrent_min + " and " + monthlyrent_max
                                + ")) AND ((roomsize_min between " + roomsize_min + " and " + roomsize_max
                                + ") OR (roomsize_max between " + roomsize_min + " and " + roomsize_max
                                + ")) AND life_id in (select id from life where sleep = (case when " + like_sleep
                                + " = 3 then sleep else " + like_sleep + " end) and smoke = (case when " + like_smoke
                                + " = 2 then smoke else " + like_smoke + " end) and drink = (case when " + like_drink
                                + " = 3 then drink else " + like_drink + " end) and tidy = (case when " + like_tidy
                                + " = 3 then tidy else " + like_tidy + " end) and rule = (case when " + like_rule
                                + " = 3 then rule else " + like_rule + " end) and sharing = (case when " + like_sharing
                                + " = 2 then sharing else " + like_sharing + " end)) AND character_id in (select id from character where MBTI_1 = (case when "
                                + like_MBTI_1 + " = 2 then MBTI_1 else " + like_MBTI_1 + " end) and MBTI_2 = (case when "
                                + like_MBTI_2 + " = 2 then MBTI_2 else " + like_MBTI_2 + " end) and MBTI_3 = (case when "
                                + like_MBTI_3 + " = 2 then MBTI_3 else " + like_MBTI_3 + " end) and MBTI_4 = (case when "
                                + like_MBTI_4 + " = 2 then MBTI_4 else " + like_MBTI_4 + " end));";

                        OleDbCommand cmd1 = new OleDbCommand(sql, conn1);
                        OleDbDataReader read = cmd1.ExecuteReader();

                        while (read.Read())
                        {
                            roomateId.Add(read.GetValue(0).ToString());
                        }

                        read.Close();
                        conn1.Close();

                        //일단 나를 원하는 룸메이트 추천
                        // 구조체 생성
                        roomateId2.Clear();
                        roomate2.Clear();
                        conn1.Open();

                        sql = "select user_id from users where man_age_min <= "
                          + man_age + " and man_age_max >= " + man_age + " AND man_sex= " + man_sex +
                          " AND location = " + location + " AND ((monthlyrent_min between " + monthlyrent_min +
                          " and " + monthlyrent_max + ") OR (monthlyrent_max between " + monthlyrent_min +
                          " and " + monthlyrent_max + ")) AND ((roomsize_min between " + roomsize_min +
                          " and " + roomsize_max + " ) OR (roomsize_max between " + roomsize_min +
                          " and " + roomsize_max + ")) AND like_life_id in (select id from like_life where (case when sleep = 3 then " +
                          sleep + " else sleep end) = " + sleep + " and (case when smoke = 2 then " + smoke + " else smoke end) = " +
                          smoke + " and(case when drink = 3 then " + drink + " else drink end) = " + drink +
                          " and (case when tidy = 3 then " + tidy + " else tidy end) =" +
                          tidy + " and (case when rule = 3 then " + rule + " else rule end) = " + rule +
                          " and (case when sharing = 2 then " + sharing + "  else sharing end) = " +
                          sharing + ") AND like_character_id in (select id from like_character where(case when MBTI_1 = 2 then " +
                        MBTI_1 + " else MBTI_1 end) = " + MBTI_1 + " and (case when MBTI_2 = 2 then " + MBTI_2 +
      "  else MBTI_2 end) = " + MBTI_2 + " and (case when MBTI_3 = 2 then " + MBTI_3 +
      " else MBTI_3 end) = " + MBTI_3 + " and (case when MBTI_4 = 2 then " + MBTI_4 +
      " else MBTI_4 end) = " + MBTI_4 + ");";

                        cmd1 = new OleDbCommand(sql, conn1);
                        read = cmd1.ExecuteReader();

                        while (read.Read())
                        {
                            roomateId2.Add(read.GetValue(0).ToString());
                        }

                        //교집합해서 서로 원하는 룸메 아이디 찾기
                        for (int i = 0; i < roomateId.Count(); i++)
                        {
                            for (int j = 0; j < roomateId2.Count(); j++)
                            {
                                if (roomateId[i] == roomateId2[j])
                                {
                                    if (roomateId[i] != user_id)
                                        roomateId3.Add(roomateId[i]);
                                }
                            }
                        }

                        for (int i = 0; i < roomateId3.Count(); i++)
                        {
                            sql = "select user_id, name, man_age, man_age_min, man_age_max, man_sex, location, monthlyrent_min, monthlyrent_max, roomsize_min, roomsize_max, ul.sleep, ul.smoke, ul.drink, ul.tidy, ul.rule, ul.sharing, ull.sleep, ull.smoke, ull.drink, ull.tidy, ull.rule, ull.sharing, uc.MBTI_1, uc.MBTI_2, uc.MBTI_3, uc.MBTI_4, ulc.MBTI_1, ulc.MBTI_2, ulc.MBTI_3, ulc.MBTI_4 from users u, life ul, like_life ull, character uc, like_character ulc where user_id = " + roomateId3[i] + " and u.life_id = ul.id and u.like_life_id = ull.id and u.character_id = uc.id and u.like_character_id = ulc.id;";
                            cmd1 = new OleDbCommand(sql, conn1);
                            read = cmd1.ExecuteReader();
                            while (read.Read())
                            {
                                if (read.GetValue(0).ToString() != user_id)
                                {
                                    user rm = new user(read.GetValue(0).ToString(), read.GetValue(1).ToString(), read.GetValue(2).ToString(), read.GetValue(3).ToString(), read.GetValue(4).ToString(), read.GetValue(5).ToString(), read.GetValue(6).ToString(), read.GetValue(7).ToString(), read.GetValue(8).ToString(), read.GetValue(9).ToString(), read.GetValue(10).ToString(), read.GetValue(11).ToString(), read.GetValue(12).ToString(), read.GetValue(13).ToString(), read.GetValue(14).ToString(), read.GetValue(15).ToString(), read.GetValue(16).ToString(), read.GetValue(17).ToString(), read.GetValue(18).ToString(), read.GetValue(19).ToString(), read.GetValue(20).ToString(), read.GetValue(21).ToString(), read.GetValue(22).ToString(), read.GetValue(23).ToString(), read.GetValue(24).ToString(), read.GetValue(25).ToString(), read.GetValue(26).ToString(), read.GetValue(27).ToString(), read.GetValue(28).ToString(), read.GetValue(29).ToString(), read.GetValue(30).ToString());
                                    roomate3.Add(rm);
                                }
                            }
                        }
                        read.Close();
                        conn1.Close();

                        for (int i = 0; i < roomateId3.Count(); i++)
                        {
                            ListViewItem item1 = new ListViewItem(roomateId3[i].ToString());
                            item1.SubItems.Add(roomate3[i].name.ToString());
                            item1.SubItems.Add(roomate3[i].man_age.ToString());
                            listView1.Items.AddRange(new ListViewItem[] { item1 });
                        }
                        break;
                    }
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
            ReplaceInfo();
           
            conn1.Open();
        
            string msg_sql="select * from messages where r_id = " + user_id + ";";
            OleDbCommand cmd2 = new OleDbCommand(msg_sql, conn1);
            OleDbDataReader read2 = cmd2.ExecuteReader();

            while (read2.Read())
            {
                message msg = new message(read2.GetValue(0).ToString(), read2.GetValue(1).ToString(), read2.GetValue(2).ToString(), read2.GetValue(3).ToString(), read2.GetValue(4).ToString());
                messagebox.Add(msg);
            }
            for (int i = 0; i < messagebox.Count(); i++)
            {
                string phone_num = "";
                phone_num = messagebox[i].phone.ToString().Substring(0, 3) + "-" + messagebox[i].phone.ToString().Substring(3, 4) + "-" + messagebox[i].phone.ToString().Substring(7);
                ListViewItem item1 = new ListViewItem(messagebox[i].s_name.ToString());
                item1.SubItems.Add(phone_num);
                item1.SubItems.Add(GetType(Convert.ToInt32(messagebox[i].type.ToString())));
                listView2.Items.AddRange(new ListViewItem[] { item1 });
            }

            read2.Close();
            conn1.Close();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                    find_id = listView1.GetItemAt(e.X, e.Y).Text;
                }
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
       

        private void 상세보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch(selectedIndex)
            {
                case 0:
                    for (int i = 0; i < roomateId.Count(); i++)
                    {
                        if (roomateId[i].ToString() == find_id)
                        {
                            MessageBox.Show("\t이름 : " + roomate[i].name + "\n\t나이 : " + roomate[i].man_age + "\n\t지역 : " + GetLocation(Convert.ToInt32(roomate[i].location)) + "\n\t희망 월세 지출 : " + roomate[i].monthlyrent_min + " ~ " + roomate[i].monthlyrent_max + " 만원        \n\t성격 유형 : " + GetCharacter(Convert.ToInt32(roomate[i].MBTI_1), Convert.ToInt32(roomate[i].MBTI_2), Convert.ToInt32(roomate[i].MBTI_3), Convert.ToInt32(roomate[i].MBTI_4)) + "\n\t수면 시간 : " + GetSleep(Convert.ToInt32(roomate[i].sleep)) + "\n\t흡연 여부 : " + GetSmoke(Convert.ToInt32(roomate[i].smoke)) + "\n\t음주 여부 : " + GetDrink(Convert.ToInt32(roomate[i].drink)) + "\n\t청결도 : " + GetTidy(Convert.ToInt32(roomate[i].tidy)) + "\n\t규칙도 : " + GetRule(Convert.ToInt32(roomate[i].rule)) + "\n\t물품공유도 : " + GetSharing(Convert.ToInt32(roomate[i].sharing)));
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < roomateId2.Count(); i++)
                    {
                        if (roomateId2[i].ToString() == find_id)
                        {
                            MessageBox.Show("\t이름 : " + roomate2[i].name + "\n\t나이 : " + roomate2[i].man_age + "\n\t지역 : " + GetLocation(Convert.ToInt32(roomate2[i].location)) + "\n\t희망 월세 지출 : " + roomate2[i].monthlyrent_min + " ~ " + roomate2[i].monthlyrent_max + " 만원        \n\t성격 유형 : " + GetCharacter(Convert.ToInt32(roomate2[i].MBTI_1), Convert.ToInt32(roomate2[i].MBTI_2), Convert.ToInt32(roomate2[i].MBTI_3), Convert.ToInt32(roomate2[i].MBTI_4)) + "\n\t수면 시간 : " + GetSleep(Convert.ToInt32(roomate2[i].sleep)) + "\n\t흡연 여부 : " + GetSmoke(Convert.ToInt32(roomate2[i].smoke)) + "\n\t음주 여부 : " + GetDrink(Convert.ToInt32(roomate2[i].drink)) + "\n\t청결도 : " + GetTidy(Convert.ToInt32(roomate2[i].tidy)) + "\n\t규칙도 : " + GetRule(Convert.ToInt32(roomate2[i].rule)) + "\n\t물품공유도 : " + GetSharing(Convert.ToInt32(roomate2[i].sharing)));
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < roomateId3.Count(); i++)
                    {
                        if (roomateId3[i].ToString() == find_id)
                        {
                            MessageBox.Show("\t이름 : " + roomate3[i].name + "\n\t나이 : " + roomate3[i].man_age + "\n\t지역 : " + GetLocation(Convert.ToInt32(roomate3[i].location)) + "\n\t희망 월세 지출 : " + roomate3[i].monthlyrent_min + " ~ " + roomate3[i].monthlyrent_max + " 만원       \n\t성격 유형 : " + GetCharacter(Convert.ToInt32(roomate3[i].MBTI_1), Convert.ToInt32(roomate3[i].MBTI_2), Convert.ToInt32(roomate3[i].MBTI_3), Convert.ToInt32(roomate3[i].MBTI_4)) + "\n\t수면 시간 : " + GetSleep(Convert.ToInt32(roomate3[i].sleep)) + "\n\t흡연 여부 : " + GetSmoke(Convert.ToInt32(roomate3[i].smoke)) + "\n\t음주 여부 : " + GetDrink(Convert.ToInt32(roomate3[i].drink)) + "\n\t청결도 : " + GetTidy(Convert.ToInt32(roomate3[i].tidy)) + "\n\t규칙도 : " + GetRule(Convert.ToInt32(roomate3[i].rule)) + "\n\t물품공유도 : " + GetSharing(Convert.ToInt32(roomate3[i].sharing)));
                        }
                    }
                    break;
            }
        }
    }
}