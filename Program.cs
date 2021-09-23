// Project Name:    VeeSay
// Description:     Enhanced cowsay clone for desktop ricers
// Project Home:    https://github.com/MarkSixtyFour/veesay

using System;
using System.Collections.Generic;
using System.Linq;

namespace VeeSay
{
    class Program
    {
        private static List<string> Character = new List<string> { 
            @"   .           .",
            @"  /^\         /^\",
            @" // \\       // \\",
            @" ||  ||     ||  ||",
            @" \\  ||     ||  //",
            @"  \\,((_~;~_)),//",
            @"   '.         .'",
            @"    /         \",
            @"    |.^.' '.^.|",
            @"    ||_| . |_||",
            @" .-.\_  ._.  _/.-.",
            @"'    ,'' , '',    '"
        };

        private static int MessageStart { get; } = Character.OrderByDescending(l => l.Length).First().Length;
        private static int ExcessChars { get; } = 4;
        private static int StandardConsoleWidth = 60;

        static void Main(string[] args)
        {
            string[] tokens;

            if (args.Length == 1)
            {
                tokens = args[0].Split(' ');
            }
            else if (args.Length > 1)
            {
                tokens = args;
            }
            else
            {
                string consoleInput = Console.In.ReadToEnd();
                tokens = consoleInput.Split(' ');
            }
                
            PadLines(Character, MessageStart);
            List<string> lines = SplitMessage(tokens, StandardConsoleWidth - ExcessChars);
            int midpoint = (Character.Count() / 2);
            int messageIndex = midpoint - lines.Count();

            if (messageIndex < 0)
            {
                int positionModifier = Math.Abs(messageIndex); 
                Character = BumpDown(Character, positionModifier, MessageStart);
                messageIndex = 0;
            }

            for (int i = 0; i < lines.Count; i++)
            {
                Character[messageIndex + i] += $"  {lines.ElementAt(i)}  ";
            }

            Character[messageIndex + lines.Count] += "/";
            Console.WriteLine(string.Join('\n', Character));
        }

        private static void PadLines(List<string> block, int width)
        {
            for (int i = 0; i < Character.Count(); i++)
                block[i] = block[i].PadRight(width, ' ');
        }

        private static List<string> BumpDown(List<string> block, int amount, int width)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < amount; i++)
                temp.Add(string.Empty.PadRight(width));
            
            temp.AddRange(block);
            return temp;
        }

        private static List<string> SplitMessage(string[] tokens, int width)
        {
            List<string> lines = new List<string>();
            string line = "";

            for (int i = 0; i < tokens.Length; i++)
            {
                if ((line.Trim().Length + tokens[i].Length) > width)
                {
                    lines.Add(line.Trim());
                    line = tokens[i] + ' ';
                }
                else if (i == (tokens.Length - 1))
                {
                    line += tokens[i].Replace("\n", "");
                    lines.Add(line);
                }
                else
                {
                    line += (tokens[i] + ' ');
                }
            }

            return lines;
        }
    }
}
