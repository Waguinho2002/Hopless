using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hopless
{
    public partial class Jumpscare : Form
    {
        public Jumpscare()
        {
            InitializeComponent();
        }

        SoundPlayer sound;

        private void Jumpscare_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private async void Jumpscare_Load(object sender, EventArgs e)
        {
            using (var fs = Properties.Resources.jumpscare)
            {
                sound = new SoundPlayer(fs);
                sound.Play();
            }
            await Task.Delay(5000);
            sound.Stop();
            this.Hide();
            Hopeless ho = new Hopeless();
            ho.ShowDialog();
        }
    }
}
