using System;
using System.Security.Cryptography;
using System.Text;


namespace Rock_Paper_Scissors
{
    class RandomnessGeneration
    {
        private HMAC Hmac;
        private Random randomMoveComputer;
        private readonly RandomNumberGenerator randomKey;

        public readonly int KeyBitSize = 256;

        public RandomnessGeneration()
        {
            Hmac = HMAC.Create("HMACSHA256");
            randomMoveComputer = new Random();
            randomKey = RandomNumberGenerator.Create();
        }

        public byte[] GetNewKey()
        {          
            var key = new byte[KeyBitSize / 16];
            randomKey.GetBytes(key);
            return key;
        }

        public byte[] GetHMAC(string computerMove, byte[] key)
        {
            Hmac.Key = Encoding.UTF8.GetBytes(BitConverter.ToString(key).Replace("-", ""));
            return Hmac.ComputeHash(Encoding.UTF8.GetBytes(computerMove));
        }

        public int ComputerMove(int count)
        {

            Console.WriteLine();
            return randomMoveComputer.Next(1, count);
        }



    }
}
