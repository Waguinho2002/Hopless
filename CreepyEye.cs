using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hopless
{
    public partial class CreepyEye : Form
    {
        public CreepyEye()
        {
            InitializeComponent();
        }

        private void CreepyEye_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private async void CreepyEye_Load(object sender, EventArgs e)
        {
            await Task.Delay(8000);
            this.Hide();
            await Task.Delay(5000);
            Jumpscare jmc = new Jumpscare();
            jmc.Show();
        }
    }
}
