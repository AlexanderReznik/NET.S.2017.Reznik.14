using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinarySearchTree
{
    public sealed class BinarySearchTree<T> : IEnumerable<T>
    {
        #region fields

        private readonly IComparer<T> _comparer;

        #endregion

        #region Properties

        private Node<T> Root { get; set; }
        private IComparer<T> Comparer => _comparer;

        #endregion

        #region C-tors

        /// <summary>
        /// Creates a tree with default comparision
        /// </summary>
        public BinarySearchTree()
        {
            CheckComparer("No default comparer. Use another c-tor.");
            Root = null;
            _comparer = Comparer<T>.Default;
        }

        /// <summary>
        ///  Creates a tree with comparision
        /// </summary>
        /// <param name="comparer">comparer</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            if (ReferenceEquals(comparer, null))
            {
                CheckComparer();
                comparer = Comparer<T>.Default;
            }
            Root = null;
            _comparer = comparer;
        }

        /// <summary>
        /// Creates a tree with comparision
        /// </summary>
        /// <param name="comparision">comparer</param>
        public BinarySearchTree(Comparison<T> comparision)
        {
            if (ReferenceEquals(comparision, null))
            {
                CheckComparer();
                comparision = Comparer<T>.Default.Compare;
            }
            Root = null;
            _comparer = Comparer<T>.Create(comparision);
        }


        #endregion

        #region Methods

        /// <summary>
        /// Adds an element if it's not exists in the tree
        /// </summary>
        /// <param name="element">Element to add</param>
        public void Add(T element)
        {
            Root = DoInsert(Root, element);
        }

        /// <summary>
        /// Adds a collection
        /// </summary>
        /// <param name="coll">Collection</param>
        public void Add(IEnumerable<T> coll)
        {
            if(coll == null) throw new ArgumentNullException();
            foreach (var t in coll)
            {
                Add(t);
            }
        }

        /// <summary>
        /// Finds an element
        /// </summary>
        /// <param name="element">Element to find</param>
        /// <returns>True if exists</returns>
        public bool Contains(T element) => Contains(Root, element);

        /// <summary>
        /// Clears the tree
        /// </summary>
        public void Clear()
        {
            Root = null;
        }

        /// <summary>
        /// PreOrderTraversal(root-left-right)
        /// </summary>
        /// <returns>IEnumerable for preorder</returns>
        public IEnumerable<T> PreOrderTraversal() => PreOrder(Root);

        /// <summary>
        /// PostOrderTraversal(left-right-root)
        /// </summary>
        /// <returns>IEnumerable for postorder</returns>
        public IEnumerable<T> PostOrderTraversal() => PostOrder(Root);

        /// <summary>
        /// InOrderTraversal(left-root-right)
        /// </summary>
        /// <returns>IEnumerable for inorder</returns>
        public IEnumerable<T> InOrderTraversal() => InOrder(Root);

        /// <summary>
        /// Now you can use foreach
        /// </summary>
        /// <returns>IEnumerator for inorder</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Private

        private Node<T> DoInsert(Node<T> node, T x)
        {
            if (node == null)
            {
                return new Node<T>(x);
            }
            int comp = Comparer.Compare(x, node.Value);
            if ( comp < 0) node.Left = DoInsert(node.Left, x);
            
            else if (comp > 0) node.Right = DoInsert(node.Right, x);
            
            return node;
        }

        private bool Contains(Node<T> node, T element)
        {
            if (node == null) return false;
            int comp = Comparer.Compare(node.Value, element);
            if (comp == 0) return true;
            else if (comp < 0) return Contains(node.Right, element);
            else return Contains(node.Left, element);
        }

        private Tuple<Node<T>, Node<T>> GetNode(T value, Node<T> node,Node<T> parent)
        {
            if (node == null) return new Tuple<Node<T>, Node<T>>(null, null);
            int comp = Comparer.Compare(value, node.Value);
            if (comp == 0) return new Tuple<Node<T>, Node<T>>(node, parent);
            else if (comp < 0) return GetNode(value, node.Left, node);
            else return GetNode(value, node.Right, node);
        }

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            yield return node.Value;
            if (node.Left != null)
                foreach (var n in PreOrder(node.Left))
                    yield return n;
            if (node.Right != null)
                foreach (var n in PreOrder(node.Right))
                    yield return n;
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node.Left != null)
                foreach (var n in InOrder(node.Left))
                    yield return n;
            yield return node.Value;
            if (node.Right != null)
                foreach (var n in InOrder(node.Right))
                    yield return n;
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node.Left != null)
                foreach (var n in PostOrder(node.Left))
                    yield return n;
            if (node.Right != null)
                foreach (var n in PostOrder(node.Right))
                    yield return n;
            yield return node.Value;
        }

        private void CheckComparer(string s = "")
        {
                if (!(typeof(T).GetInterfaces().Contains(typeof(IComparable)) || typeof(T).GetInterfaces().Contains(typeof(IComparable<T>))
                      || typeof(T).GetInterfaces().Contains(typeof(IComparer)) || typeof(T).GetInterfaces().Contains(typeof(IComparer<T>))))
                    throw new ArgumentNullException(s);
        }

        #endregion
    }

    internal sealed class Node<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Value { get; set; }

        public Node(T t)
        {
            Value = t;
            Left = null;
            Right = null;
        }
    }
}


