using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Hopless
{
    internal class CmdPrompts
    {
        public static void Kill(string fileName, string args)
        {
            ProcessStartInfo kill  = new ProcessStartInfo();
            kill.FileName = fileName;
            kill.Arguments = args;
            kill.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(kill);
            
        }

        public static void Start(string fileName, string args)
        {
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = fileName;
            p.Arguments = args;
            p.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(p);

        }
    }
}
