namespace MonsterPang
{
    partial class MonsterPang
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonsterPang));
            this.stones = new System.Windows.Forms.PictureBox();
            this.monsterGUI = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.stones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterGUI)).BeginInit();
            this.SuspendLayout();
            // 
            // stones
            // 
            this.stones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stones.Image = global::MonsterPang.Properties.Resources.stones;
            this.stones.Location = new System.Drawing.Point(0, 164);
            this.stones.Name = "stones";
            this.stones.Size = new System.Drawing.Size(320, 316);
            this.stones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.stones.TabIndex = 0;
            this.stones.TabStop = false;
            this.stones.Click += new System.EventHandler(this.stones_Click);
            this.stones.Paint += new System.Windows.Forms.PaintEventHandler(this.MonsterPang_Paint);
            this.stones.MouseDown += new System.Windows.Forms.MouseEventHandler(this.stones_MouseDown);
            // 
            // monsterGUI
            // 
            this.monsterGUI.Image = global::MonsterPang.Properties.Resources.monster1;
            this.monsterGUI.Location = new System.Drawing.Point(0, 0);
            this.monsterGUI.Name = "monsterGUI";
            this.monsterGUI.Size = new System.Drawing.Size(320, 164);
            this.monsterGUI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.monsterGUI.TabIndex = 1;
            this.monsterGUI.TabStop = false;
            this.monsterGUI.Paint += new System.Windows.Forms.PaintEventHandler(this.MonsterPang_Paint2);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MonsterPang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 479);
            this.Controls.Add(this.stones);
            this.Controls.Add(this.monsterGUI);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MonsterPang";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MonsterPang_Load);
            this.Click += new System.EventHandler(this.MonsterPang_Click);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MonsterPang_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MonsterPang_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MonsterPang_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.stones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterGUI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox stones;
        private System.Windows.Forms.PictureBox monsterGUI;
        private System.Windows.Forms.Timer timer;
    }
}

