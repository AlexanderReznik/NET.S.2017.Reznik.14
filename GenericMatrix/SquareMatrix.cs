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
        /// Dimension of square matrix
        /// </summary>
        public int Size => _size;

        /// <summary>
        /// Number of rows
        /// </summary>
        public override int M => Size;

        /// <summary>
        /// Number of columns
        /// </summary>
        public override int N => Size;

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        /// <returns>Element</returns>
        public override T this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);
                return Array[i*Size + j];
            }
            set
            {
                CheckIndexes(i, j);
                Array[i*Size + j] = value;
                OnChange(new ChangeEventArgs(i, j, "Square Matrix"));
            }
        }

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

        

        #endregion
    }
}
