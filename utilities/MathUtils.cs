using System;
using System.Collections.Generic;
using System.Text;

namespace utilities
{
    public static class MathUtils
    {
        public static int NumberOfDigits(int x)
        {
            // Summary
            //
            // Method returns number of digits of an interger. If input is negative, the
            // sign is ignored and must be managed by the caller

            if (x == 0) return 1;
            if (x < 0) x *= -1;

            return (int)Math.Floor(Math.Log10(x) + 1);
        }

        public static IEnumerable<int> GetDigits(int x)
        {
            // Summary
            //
            // Method returns digits of an integer. If input is negative, the
            // sign is ignored and must be managed by the caller

            var numDigits = (int)(Math.Log10(x) + 1);

            if (x < 0)
            {
                x *= -1;
            }

            for (int i = 0; i < numDigits; i++)
            {
                yield return (x % 10);
                x /= 10;
            }
        }
    }
}
