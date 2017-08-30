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
        public static string temporaryDirectory;
        public static bool directorySet = false;

        public static string[,] dataArray;

        public static void Reset()
        {
            directory = defaultDirectory;
            temporaryDirectory = string.Empty;
            directorySet = false;

            Array.Clear(dataArray, 0, dataArray.Length);

            Console.WriteLine("Global variables have been reset."); //may want to change this message in the future
        }
    }

    public static class ErrorMessages
    {
        public static string invCommand = "Invalid command.";
    }
}
