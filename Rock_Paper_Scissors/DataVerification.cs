using System;
using System.Collections.Generic;


namespace Rock_Paper_Scissors
{
    class DataVerification
    {
        public bool InputVerification(string[] args)  
        {
            if (args.Length == 0)
            {
                WriteLine("Input parameters are empty \n", ConsoleColor.Red);
                return false;
            }

            if (args.Length % 2 != 0 && args.Length >= 3)
            {
                return true;
            }

            WriteLine("Input error  'Data must not be even and> = 3' \n ", ConsoleColor.Red);
            return false;
        }

        public bool ResponseCheck(string valueUser, Dictionary<int, string> pairs)
        {
            int valUser;
            try
            {
                if (valueUser == string.Empty)
                {
                    WriteLine("The data is empty, re-enter it..  \n", ConsoleColor.Yellow);
                    return false;
                }
                valUser = Int32.Parse(valueUser);
               

                if (valUser == 0)
                {
                    return true;
                }

                foreach (var item in pairs)
                {
                    if (item.Key == valUser)
                    {
                        return true;
                    }
                }

                WriteLine("There is no entered number, please repeat the move  \n", ConsoleColor.Yellow);
                return false;

            }
            catch (Exception)
            {
                WriteLine("Please enter a valid number  \n", ConsoleColor.Yellow);
                return false;
            }
        }

        static void WriteLine(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }
}
