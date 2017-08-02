using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    /// <summary>
    /// Symetric matrix
    /// </summary>
    /// <typeparam name="T">Param</typeparam>
    public class SymetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="size">Size</param>
        public SymetricMatrix(int size) : this(size, size * (size + 1) / 2) {}

        protected SymetricMatrix(int size, int arraydimension) : base(size, arraydimension) {}

        protected override int GetArrayIndex(int i, int j)
        {
            if (i >= j) return i * (i + 1) / 2 + j;
            else return j * (j + 1) / 2 + i;
        }
    }
}
