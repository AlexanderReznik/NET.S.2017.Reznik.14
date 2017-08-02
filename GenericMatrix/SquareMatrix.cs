using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    /// <summary>
    /// Square matrix
    /// </summary>
    /// <typeparam name="T">Param</typeparam>
    public class SquareMatrix<T> : AbstractMatrix<T>
    {
        #region fields

        private readonly int _size;
        
        #endregion

        #region Properties

        /// <summary>
        /// Number of rows
        /// </summary>
        public override int M => _size;

        /// <summary>
        /// Number of columns
        /// </summary>
        public override int N => _size;
        
        #endregion

        #region C-tor

        /// <summary>
        /// C-tor
        /// </summary>
        /// <param name="size">Size</param>
        public SquareMatrix(int size) : this(size, size * size) { }

        protected SquareMatrix(int size, int arraydimension) : base(size, size, arraydimension)
        {
            _size = size;
        }

        #endregion

        #region Private

        protected override int GetArrayIndex(int i, int j) => i * N + j;

        #endregion
    }
}
