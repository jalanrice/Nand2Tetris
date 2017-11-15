using System;
using System.IO;
using Assembler;
using System.Collections.Generic;
using static Assembler.Parser;

namespace Assembler
{
    class Program
    {
        static void Main(string[] arg)
        {
            MakeMachine();

        }

        static void MakeMachine()
        {
            Console.Write("File name: ");
            string file = Console.ReadLine();
            List<string> lines = Initializer(file);
            string path = @"c:\temp\" + file + ".txt";
            string machineCode = "";

            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (string line in lines)
                {
                    string commandType = CommandType(line);
                    if (commandType == "ACommand" || commandType == "LCommand")
                    {
                        //machineCode += Symbol(line) + "\r\n";
                        sw.WriteLine(Symbol(line));
                    }
                    else
                    {
                        string machineLine = "111" + Comp(line) + Dest(line) + Jump(line);
                        sw.WriteLine(machineLine);
                        //machineCode += machineLine;
                    }
                }
            }

        }

    }
}