using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public static class MatrixOperations
    {
        public static DiagonalMatrix<T> Sum<T>(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            Check(lhs, rhs);
            DiagonalMatrix<T> answer = new DiagonalMatrix<T>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
                answer[i, i] = (dynamic)lhs[i, i] + rhs[i, i];
            return answer;
        }

        public static SymetricMatrix<T> Sum<T>(SymetricMatrix<T> lhs, SymetricMatrix<T> rhs)
        {
            Check(lhs, rhs);
            SymetricMatrix<T> answer = new SymetricMatrix<T>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
                for(int j = 0; j <= i; j++)
                    answer[i, j] = (dynamic)lhs[i, j] + rhs[i, j];
            return answer;
        }

        public static SquareMatrix<T> Sum<T>(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            Check(lhs, rhs);
            SquareMatrix<T> answer = new SquareMatrix<T>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
                for (int j = 0; j <lhs.Size; j++)
                    answer[i, j] = (dynamic)lhs[i, j] + rhs[i, j];
            return answer;
        }

        private static void Check<T>(AbstractMatrix<T> lhs, AbstractMatrix<T> rhs)
        {
            if(ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) throw new ArgumentNullException();
            if(lhs.M != rhs.M || lhs.N != rhs.N) throw new ArgumentException("Incorrect size.");
        }
    }
}
