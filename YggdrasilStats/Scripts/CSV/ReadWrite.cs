using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YggdrasilStats.Scripts.CSV
{
    class ReadWrite
    {
        //TODO: add failsafes

        //argv[2] will contain filename (argv[0] = file, argv[1] = load/read/etc)
        public static void Start(string[] argv)
        {
            string cmd = argv[1].ToLower();
            //string filePath = argv[2];
            string file = argv[2]; //TODO: Add support to save file in a specified directory, possibly using code in FileDirectory
                                   //get filename, path if specified


            switch (cmd)
            {
                case "read":
                case "load":
                case "open":
                    {
                        Read(file);
                        break;
                    }
                default:
                    {
                        Console.WriteLine(ErrorMessages.invCommand);
                        break;
                    }
            }
        }

        //public static void Read(string[] argv)
        static void Read(string file)
        {
            //get delimiters, load
            //assume file being read is a .csv (obviously)

            /*
            2d array example:

            var[i, j]
            
            eg,
                {1, 2, 3, 4}
                {5, 6, 7, 8}

                would be int[2, 4]

            such that 

            */
            int i;
            int iMax;
            int j;
            int jMax;
            string filePath = System.IO.Path.Combine(Globals.directory, file);

            //TODO: ask user to input comment token/delimiters/etc, set to default if nothing entered (So I guess str = "")
            string commentToken = "#";
            char delimiter = ',';

            string[][] data; //jagged array
            //maybe make a list for each row and then add that to array

            StreamReader sr = new StreamReader(filePath);
            var lines = new List<string[]>();
            i = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(delimiter);
                lines.Add(Line);
                i++;
            }
            
            data = lines.ToArray();

            jMax = data[0].Length;
            iMax = data.Length;

            //Console.WriteLine("[1][1] = {0}\n[1][2] = {1}", data[1][1], data[1][2]);
            //Note: Mathematically, matrices are not 0-indexed

            Console.WriteLine("Rows: {0}\nColumns: {1}", iMax, jMax);

            ConvertArray(data, iMax, jMax);

            Console.WriteLine("File loaded: {0}", file);

            //test code below
            Console.WriteLine("[Test]\nElement at <1,1>: {0}\nElement at <{1},{2}>: {3}", Globals.dataArray[0, 0], iMax, jMax, Globals.dataArray[iMax - 1, jMax - 1]);
            for (i = 0; i < Globals.dataArray.GetLength(0); i++)
            {
                for (j = 0; j < Globals.dataArray.GetLength(1); j++)
                {
                    Console.Write("{0} ", Globals.dataArray[i, j]);
                }
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine("[End Test]");
        }

        static void Write()
        {

        }

        static void ConvertArray(string[][] jaggedArr, int rows, int columns)
        {
            //arrays in jaggedArr MUST be of equal length
            string[,] arr2d = new string[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    arr2d[i,j] = jaggedArr[i][j];
                }
            }

            Globals.dataArray = arr2d;
        }

        static bool CheckExtension(string file)
        {
            if (file.Length <= 4)
            {
                return false;
            }
            else
            {
                string extension = file.Substring(file.Length - 4);
                if (extension == ".csv")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
    }
}
