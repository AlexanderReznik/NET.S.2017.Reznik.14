using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public class DiagonalMatrix<T> : SymetricMatrix<T>
    {
        public DiagonalMatrix(int size) : this(size, size) { }

        protected DiagonalMatrix(int size, int arraydimension) : base(size, arraydimension) { }

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
