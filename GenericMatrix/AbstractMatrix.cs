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
        public virtual T this[int i, int j] {
            get
            {
                CheckIndexes(i, j);
                return Array[i*N + j];
            }
            set
            {
                CheckIndexes(i, j);
                Array[i*N + j] = value;
                OnChange(new ChangeEventArgs(i, j, "Matrix"));
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

        /// <summary>
        /// String representation
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sb.Append(this[i, j]);
                    sb.Append(" ");
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        #region private

        protected void OnChange(ChangeEventArgs e)
        {
            var temp = Change;
            temp?.Invoke(this, e);
        }

        protected void CheckIndexes(int i, int j)
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
    #region fields
    private readonly int i;
    private readonly int j;
    private readonly string message;
    #endregion

    #region ctor
    public ChangeEventArgs(int i, int j, string message)
    {
        this.i = i;
        this.j = j;
        this.message = message;
    }
    #endregion

    #region properties
    public int I { get { return i; } }
    public int J { get { return j; } }
    public string Message { get { return message; } }
    #endregion
}
#endregion
