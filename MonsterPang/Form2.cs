using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MonsterPang
{
    public partial class LvUpDiag : Form
    {
        private Bitmap ending = Properties.Resources.end;

        public LvUpDiag()
        {
            InitializeComponent();
            SoundPlayer sndplayr = new SoundPlayer(Properties.Resources.lvUpSound);
            sndplayr.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
