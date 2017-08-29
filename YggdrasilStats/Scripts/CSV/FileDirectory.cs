using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YggdrasilStats.Scripts.CSV
{
    public static class FileDirectory
    {
        //static string[] invalidChars = {"*", "[", "]", "\"", ":", ";", "=", "," };
        static readonly char[] invalidChars = { '*', '[', ']', '"', ':', ';', '=', ',', '&', '#', '/' };
        
        public static void Start(string[] argv)
        {
            #region argtest
            //Console.WriteLine("TEST arguments:");
            //Console.Write(Environment.NewLine);
            //foreach (string value in argv)
            //{
            //    Console.Write("{0}, ", value);
            //}
            //Console.Write(Environment.NewLine);
            #endregion

            //Note: argvv[0] = Start(), argv[1] = subcommand, argv[2] = subsubcommand/filepath 
            switch (argv[1].ToLower())
            {
                case "arrtest":
                    {
                        //just prints invalid characters for setting a filepath
                        Console.WriteLine("Invalid Characters:");
                        Console.Write(Environment.NewLine);
                        foreach (char c in invalidChars)
                        {
                            Console.Write(c + " ");
                        }
                        Console.Write(Environment.NewLine);
                        break;
                    }
                case "set":
                    {
                        if (argv.Length < 3)
                        {
                            //in the event the user doesn't input a command after "set"
                            Console.WriteLine("Invalid argument.");
                        }
                        else if (argv[2].ToLower() == "default")
                        {
                            Globals.directory = Globals.defaultDirectory;
                            Globals.directorySet = true;
                            Console.WriteLine("Directory set to {0}", Globals.directory);
                        }
                        else
                        {
                            if (argv[2].IndexOfAny(invalidChars) == -1)
                            {
                                //IndexOfAny return -1 of no characters in array are found in target string
                                //valid command and filepath
                                //default to documents\yggdrasil statistics
                                //TODO: implement full path declaration, eg, C:\Bollocks\Project, probably involves changing ':' in invalidChars

                                Globals.directory = System.IO.Path.Combine(Globals.defaultDirectory, argv[2]);
                                Globals.directorySet = true;
                                Console.WriteLine("Directory set to {0}", Globals.directory);

                                FileCheck(Globals.directory);
                            }
                            else
                            {
                                //if invalid character(s) detected
                                Console.WriteLine("Invalid character detected.");
                                Console.WriteLine("The following characters are not allowed:");
                                foreach (char c in invalidChars)
                                {
                                    Console.Write("{0} ", c);
                                }
                                Console.WriteLine("Note: If declaring subfolders, \"\\\" must be used."); //sure is \ in here
                                Console.Write(Environment.NewLine);
                            }

                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid argument: default");
                        break;
                    }
            }
        }

        static void FileCheck(string filePath)
        {
            //check filepath and create it if it doesn't exist

            string defaultPath = Globals.defaultDirectory;
            //removes defaultPath from filePath, creating a string with only subfolders
            string subPath = filePath.Replace(defaultPath, "");
            string tempPath;
            
            //remove first \ if present
            if (subPath.ToCharArray()[0] == '\\')
            {
                subPath = subPath.Remove(0, 1);
            }

            //get subfolder names
            string[] subfolders = subPath.Split('\\');
            
            //default filepath:
            //TODO: edit default filepath check if/when full path declaration is implemented
            if (!System.IO.Directory.Exists(defaultPath))
            {
                Console.WriteLine("Directory not found -- creating {0}", defaultPath);
                System.IO.Directory.CreateDirectory(defaultPath);
            }

            //create subfolders if they don't exist:
            tempPath = defaultPath;
            for (int i = 0; i < subfolders.Length; i++)
            {
                tempPath = System.IO.Path.Combine(tempPath, subfolders[i]);
                if (!System.IO.Directory.Exists(tempPath))
                {
                    System.IO.Directory.CreateDirectory(tempPath);
                }
            }
            //Console.WriteLine("filepath: {0}\ntemppath: {1}", filePath, tempPath);
            Console.WriteLine("Directory found/created: {0}", filePath);
        }
    }
}
