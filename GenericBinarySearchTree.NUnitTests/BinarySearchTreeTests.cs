using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BookLibrary;


namespace GenericBinarySearchTree.NUnitTests
{
    public class BinarySearchTreeTests
    {
        [TestCase(new int[] {91, 82, 73, 64, 55, 46, 169, 67, 46}, ExpectedResult = true)]
        public bool Tree_IntTest(int[] array)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int> {array};
            BinarySearchTree<int> treeModulo = new BinarySearchTree<int>(new IntComparer()) {array};
            IntComparer comp = new IntComparer();
            List<int> al = new List<int>(tree);
            for(int i = 1; i < al.Count; i++)
                if (al[i] < al[i - 1]) return false;
            al = new List<int>(treeModulo);
            for (int i = 1; i < al.Count; i++)
                if (comp.Compare(al[i], al[i - 1]) < 0) return false;
            return true;
        }

        [TestCase( "4591", "8276868", "723", "4", "555555555555", "4326", "1679", "607", "46" , ExpectedResult = true)]
        public bool Tree_StringTest(params string[] array)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string> { array };
            BinarySearchTree<string> treeModulo = new BinarySearchTree<string>(new StringComparer()) { array };
            StringComparer comp = new StringComparer();
            List<string> al = new List<string>(tree);
            for (int i = 1; i < al.Count; i++)
                if (al[i].CompareTo(al[i - 1]) < 0) return false;
            al = new List<string>(treeModulo);
            for (int i = 1; i < al.Count; i++)
                if (comp.Compare(al[i], al[i - 1]) < 0) return false;
            return true;
        }

        [TestCase(ExpectedResult = true)]
        public bool Tree_BookTest()
        {
            List<Book> array = new List<Book>();
            array.Add(new Book("qwer", "qwer", 123, 123));
            array.Add(new Book("asdf", "asdf", 456, 456));
            array.Add(new Book("zxcv", "zxcv", 789, 789));
            array.Add(new Book("tyui", "tyui", 741, 741));
            array.Add(new Book("ghjk", "ghjk", 852, 852));
            array.Add(new Book("bnm,", "bnm,", 963, 963));
            BinarySearchTree<Book> tree = new BinarySearchTree<Book> { array };
            BinarySearchTree<Book> treeModulo = new BinarySearchTree<Book>(new BookComparer()) { array };
            BookComparer comp = new BookComparer();
            List<Book> al = new List<Book>(tree);
            for (int i = 1; i < al.Count; i++)
                if (al[i].CompareTo(al[i - 1]) < 0) return false;
            al = new List<Book>(treeModulo);
            for (int i = 1; i < al.Count; i++)
                if (comp.Compare(al[i], al[i - 1]) < 0) return false;
            return true;
        }

        [TestCase(new int[] { 91, 82, 73, 64, 55, 46, 169, 67, 46, 97 }, ExpectedResult = true)]
        public bool Tree_PointTest(int[] arrayInt)
        {
            Point[] array = new Point[5];
            for(int i = 0; i < 5; i++)
                array[i] = new Point(arrayInt[2*i], arrayInt[2 * i + 1]);
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(new PointComparer()) { array };
            PointComparer comp = new PointComparer();
            List<Point> al = new List<Point>(tree);
            for (int i = 1; i < al.Count; i++)
                if (comp.Compare(al[i], al[i - 1]) < 0) return false;
            return true;
        }
    }

    public class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x % 10 - y % 10;
        }
    }

    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.Length - y.Length;
        }
    }

    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Year - y.Year;
        }
    }

    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return x.X - y.X;
        }
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
