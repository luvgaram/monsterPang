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

        public MonsterPang()
        {
            InitializeComponent();
        }

        private void MonsterPang_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(st1Bitmap, 12, 6, st1Bitmap.Width, st1Bitmap.Height);
            e.Graphics.DrawImage(st2Bitmap, 115, 6, st2Bitmap.Width, st2Bitmap.Height);
            e.Graphics.DrawImage(st3Bitmap, 218, 6, st3Bitmap.Width, st3Bitmap.Height);
            e.Graphics.DrawImage(st4Bitmap, 321, 6, st4Bitmap.Width, st4Bitmap.Height);
            e.Graphics.DrawImage(st5Bitmap, 424, 6, st5Bitmap.Width, st5Bitmap.Height);
            e.Graphics.DrawImage(st6Bitmap, 527, 6, st6Bitmap.Width, st6Bitmap.Height);
        }

        private void MonsterPang_Paint2(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(hpBitmap, 10, 270, hpBitmap.Width, hpBitmap.Height); 
        }

        private void MonsterPang_Load(object sender, EventArgs e)
        {

        }
    }
}
