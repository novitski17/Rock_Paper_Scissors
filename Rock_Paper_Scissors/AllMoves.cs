using System;
using System.Collections.Generic;


namespace Rock_Paper_Scissors
{
    class AllMoves
    {
        public Dictionary<int, string> ListOfMoves { get; set; }

        public AllMoves()
        {
            ListOfMoves = new Dictionary<int, string>();
        }

        public bool IsSaveParams(string[] args)
        {

            for (int i = 0; i < args.Length; i++)
            {
                if (IsContain(args[i]))
                {
                    ListOfMoves[i + 1] = args[i];
                }
                else
                {
                    WriteLine("Input error 'entered parameters should not be repeated'. \n", ConsoleColor.Red);
                    return false;
                }

            }
            return true;
        }

        private bool IsContain(string arg)
        {
            foreach (var move in ListOfMoves)
            {
                if (arg == move.Value)
                {
                    return false;
                }
            }
            return true;
        }

        static void WriteLine(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }
}
