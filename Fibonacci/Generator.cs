using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Fibonacci
{
    public class Generator
    {
        /// <summary>
        /// Using foreach you can get first n Fibonacci numbers
        /// </summary>
        /// <param name="n">How many numbers you want to see</param>
        /// <returns>IEnumerable with fibonacci numbers</returns>
        public static IEnumerable<BigInteger> Generate(long n)
        {
            if(n < 1) throw new ArgumentException();

            BigInteger previous = 0;
            BigInteger current = 1;
            yield return 1;
            for (long i = 0; i < n - 1; i++)
            {
                BigInteger temp = current;
                current += previous;
                previous = temp;
                yield return current;
            }
        }
    }
}
