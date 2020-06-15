
namespace Rock_Paper_Scissors
{
    class DeterminationWinner
    {
        public int GetWinner(int userMove, int computerMove, int count)
        {
            if (userMove == computerMove)
            {
                return 0; 
            }
            int[] winValueForUser = GetWinValueForUser(computerMove, count);
            foreach (var item in winValueForUser)
            {
                if (userMove == item)
                {
                    return 1;    
                }
            }
            return -1; 
        }

        private int[] GetWinValueForUser(int hodKomp, int count)
        {
            int[] winValue = new int[(count - 1) / 2];
            for (int i = 0; i < winValue.Length; i++)
            {
                winValue[i] = hodKomp + i + 1;
            }
            return winValue;
        }
    }
}
