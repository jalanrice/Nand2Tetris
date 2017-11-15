using System;
using System.Collections.Generic;
using System.Text;

namespace Assembler
{
    class Parser
    {
        public static int LineCount { get; set; }
        public static int CurrentLine { get; set; }

        public static List<string> Initializer(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Source\nand2tetris\" + fileName);

            var processedAssembly = new List<string>();
            

            foreach (string line in lines)
            {
                bool isComment = false;
                bool isWhiteSpace = string.IsNullOrWhiteSpace(line);
                if (!isWhiteSpace)
                {
                    isComment = (line[0] == '/') && (line[1] == '/');
                }
                
                if (!isComment && !isWhiteSpace)
                {
                    processedAssembly.Add(line);
                }
            }
            LineCount = processedAssembly.Count;

            return processedAssembly;
        }

        public static Boolean HasMoreCommands()
        {
            if (CurrentLine < LineCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Advance()
        {
            CurrentLine++;
        }

        public static string CommandType(string line)
        {
            bool isACommand = (line[0] == '@');
            bool isLCommand = line[0] == '(';
            if (isACommand)
            {
                return "ACommand";
            }
            else if (isLCommand)
            {
                return "LCommand";
            }
            else
            {
                return "CCommand";
            }
        }

        public static string Symbol(string line)
        {
            string binaryLine;
            int lineInt;
            //if(Char.IsNumber(line[1]))
            //{
                line = line.TrimStart('@');
                lineInt = Convert.ToInt32(line);
                binaryLine = Convert.ToString(lineInt, 2).PadLeft(16, '0');

                return binaryLine;
            //}

            
        }

        public static string Dest(string line)
        {
            var destDict = new Dictionary<string, string>()
            {
                { "null", "000" },
                { "M", "001" },
                { "D", "010" },
                { "MD", "011" },
                { "A", "100" },
                { "AM", "101" },
                { "AD", "110" },
                { "AMD", "111" }
            };

            string[] splitCommand = new string[] { "","" };

            

            if (line.Contains("="))
            {
                splitCommand = line.Split('=');
                return destDict[splitCommand[0]];
            }
            else
            {                
                return destDict["null"];
            }
        }

        public static string Comp(string line)
        {
            var compDict = new Dictionary<string, string>()
            {
                { "0", "0101010" },
                { "1", "0111111" },
                { "-1", "0111010" },
                { "D", "0001100" },
                { "A", "0110000" },
                { "!D", "0001101" },
                { "!A", "0110001" },
                { "-D", "0001111" },
                { "-A", "0110011" },
                { "D+1", "0011111" },
                { "A+1", "0110111" },
                { "D-1", "0001110" },
                { "A-1", "0110010" },
                { "D+A", "0000010" },
                { "D-A", "0010011" },
                { "A-D", "0000111" },
                { "D&A", "0000000" },
                { "D|A", "0010101" },
                { "M", "1110000" },
                { "!M", "1110001" },
                { "-M", "1110011" },
                { "M+1", "1110111" },
                { "M-1", "1110010" },
                { "D+M", "1000010" },
                { "D-M", "1010011" },
                { "M-D", "1000111" },
                { "D&M", "1000000" },
                { "D|M", "1010101" }
            };

            string[] splitCommand = new string[] { "", "", "" };
            

            if (line.Contains("="))
            {
                splitCommand = line.Split('=', ';');
                return compDict[splitCommand[1]];
            }
            else
            {
                splitCommand = line.Split(';');
                return compDict[splitCommand[0]];
            }
        }

        public static string Jump(string line)
        {
            var jumpDict = new Dictionary<string, string>()
            {
                { "null", "000" },
                { "JGT", "001" },
                { "JEQ", "010" },
                { "JGE", "011" },
                { "JLT", "100" },
                { "JNE", "101" },
                { "JLE", "110" },
                { "JMP", "111" }
            };

            string[] splitCommand = new string[] { "", "" };
            if (line.Contains(";"))
            {
                splitCommand = line.Split(';');
                return jumpDict[splitCommand[1]];
            }
            else
            {
                return jumpDict["null"];
            }

        }
    }
}
