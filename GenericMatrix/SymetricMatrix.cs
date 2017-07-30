using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public class SymetricMatrix<T> : SquareMatrix<T>
    {
        public SymetricMatrix(int size) : this(size, size * (size + 1) / 2) {}

        protected SymetricMatrix(int size, int arraydimension) : base(size, arraydimension) {}

        public override T this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);
                if (i >= j) return Array[i * (i + 1) / 2 + j];
                else return Array[j * (j + 1) / 2 + i];
            }
            set
            {
                CheckIndexes(i, j);
                if (i >= j) Array[i * (i + 1) / 2 + j] = value;
                else Array[j * (j + 1) / 2 + i] = value;
                OnChange(new ChangeEventArgs(i, j, "Symetric Matrix"));
            }
        }
    }
}
