namespace App;

public static class Algorithms
{
    public static ICollection<int> FindPrimeNumbers(int minimum = 1, int maximum = 1000)
    {
        return Enumerable.Range(minimum, maximum - minimum + 1)
            .Where(IsPrimeNumber)
            .ToList();
    }

    private static bool IsPrimeNumber(int number)
    {
        if (number % 2 == 0)
        {
            return number == 2;
        }

        var max = (int)Math.Sqrt(number);

        for (var index = 3; index <= max; index += 2)
        {
            if (number % index == 0)
            {
                return false;
            }
        }

        return true;
    }
}
