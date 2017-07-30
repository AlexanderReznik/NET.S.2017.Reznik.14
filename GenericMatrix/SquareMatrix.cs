using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
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

        public override int M => Size;
        public override int N => Size;

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
