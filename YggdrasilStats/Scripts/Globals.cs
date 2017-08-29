using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YggdrasilStats.Scripts
{
    public static class Globals
    {
        public static string directory;
        public static string defaultDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Yggdrasil Statistics");
        public static bool directorySet = false;
    }
}
