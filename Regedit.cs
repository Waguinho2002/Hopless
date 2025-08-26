using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Hopless
{
    internal class Regedit
    {
        public static void RegistryLM(string keyPath, string keyName, string keyValue)
        {
            var key = Registry.LocalMachine.CreateSubKey(keyPath);
            key.SetValue(keyName, keyValue);
            key.Flush();
        }

        public static void RegistryLM(string keyPath, string keyName, int keyValue)
        {
            var key = Registry.LocalMachine.CreateSubKey(keyPath);
            key.SetValue(keyName, keyValue);
            key.Flush();
        }

        public static void DeleteKeyLM(string keyPath, string KeyDeleteValue)
        {
            var key = Registry.LocalMachine.CreateSubKey(keyPath);
            key.DeleteValue(KeyDeleteValue);
            
        }
    }
}
