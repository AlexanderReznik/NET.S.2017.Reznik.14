using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class Generator
    {
        /// <summary>
        /// Using foreach you can get first n Fibonacci numbers(but not more than 46)
        /// </summary>
        /// <param name="n">How many numbers you want to see</param>
        /// <returns>IEnumerable with fibonacci numbers</returns>
        public static IEnumerable<long> Generate(int n)
        {
            if(n < 1) throw new ArgumentException();
            if (n > 46) n = 46;
            long previous = 0;
            long current = 1;
            yield return 1;
            for (int i = 0; i < n - 1; i++)
            {
                long temp = current;
                current += previous;
                previous = temp;
                yield return current;
            }
        }
    }
}
