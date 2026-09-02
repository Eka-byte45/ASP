namespace Blazor.Components.Pages
{
    public partial class Power
    {
        int baseNumber;
        int exponent;
        double result;

        void CalculatePower()
        {
            result = 1;
            if (exponent == 0)
            {
                result = 1;
            }
            if (exponent < 0)
            {
                int plus = -exponent;

                for (int i = 1; i <= plus; i++)
                {
                    result *= baseNumber;
                }
                result = 1 / result;
            }

            else
            {
                for (int i = 1; i <= exponent; i++)
                {
                    result *= baseNumber;
                }
            }
        }
    }
}
