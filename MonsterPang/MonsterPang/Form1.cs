using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterPang
{
    public partial class MonsterPang : Form
    {
        private Bitmap hpBitmap = Properties.Resources.hp;
        private Bitmap st1Bitmap = Properties.Resources.stone1;
        private Bitmap st2Bitmap = Properties.Resources.stone2;
        private Bitmap st3Bitmap = Properties.Resources.stone3;
        private Bitmap st4Bitmap = Properties.Resources.stone4;
        private Bitmap st5Bitmap = Properties.Resources.stone5;
        private Bitmap st6Bitmap = Properties.Resources.stone6;
        private Stone[,] boardGUI = new Stone[Board.boardSize,Board.boardSize];
        private Stage stage;

        public MonsterPang()
        {
            InitializeComponent();
            int level = 1;
            while (level < 6)
            {
                stage = new Stage(level);
                //stage.Play();

                level++;
                switch(level)
                {
                    case 2: monster.Image = Properties.Resources.monster2;
                        break;
                    case 3: monster.Image = Properties.Resources.monster3;
                        break;
                    case 4: monster.Image = Properties.Resources.monster4;
                        break;
                    case 5: monster.Image = Properties.Resources.monster5;
                        break;
                    default:
                        break;
                }
            }
        }

        private void MonsterPang_Paint(object sender, PaintEventArgs e)
        {
            int x = 8;
            int y = 4;
            for(int row = 0; row < boardGUI.GetLength(0); row++)
            {
                x = 8;
                for(int col = 0; col < boardGUI.GetLength(1); col++)
                {
                    boardGUI[row, col] = stage.board.stones[row,col];
                    switch(boardGUI[row, col].type)
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

        private void MonsterPang_Paint2(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(hpBitmap, 10, 134, hpBitmap.Width, hpBitmap.Height); 
        }

        private void MonsterPang_Load(object sender, EventArgs e)
        {

        }

        private void stones_Click(object sender, EventArgs e)
        {

        }
    }
}
