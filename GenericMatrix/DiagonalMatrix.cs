using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    /// <summary>
    /// Abstract matrix
    /// </summary>
    /// <typeparam name="T">Param</typeparam>
    public class DiagonalMatrix<T> : AbstractMatrix<T>
    {
        /// <summary>
        /// C-tor
        /// </summary>
        /// <param name="size"></param>
        public DiagonalMatrix(int size) : base(size, size, size)
        {
            _size = size;
        }

        private readonly int _size;

        public override int Size => _size;

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
                if (i != j) return default(T);
                else return Array[i];
            }
            set {
                CheckIndexes(i, j);
                if (i != j) throw new InvalidOperationException();
                else Array[i] = value;
                OnChange(new ChangeEventArgs(i, j, "Diagonal Matrix"));
            }
        }
    }
}
