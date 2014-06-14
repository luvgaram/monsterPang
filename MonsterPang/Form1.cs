﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MonsterPang
{
    public partial class MonsterPang : Form
    {
        private Bitmap hpBitmap = Properties.Resources.hp;
        private Bitmap hpBarBitmap = Properties.Resources.hpBar;
        private Bitmap lvupBitmap = Properties.Resources.lvup;
        private Bitmap st1Bitmap = Properties.Resources.stone1;
        private Bitmap st2Bitmap = Properties.Resources.stone2;
        private Bitmap st3Bitmap = Properties.Resources.stone3;
        private Bitmap st4Bitmap = Properties.Resources.stone4;
        private Bitmap st5Bitmap = Properties.Resources.stone5;
        private Bitmap st6Bitmap = Properties.Resources.stone6;
        private Stone[,] boardGUI = new Stone[Board.boardSize,Board.boardSize];
        private Stage stage;
        private int level = 1; //전역변수로 추가
        private int lvUpTime = 0;
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
            stage = new Stage(level); //보드 만들고, 몬스터 만들고!
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
            if (lvUpTime == 0)
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
                                e.Graphics.DrawImage(st1Bitmap, x, y, st1Bitmap.Width, st1Bitmap.Height);
                                break;
                            case 2:
                                e.Graphics.DrawImage(st2Bitmap, x, y, st2Bitmap.Width, st2Bitmap.Height);
                                break;
                            case 3:
                                e.Graphics.DrawImage(st3Bitmap, x, y, st3Bitmap.Width, st3Bitmap.Height);
                                break;
                            case 4:
                                e.Graphics.DrawImage(st4Bitmap, x, y, st4Bitmap.Width, st4Bitmap.Height);
                                break;
                            case 5:
                                e.Graphics.DrawImage(st5Bitmap, x, y, st5Bitmap.Width, st5Bitmap.Height);
                                break;
                            case 6:
                                e.Graphics.DrawImage(st6Bitmap, x, y, st6Bitmap.Width, st6Bitmap.Height);
                                break;
                            default:
                                break;
                        }
                        x = x + 50;
                    }
                    y = y + 52;
                }
            }
            else
            {
                e.Graphics.DrawImage(lvupBitmap, 0, 6, lvupBitmap.Width, lvupBitmap.Height);
                Pause();
                lvUpTime = 0;
                StrtTimer();
            }
        }

        private void MonsterPang_Paint2(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(hpBitmap, 10, 134, hpBitmap.Width, hpBitmap.Height);
            e.Graphics.DrawImage(hpBarBitmap, 32, 138, (stage.monster.hpPercent) * 25, 20);
            
        }

        private void MonsterPang_Load(object sender, EventArgs e)
        {

        }

 

        private void timer1_Tick(object sender, EventArgs e) //edit
        {
            if(stage.monster.hp>0)
            {
                DisableForm();
                stage.DeleteContinuously();
                Invalidate();
                StopTimer();
                EnableForm();
                return;
            }
            else{
                DisableForm();
                StopTimer();
                level++;
                stage = new Stage(level);
                ConvertMosterImage(level);
                lvUpTime = 1;
                Invalidate();
                EnableForm();
                return;
            }
        }

        /*
        private void PaintAll ()
        {
            MonsterPang_Paint(null, null);
            MonsterPang_Paint2(null, null);
        }*/

        public void Pause()
        {
            Thread.Sleep(2000);
        }

        private void StrtTimer()
        {
            timer.Start();
        }

        private void StopTimer() //edit
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

        private void MonsterPang_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void MonsterPang_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void stones_Click(object sender, EventArgs e)
        {
            
        }

        private void stones_MouseDown(object sender, MouseEventArgs e)
        {
                  
            if (pointNum == 0)
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
                }//first.X, first.Y 를 row1, col1으로 변환해 할당하기, 이렇게 할당했기 때문에 엄한 데 클릭하면 할당이 안될 수 있다. 
                if (row1 != -1 && col1 != -1) //할당 안되었을 때 대비하여!
                {
                    pointNum++;
                }

            }
            else if (pointNum == 1)
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
                    pointNum = 0;
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
                        stage.board.Refresh();
                        row1 = -1;
                        col1 = -1;
                        row2 = -1;
                        col2 = -1;
                        Invalidate();
                        StrtTimer();
                    }
                    

                }
            }
        }

        private void MonsterPang_Click(object sender, EventArgs e)
        {

        }

        private void MonsterPang_MouseDown(object sender, MouseEventArgs e)
        {
            
           
        }



    }
}
