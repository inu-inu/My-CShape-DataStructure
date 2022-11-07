using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_C_Sharp_DataStructure.List
{
    public class ArrayList<T> : IEnumerable<T>
    {
        bool DefaultMaxCapacityIsX64 = true;
        bool IsMaximumCapacityReached = false;
        public const int MAXIMUM_ARRAY_LENGTH_x64 = 0X7FEFFFFF; //x64
        public const int MAXIMUM_ARRAY_LENGTH_x86 = 0x8000000; //x86

        private readonly T[] _emptyArray = new T[0];
        private const int _defaultCapacity = 8;
        private T[] _collections;
        /// <summary>
        /// Number of elements added to the array.
        /// </summary>
        private int _size { get; set; }
        public int Count { get { return _size; } }
        public int Capacity { get { return _collections.Length; } }
        public bool IsEmpty { get { return Count == 0; } }
        private void ThrowOutOfRangeException(string str = null)
        {
            throw new ArgumentOutOfRangeException(str);
        }
        public T First
        {
            get
            {
                if (Count == 0) { ThrowOutOfRangeException("List is empty"); }
                return _collections[0];
            }
        }
        public T Last
        {
            get
            {
                if (Count == 0) { ThrowOutOfRangeException("List is empty"); }
                return _collections[Count - 1];
            }
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > _size) { throw new IndexOutOfRangeException(); }
                return _collections[index];
            }
            set
            {
                if (index < 0 || index > _size) { throw new IndexOutOfRangeException(); }
                _collections[index] = value;
            }
        }
        public ArrayList() : this(0) { }
        public ArrayList(int capacity)
        {
            if (capacity < 0) { ThrowOutOfRangeException(); }
            if (capacity == 0)
            {
                _collections = _emptyArray;
            }
            else
            {
                _collections = new T[capacity];
            }
            _size = 0;
        }
        private void ensureCapacity(int minCapacity)
        {
            if (_collections.Length < minCapacity && IsMaximumCapacityReached == false)
            {
                int newCapacity = (_collections.Length == 0 ? _defaultCapacity : _collections.Length * 2);
                if (newCapacity < minCapacity)
                {
                    newCapacity = minCapacity;
                }
                this.resizeCapacity(newCapacity);
            }
        }
        private void resizeCapacity(int newCapacity)
        {
            if (newCapacity != _collections.Length && newCapacity > _size)
            {
                try
                {
                    Array.Resize<T>(ref _collections, newCapacity);
                }
                catch (OutOfMemoryException)
                {
                    if (DefaultMaxCapacityIsX64 == true)
                    {
                        DefaultMaxCapacityIsX64 = false;
                        ensureCapacity(newCapacity);
                    }
                    throw;
                }
            }
        }
        public void Add(T dataItem)
        {
            if (_size == _collections.Length)
            {
                ensureCapacity(_size + 1);
            }
            _collections[_size++] = dataItem;
        }
        public void AddRange(IEnumerable<T> elements)
        {
            if (elements == null) { throw new ArgumentNullException(); }
            if ((uint)_size + elements.Count() > MAXIMUM_ARRAY_LENGTH_x64) { throw new OverflowException(); }

            if (elements.Any())
            {
                ensureCapacity(_size + elements.Count());
                foreach (var e in elements)
                {
                    this.Add(e);
                }
            }
        }
        public void AddRepeatedly(T value, int count)
        {
            if (count < 0) {  ThrowOutOfRangeException(); }
            if ((uint)_size + count > MAXIMUM_ARRAY_LENGTH_x64) { throw new OverflowException(); }

            if (count > 0)
            {
                ensureCapacity(_size + count);
                for (int i = 0; i < count; i++)
                {
                    this.Add(value);
                }
            }
        }
        public void InsertAt(object value, int index)
        {
            if (index < 0) { }
        }
        public void Remove()
        {

        }
        public void RemoveAt(int index)
        {

        }
        public void Find()
        {

        }
        public void FindIndex()
        {

        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
