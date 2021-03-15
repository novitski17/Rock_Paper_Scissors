using System;
using System.Collections.Generic;


namespace Rock_Paper_Scissors
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine();

            AllMoves allMoves = new AllMoves();
            DataVerification verification = new DataVerification();
            RandomnessGeneration generationMoveAndKey = new RandomnessGeneration();
            DeterminationWinner winner = new DeterminationWinner();

            if (!verification.InputVerification(args) || !allMoves.IsSaveParams(args))
            {
               return;
            }

            while (true)
            {
                var key = generationMoveAndKey.GetNewKey();
                int computerMove = generationMoveAndKey.ComputerMove(args.Length);
                var keyHMAC = generationMoveAndKey.GetHMAC(allMoves.ListOfMoves[computerMove], key);
                Console.WriteLine("HMAC: " + DecodeByteFromString(keyHMAC)); 

                string valueUser;

                do
                {
                    ViewMenu(allMoves.ListOfMoves);
                    Console.Write("Enter your move: ");
                    valueUser = Console.ReadLine();

                } while (!verification.ResponseCheck(valueUser, allMoves.ListOfMoves));

                if (Convert.ToInt32(valueUser) == 0)
                {
                    Console.WriteLine();
                    return;
                }

                Console.WriteLine("Your move: " + allMoves.ListOfMoves[Convert.ToInt32(valueUser)]);
                Console.WriteLine("Computer move: " + allMoves.ListOfMoves[computerMove]);

                switch (winner.GetWinner(Convert.ToInt32(valueUser), computerMove, args.Length)) 
                {
                    case 0:
                        WriteLine("Draw!", ConsoleColor.Yellow);
                        break;

                    case 1:
                        WriteLine("You win!", ConsoleColor.Green);
                        break;

                    case -1:
                        WriteLine("You lost!", ConsoleColor.Red);
                        break;
                }
                Console.WriteLine("HMAC key: " + BitConverter.ToString(key).Replace("-", "") + "\n");
                WriteLine("New attempt: \n", ConsoleColor.Yellow);
            }
        }
               
        static string DecodeByteFromString(byte[] str)
        {
            return BitConverter.ToString(str, 0, str.Length).Replace("-", "").ToLower();
        }

        static public void ViewMenu(Dictionary<int, string> pairs)
        {
            Console.WriteLine("Available moves:");

            foreach (var item in pairs)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.WriteLine("0 - exit");
        }

        static void WriteLine(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }






}
