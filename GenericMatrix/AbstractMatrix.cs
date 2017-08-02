using System;

namespace GenericMatrix
{
    /// <summary>
    /// Abstract matrix
    /// </summary>
    /// <typeparam name="T">Param</typeparam>
    public abstract class AbstractMatrix<T>
    {
        #region fields

        private readonly T[] _array;
        /// <summary>
        /// Event
        /// </summary>
        public event EventHandler<ChangeEventArgs> Change = delegate { };

        #endregion

        #region Properties
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        /// <returns>Element</returns>
        public T this[int i, int j] {
            get
            {
                if(!CheckIndexes(i, j)) return default(T);
                return Array[GetArrayIndex(i, j)];
            }
            set
            {
                CheckIndexesSet(i, j);
                Array[GetArrayIndex(i, j)] = value;
                OnChange(new ChangeEventArgs(i, j, "Changed"));
            }
        }
        /// <summary>
        /// Number of rows
        /// </summary>
        public virtual int M { get; }
        /// <summary>
        /// Number of columns
        /// </summary>
        public virtual int N { get; }

        protected T[] Array => _array;

        #endregion

        protected AbstractMatrix(int m, int n, int arraydimension)
        {
            if(m < 1 || n < 1) throw new ArgumentException("Incorrect size.");
            _array = new T[arraydimension];
            M = m;
            N = n;
        }

        #region private

        protected virtual int GetArrayIndex(int i, int j)
        {
            return i * N + j;
        }

        protected void OnChange(ChangeEventArgs e)
        {
            var temp = Change;
            temp?.Invoke(this, e);
        }

        protected virtual bool CheckIndexes(int i, int j)
        {
            if (i < 0 || i >= M) throw new ArgumentException($"{nameof(i)} must be from 0 to matrix number of rows({M}).");
            if (j < 0 || j >= N) throw new ArgumentException($"{nameof(j)} must be from 0 to matrix number of columns({N}).");
            return true;
        }

        protected virtual void CheckIndexesSet(int i, int j)
        {
            if (i < 0 || i >= M) throw new ArgumentException($"{nameof(i)} must be from 0 to matrix number of rows({M}).");
            if (j < 0 || j >= N) throw new ArgumentException($"{nameof(j)} must be from 0 to matrix number of columns({N}).");
        }

        #endregion


    }
}

#region ChangeEventArgs

public sealed class ChangeEventArgs : EventArgs
{
    #region ctor
    public ChangeEventArgs(int i, int j, string message)
    {
        I = i;
        J = j;
        Message = message;
    }
    #endregion

    #region properties

    public int I { get; }
    public int J { get; }
    public string Message { get; }

    #endregion
}
#endregion
