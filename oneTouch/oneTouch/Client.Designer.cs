namespace oneTouch
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.메세지보내기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.상세보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tapcot = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.연락처전송ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.tapcot.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "정보 업데이트";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "내가 원하는 룸메이트",
            "나를 원하는 룸메이트",
            "서로 원하는 룸메이트"});
            this.comboBox1.Location = new System.Drawing.Point(156, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(158, 23);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(324, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "검색";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(13, 66);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(377, 141);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메세지보내기ToolStripMenuItem,
            this.상세보기ToolStripMenuItem,
            this.연락처전송ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 76);
            // 
            // 메세지보내기ToolStripMenuItem
            // 
            this.메세지보내기ToolStripMenuItem.Name = "메세지보내기ToolStripMenuItem";
            this.메세지보내기ToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.메세지보내기ToolStripMenuItem.Text = "메세지 보내기";
            this.메세지보내기ToolStripMenuItem.Click += new System.EventHandler(this.메세지보내기ToolStripMenuItem_Click);
            // 
            // 상세보기ToolStripMenuItem
            // 
            this.상세보기ToolStripMenuItem.Name = "상세보기ToolStripMenuItem";
            this.상세보기ToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.상세보기ToolStripMenuItem.Text = "상세보기";
            this.상세보기ToolStripMenuItem.Click += new System.EventHandler(this.상세보기ToolStripMenuItem_Click);
            // 
            // tapcot
            // 
            this.tapcot.Controls.Add(this.tabPage1);
            this.tapcot.Controls.Add(this.tabPage2);
            this.tapcot.Location = new System.Drawing.Point(19, 7);
            this.tapcot.Name = "tapcot";
            this.tapcot.SelectedIndex = 0;
            this.tapcot.Size = new System.Drawing.Size(419, 254);
            this.tapcot.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(411, 225);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(411, 225);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(26, 74);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(358, 123);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // 연락처전송ToolStripMenuItem
            // 
            this.연락처전송ToolStripMenuItem.Name = "연락처전송ToolStripMenuItem";
            this.연락처전송ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.연락처전송ToolStripMenuItem.Text = "연락처 전송";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "내게 오는 사람들을 진정으로 대하라. 돈은 덤으로 온다.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "-진정 스님";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 274);
            this.Controls.Add(this.tapcot);
            this.Name = "Client";
            this.Text = "One Touch";
            this.Load += new System.EventHandler(this.Client_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tapcot.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메세지보내기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 상세보기ToolStripMenuItem;
        private System.Windows.Forms.TabControl tapcot;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ToolStripMenuItem 연락처전송ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}