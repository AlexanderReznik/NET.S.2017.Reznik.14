using System;
using Microsoft.CSharp.RuntimeBinder;

namespace GenericMatrix
{
    /// <summary>
    /// Operations on matrix
    /// </summary>
    public static class MatrixOperations
    {
        /// <summary>
        /// Adding matrix
        /// </summary>
        /// <typeparam name="T">Param of matrix</typeparam>
        /// <param name="lhs">First matrix</param>
        /// <param name="rhs">Second matrix</param>
        /// <returns>Sum of the first and the second</returns>
        public static AbstractMatrix<T> Add<T>(AbstractMatrix<T> lhs, AbstractMatrix<T> rhs)
        {
            return Sum((dynamic) lhs, (dynamic) rhs);
        }

        /// <summary>
        /// Adding matrix
        /// </summary>
        /// <typeparam name="T">Param of matrix</typeparam>
        /// <param name="lhs">First matrix</param>
        /// <param name="rhs">Second matrix</param>
        /// <returns>Sum of the first and the second</returns>
        private static DiagonalMatrix<T> Sum<T>(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            Check(lhs, rhs);
            DiagonalMatrix<T> answer = new DiagonalMatrix<T>(lhs.M);
            for (int i = 0; i < lhs.M; i++)
                answer[i, i] = AddT(lhs[i, i],rhs[i, i]);
            return answer;
        }

        /// <summary>
        /// Adding matrix
        /// </summary>
        /// <typeparam name="T">Param of matrix</typeparam>
        /// <param name="lhs">First matrix</param>
        /// <param name="rhs">Second matrix</param>
        /// <returns>Sum of the first and the second</returns>
        private static SymetricMatrix<T> Sum<T>(SymetricMatrix<T> lhs, SymetricMatrix<T> rhs)
        {
            Check(lhs, rhs);
            SymetricMatrix<T> answer = new SymetricMatrix<T>(lhs.M);
            for (int i = 0; i < lhs.M; i++)
                for(int j = 0; j <= i; j++)
                    answer[i, j] = AddT(lhs[i, j], rhs[i, j]);
            return answer;
        }

        /// <summary>
        /// Adding matrix
        /// </summary>
        /// <typeparam name="T">Param of matrix</typeparam>
        /// <param name="lhs">First matrix</param>
        /// <param name="rhs">Second matrix</param>
        /// <returns>Sum of the first and the second</returns>
        private static SquareMatrix<T> Sum<T>(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            Check(lhs, rhs);
            SquareMatrix<T> answer = new SquareMatrix<T>(lhs.M);
            for (int i = 0; i < lhs.M; i++)
                for (int j = 0; j <lhs.M; j++)
                    answer[i, j] = AddT(lhs[i, j], rhs[i, j]);
            return answer;
        }

        private static SquareMatrix<T> Sum<T>(SquareMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            Check(lhs, rhs);
            SquareMatrix<T> answer = new SquareMatrix<T>(lhs.M);
            for (int i = 0; i < lhs.M; i++)
            for (int j = 0; j < lhs.M; j++)
                answer[i, j] = AddT(lhs[i, j], rhs[i, j]);
            return answer;
        }

        private static SquareMatrix<T> Sum<T>(DiagonalMatrix<T> lhs, SquareMatrix<T> rhs) => Sum(rhs, lhs);

        private static SymetricMatrix<T> Sum<T>(SymetricMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            Check(lhs, rhs);
            SymetricMatrix<T> answer = new SymetricMatrix<T>(lhs.M);
            for (int i = 0; i < lhs.M; i++)
            for (int j = 0; j <= i; j++)
                answer[i, j] = AddT(lhs[i, j], rhs[i, j]);
            return answer;
        }

        private static SquareMatrix<T> Sum<T>(DiagonalMatrix<T> lhs, SymetricMatrix<T> rhs) => Sum(rhs, lhs);

        private static void Check<T>(AbstractMatrix<T> lhs, AbstractMatrix<T> rhs)
        {
            if(ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) throw new ArgumentNullException();
            if(lhs.M != rhs.M || lhs.N != rhs.N) throw new ArgumentException("Incorrect size.");
        }

        private static T AddT<T>(T lhs, T rhs)
        {
            try
            {
                return (dynamic) lhs + rhs;
            }
            catch (RuntimeBinderException e)
            {
                throw new InvalidOperationException($"Operation + is not defined for {typeof(T)}");
            }
        }
    }
}
