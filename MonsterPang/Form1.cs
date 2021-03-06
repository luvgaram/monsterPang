﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace MonsterPang
{
    public partial class MonsterPang : Form
    {
        private Bitmap hpBitmap = Properties.Resources.hp;
        private Bitmap hpBarBitmap = Properties.Resources.hpBar;
        private Bitmap lvupBitmap = Properties.Resources.lvup;
        private Bitmap stBitmap;
        private Stone[,] boardGUI = new Stone[Board.boardSize,Board.boardSize];
        private Stage stage;
        private int level = 1;
        public Point first;
        public Point second;
        public int pointNum = 0;
        int row1 =-1;
        int col1 =-1;
        int row2 =-1;
        int col2 = -1;

        public MonsterPang()
        {
            InitializeComponent();
            stage = new Stage(level);
            ConvertMosterImage(level);
            StrtTimer();
        }

        public void ConvertMosterImage(int level)
        {
            switch (level)
            {
                case 1: monsterGUI.Image = Properties.Resources.monster1;
                    break;
                case 2: monsterGUI.Image = Properties.Resources.monster2;
                    break;
                case 3: monsterGUI.Image = Properties.Resources.monster3;
                    break;
                case 4: monsterGUI.Image = Properties.Resources.monster4;
                    break;
                case 5: monsterGUI.Image = Properties.Resources.monster5;
                    break;
                default:
                    break;
            }
        }

        private void MonsterPang_Paint(object sender, PaintEventArgs e)
        {

                int x = 8;
                int y = 2;

                for (int row = 0; row < boardGUI.GetLength(0); row++)
                {
                    x = 8;
                    for (int col = 0; col < boardGUI.GetLength(1); col++)
                    {
                        boardGUI[row, col] = stage.board.stones[row, col];
                        switch (boardGUI[row, col].type)
                        {
                            case 1:
                                stBitmap = Properties.Resources.stone1;
                                e.Graphics.DrawImage(stBitmap, x, y, stBitmap.Width, stBitmap.Height);
                                break;
                            case 2:
                                stBitmap = Properties.Resources.stone2;
                                e.Graphics.DrawImage(stBitmap, x, y, stBitmap.Width, stBitmap.Height);
                                break;
                            case 3:
                                stBitmap = Properties.Resources.stone3;
                                e.Graphics.DrawImage(stBitmap, x, y, stBitmap.Width, stBitmap.Height);
                                break;
                            case 4:
                                stBitmap = Properties.Resources.stone4;
                                e.Graphics.DrawImage(stBitmap, x, y, stBitmap.Width, stBitmap.Height);
                                break;
                            case 5:
                                stBitmap = Properties.Resources.stone5;
                                e.Graphics.DrawImage(stBitmap, x, y, stBitmap.Width, stBitmap.Height);
                                break;
                            case 6:
                                stBitmap = Properties.Resources.stone6;
                                e.Graphics.DrawImage(stBitmap, x, y, stBitmap.Width, stBitmap.Height);
                                break;
                            default:
                                break;
                        }
                        x = x + 50;
                    }
                    y = y + 52;
                }
        }

        private void MonsterPang_Paint2(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(hpBitmap, 10, 134, hpBitmap.Width, hpBitmap.Height);
            e.Graphics.DrawImage(hpBarBitmap, 32, 138, (stage.monster.hpPercent) * 5, 20);
            
        }

        private void MonsterPang_Load(object sender, EventArgs e)
        {

        }

 

        private void timer1_Tick(object sender, EventArgs e) //edit
        {
            if(stage.monster.hp > 3)
            {
                DisableForm();
                stage.DeleteContinuously();
                SoundPlayer sndplayr = new SoundPlayer(Properties.Resources.stoneSound);
                sndplayr.Play();
                Invalidate();

                if (stage.IsMovalble())
                {
                    StopTimer();
                    EnableForm();
                    return;
                }
                else
                {
                    stage.board.Refresh();
                    Invalidate();
                    return;

                }
            }
            else{
                if (level == 5)
                {
                    StopTimer();
                    ending endDiag = new ending();

                    if (endDiag.ShowDialog() == DialogResult.OK)
                    {
                        this.Close();
                    }
                    else
                    {
                        level = 1;
                        stage = new Stage(level);
                        ConvertMosterImage(level);
                        Invalidate();
                        StrtTimer();
                    }
                }
                else
                {
                    level++;
                    StopTimer();
                    LvUpDiag dialog = new LvUpDiag();

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        stage = new Stage(level);
                        ConvertMosterImage(level);
                        Invalidate();
                        StrtTimer();
                    }
                    return;
                }
            }
        }

        private void StrtTimer()
        {
            timer.Start();
        }

        private void StopTimer()
        {
            timer.Stop();
        }

        private void EnableForm()
        {
            this.Enabled = true;
        }

        private void DisableForm()
        {
            this.Enabled = false;
        }



        private void stones_MouseDown(object sender, MouseEventArgs e)
        {
            first.X = e.Location.X;
            first.Y = e.Location.Y;

            for (int i = 0; i < boardGUI.GetLength(0); i++)
            {
                if (((8 + (50 * i)) <= first.X) && (first.X < (8 + (50 * (i + 1)))))
                {
                    col1 = i;
                }

                if (((2 + (52 * i)) <= first.Y) && (first.Y < (2 + (52 * (i + 1)))))
                {
                    row1 = i;
                }
            }           
        }

        private void stones_MouseUp(object sender, MouseEventArgs e)
        {
            second.X = e.Location.X;
            second.Y = e.Location.Y;

            for (int i = 0; i < boardGUI.GetLength(0); i++)
            {
                if (((8 + (50 * i)) <= second.X) && (second.X < (8 + (50 * (i + 1)))))
                {
                    col2 = i;
                }

                if (((2 + (52 * i)) <= second.Y) && (second.Y < (2 + (52 * (i + 1)))))
                {
                    row2 = i;
                }
            }

            if (row2 != -1 && col2 != -1)
            {
                if (stage.IsSwitchable(row1, col1, row2, col2))
                {
                    stage.Swap(row1, col1, row2, col2);
                    row1 = -1;
                    col1 = -1;
                    row2 = -1;
                    col2 = -1;
                    StrtTimer();
                }
                else
                {
                    row1 = -1;
                    col1 = -1;
                    row2 = -1;
                    col2 = -1;
                    SoundPlayer error = new SoundPlayer(Properties.Resources.errorSound);
                    error.Play();
                    Invalidate();
                }
            }
        }

        private void MonsterPang_Click(object sender, EventArgs e)
        {

        }

        private void MonsterPang_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void MonsterPang_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void MonsterPang_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void stones_Click(object sender, EventArgs e)
        {

        }
    }
}
