using System;

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

        /// <summary>
        /// Number of rows
        /// </summary>
        public override int M => _size;

        /// <summary>
        /// Number of columns
        /// </summary>
        public override int N => _size;

        protected override int GetArrayIndex(int i, int j) => i;

        protected override void CheckIndexesSet(int i, int j)
        {
            base.CheckIndexesSet(i, j);
            if(i != j) throw new InvalidOperationException("Can not change not diagonal element.");
        }

        protected override bool CheckIndexes(int i, int j)
        {
            base.CheckIndexes(i, j);
            return i == j;
        }
    }
}
