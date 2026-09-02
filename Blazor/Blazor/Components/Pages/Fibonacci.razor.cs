using System.Numerics;

namespace Blazor.Components.Pages
{
    public partial class Fibonacci
    {
        int number;
        BigInteger[]? result;

        void CalculateFibonacci()
        {
            if (number <= 0) return;
            result = new BigInteger[number];
            if (number > 0) result[0] = 0;
            if (number > 1) result[1] = 1;
            for (int i = 2; i < number; i++)
            {
                result[i] = result[i - 1] + result[i - 2];
            }
        }
        string DisplayResult()
        {
            return result == null ? "" : string.Join(", ", result);
        }
    }
}
