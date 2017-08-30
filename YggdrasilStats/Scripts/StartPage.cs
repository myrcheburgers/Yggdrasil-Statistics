using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YggdrasilStats.Scripts;
using YggdrasilStats.Scripts.CSV;

namespace YggdrasilStats
{
    class StartPage
    {
        static bool exit = false;

        static void Main(string[] args)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string author = "Taylor J Witt";
            string[] commands = { "help", "directory", "file", "reset", "exit" };
            bool confirm = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to Yggdrasil Statistics. \n\nAuthor: {0}\nVersion: {1}", author, version);
                Console.Write(Environment.NewLine);
                Console.WriteLine("Enter arguments: (type \"help\" for commands)");

                //string input = Console.ReadLine().ToLower();
                //might need some arguments to be case-sensitive in the future, eg, file names

                

                #region inputTest
                //Console.WriteLine("TEST arguments:");
                //int i = 0;
                //foreach (string value in argv)
                //{
                //    Console.Write("{0} " + value + " ", i);
                //    i++;
                //}
                //Console.Write(Environment.NewLine);
                #endregion

                while (!confirm)
                {
                    string input = Console.ReadLine();
                    string[] argv = input.Split(' ');

                    switch (argv[0].ToLower())
                    {
                        case "help":
                            {
                                Console.Write(Environment.NewLine);
                                foreach (string value in commands)
                                {
                                    Console.Write("{0}, ", value);
                                }
                                Console.Write(Environment.NewLine);
                                break;
                            }
                        case "dir":
                        case "directory":
                            {
                                FileDirectory.Start(argv);
                                break;
                            }
                        case "file":
                            {
                                ReadWrite.Start(argv);
                                break;
                            }
                        case "exit":
                        case "quit":
                            {
                                confirm = true;
                                exit = true;
                                break;
                            }
                        case "reset":
                        case "restart":
                        case "res":
                            {
                                Globals.Reset();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid command. Enter arguments or type \"help\"");
                                break;
                            }
                    }
                }
                
            }
        }
    }
}
