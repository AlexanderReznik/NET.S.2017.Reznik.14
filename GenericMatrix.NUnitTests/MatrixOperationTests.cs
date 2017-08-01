using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static GenericMatrix.MatrixOperations;

namespace GenericMatrix.NUnitTests
{
    public class MatrixOperationTests
    {
        [Test]
        public static void Sum_IntSquareSquare()
        {
            SquareMatrix<int> m1 = new SquareMatrix<int>(3);
            for(int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                m1[i, j] = 3 * i + j;
            SquareMatrix<int> m2 = new SquareMatrix<int>(3);
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                m2[i, j] = 3 * i + j;
            AbstractMatrix<int> m = Add(m1, m2);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(m[i, j], 2*(3 * i + j));
            Assert.AreEqual(m.GetType(), typeof(SquareMatrix<int>));
        }
        [Test]
        public static void Sum_IntSquareSymetric()
        {
            SquareMatrix<int> m1 = new SquareMatrix<int>(3);
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                m1[i, j] = 3 * i + j;
            SymetricMatrix<int> m2 = new SymetricMatrix<int>(3);
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                m2[i, j] = 1;
            AbstractMatrix<int> m = Add(m1, m2);
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                Assert.AreEqual(m[i, j], 1 + 3 * i + j);
            Assert.AreEqual(m.GetType(), typeof(SquareMatrix<int>));
        }
        [Test]
        public static void Sum_IntSymetricSymetric()
        {
            SymetricMatrix<int> m2 = new SymetricMatrix<int>(3);
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                m2[i, j] = 1;
            SymetricMatrix<int> m1 = m2;
            AbstractMatrix<int> m = Add(m1, m2);
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                Assert.AreEqual(m[i, j], 2 * m1[i, j]);
            Assert.AreEqual(m.GetType(), typeof(SymetricMatrix<int>));
        }
        [Test]
        public static void Sum_IntSymetricDiagonal()
        {
            SymetricMatrix<int> m2 = new SymetricMatrix<int>(3);
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                m2[i, j] = 1;
            DiagonalMatrix<int> m1 = new DiagonalMatrix<int>(3);
            for (int i = 0; i < 3; i++)
                m1[i, i] = 1;
            AbstractMatrix<int> m = Add(m1, m2);
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                Assert.AreEqual(m[i, j], i == j ? 2 : 1);
            Assert.AreEqual(m.GetType(), typeof(SymetricMatrix<int>));
        }
        [Test]
        public static void Sum_IntDiagonalDiagonal()
        {
            DiagonalMatrix<int> m2 = new DiagonalMatrix<int>(3);
            for (int i = 0; i < 3; i++)
                m2[i, i] = 5;
            DiagonalMatrix<int> m1 = new DiagonalMatrix<int>(3);
            for (int i = 0; i < 3; i++)
                m1[i, i] = 1;
            AbstractMatrix<int> m = Add(m1, m2);
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                Assert.AreEqual(m[i, j], i == j ? 6 : 0);
            Assert.AreEqual(m.GetType(), typeof(DiagonalMatrix<int>));
        }
    }
}
