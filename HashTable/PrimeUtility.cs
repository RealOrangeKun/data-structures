namespace HashTable
{
    public class PrimeUtility
    {
        public static int GetNextPrime(int number)
        {
            if (number <= 1)
            {
                return 2; // The first prime number is 2
            }

            int nextCandidate = number;
            while (true)
            {
                if (IsPrime(nextCandidate))
                {
                    return nextCandidate;
                }
                nextCandidate++;
            }
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
