using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    public class Set<T> : IEnumerable<T>, IEquatable<Set<T>> where T : class, IEquatable<T>
    {
        #region fields

        private const int DefaultCapacity = 10;
        private T[] _array;

        #endregion

        #region Properties

        private T[] Array
        {
            get { return _array; }
            set
            {
                if (value == null) throw new ArgumentNullException();
                _array = value;
            }
        }

        /// <summary>
        /// Number of elements in set
        /// </summary>
        public int Size { get; private set; }

        private int Capacity => Array.Length;

        #endregion

        #region c-tors

        public Set() : this(DefaultCapacity)
        {
        }

        public Set(int capacity)
        {
            if (capacity < 1) throw new ArgumentException($"{nameof(capacity)} must be positive.");
            Array = new T[capacity];
            Size = 0;
        }

        public Set(IEnumerable<T> collection)
        {
            Array = new T[DefaultCapacity];
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds element
        /// </summary>
        /// <param name="item">Element to add</param>
        /// <returns>true if sucsessfull</returns>
        public bool Add(T item)
        {
            if (Contains(item)) return false;
            if (Size == Capacity) SetCapacity(2 * Capacity);
            Array[Size++] = item;
            return true;
        }

        /// <summary>
        /// Removes element
        /// </summary>
        /// <param name="item">Element to remove</param>
        /// <returns>true if sucsessfull</returns>
        public bool Remove(T item)
        {
            if (!Contains(item)) return false;
            for(int i = 0; i < Size; i++)
                if (item.Equals(Array[i]))
                {
                    Swap(ref Array[i], ref Array[Size - 1]);
                    Array[--Size] = null;
                }
            return true;
        }

        /// <summary>
        /// Finds element
        /// </summary>
        /// <param name="item">Element to find</param>
        /// <returns>True if finds</returns>
        public bool Contains(T item)
        {
            Check(item);
            for(int i = 0; i < Capacity; i++)
                if (item.Equals(Array[i])) return true;
            return false;
        }

        /// <summary>
        /// reset
        /// </summary>
        public void Clear()
        {
            Array = new T[DefaultCapacity];
            Size = 0;
        }

        /// <summary>
        /// Ads another set
        /// </summary>
        /// <param name="set">another set</param>
        public void Add(Set<T> set)
        {
            if(ReferenceEquals(set, null)) throw new ArgumentNullException();
            foreach (var item in set)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Removes another set
        /// </summary>
        /// <param name="set">another set</param>
        public void Remove(Set<T> set)
        {
            if (ReferenceEquals(set, null)) throw new ArgumentNullException();
            foreach (var item in set)
            {
                Remove(item);
            }
        }

        /// <summary>
        /// Is subset?
        /// </summary>
        /// <param name="set">another set</param>
        /// <returns>True if subset</returns>
        public bool Contains(Set<T> set)
        {
            if (ReferenceEquals(set, null)) throw new ArgumentNullException();
            foreach (var item in set)
            {
                if (!Contains(item)) return false;
            }
            return true;
        }

        /// <summary>
        /// Intersection
        /// </summary>
        /// <param name="lhs">set 1</param>
        /// <param name="rhs">set 2</param>
        /// <returns>Intersection</returns>
        public static Set<T> Intersection(Set<T> lhs, Set<T> rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException();
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException();
            Set<T> ans = new Set<T>();
            foreach (var item in lhs)
            {
                if (rhs.Contains(item)) ans.Add(item);
            }
            return ans;
        }

        /// <summary>
        /// Union
        /// </summary>
        /// <param name="lhs">set 1</param>
        /// <param name="rhs">set 2</param>
        /// <returns>Union</returns>
        public static Set<T> Union(Set<T> lhs, Set<T> rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException();
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException();
            Set<T> ans = new Set<T>();
            foreach (var item in lhs)
            {
                ans.Add(item);
            }
            foreach (var item in rhs)
            {
                ans.Add(item);
            }
            return ans;
        }

        /// <summary>
        /// SymmetricDifference
        /// </summary>
        /// <param name="lhs">set 1</param>
        /// <param name="rhs">set 2</param>
        /// <returns>SymmetricDifference</returns>
        public static Set<T> SymmetricDifference(Set<T> lhs, Set<T> rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException();
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException();
            Set <T> ans= Union(lhs, rhs);
            ans.Remove(Intersection(lhs, rhs));
            return ans;
        }

        /// <summary>
        /// Complement
        /// </summary>
        /// <param name="lhs">set 1</param>
        /// <param name="rhs">set 2</param>
        /// <returns>Complement</returns>
        public static Set<T> Complement(Set<T> lhs, Set<T> rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException();
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException();
            Set<T> ans = new Set<T>(lhs);
            ans.Remove(rhs);
            return ans;
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other">set to compare with</param>
        /// <returns>true if equals</returns>
        public bool Equals(Set<T> other)
        {
            if(ReferenceEquals(other, null)) throw new ArgumentNullException();

            if (Size != other.Size) return false;
            foreach (var item in other)
            {
                if (!Contains(item)) return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Set<T>)) return false;
            return this.Equals((Set<T>)obj);
        }

        #endregion

        #region Iterator

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return Array[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        #endregion

        #region Private

        private void Check(T item)
        {
            if (ReferenceEquals(item, null)) throw new ArgumentNullException();
        }
        private void Check(T lhs, T rhs)
        {
            Check(lhs);
            Check(rhs);
        }

        private void SetCapacity(int newcapacity)
        {
            System.Array.Resize(ref _array, newcapacity);
        }

        private void Swap(ref T lhs, ref T rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return;
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        #endregion
    }
}
