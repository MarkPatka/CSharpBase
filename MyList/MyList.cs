using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListHW
{
    class MyList<T> : IList<T>
    {
        T[] _array;
        int _size;
        int _capacity;

        public MyList()
        {
            _array = new T[0];
            _size = 0;
            _capacity = 0;
        }

        public MyList(IEnumerable<T> collection)
        {
            _array = new T[collection.Count()];
            _size = collection.Count();
            _capacity = collection.Count();

            for (int i = 0; i < collection.Count(); i++)
                _array[i] = collection.ElementAt(i);
        }

        public T this[int index]
        {                            
            get
            {
                if (index >= _size || index < 0) throw new IndexOutOfRangeException("Incorrect index.");
                return _array[index];
            }
            set
            {
                if (index >= _size || index < 0) throw new IndexOutOfRangeException("Incorrect index.");
                _array[index] = value;
            }
        }

        public int Count => _size;
        public int Capacity => _capacity;


        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (_size < _capacity)
            {
                _array[_size] = item;
                _size++;
            }
            else
            {
                T[] _tmp = new T[(int)((_capacity + 4) * 1.15)];

                for (int i = 0; i < _size; i++)
                {
                    _tmp[i] = _array[i];
                }

                _tmp[_size] = item;
                _size++;
                _capacity = _tmp.Length;
                _array = _tmp;
            }
        }

        private void AddCapacity()
        {
            T[] _tmp = new T[(int)((_capacity + 4) * 1.15)];

            for (int i = 0; i < _size; i++)
            {
                _tmp[i] = _array[i];
            }

            _size++;
            _capacity = _tmp.Length;
            _array = _tmp;
        }

        public void Clear() => _size = 0;

        public bool Contains(T item) => IndexOf(item) >= 0;
        

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (_size > array.Length - arrayIndex)
            {
                throw new System.ArgumentException("Destination array was not long enough. " +
                    "                               Check the destination index, length, " +
                    "                               and the array's lower bounds.");
            }
            for (int i = 0; i < _size; i++)
            {
                array[i + arrayIndex] = _array[i];
            }
        }

        public IEnumerator<T> GetEnumerator() => _array.GetEnumerator() as IEnumerator<T>;

        IEnumerator IEnumerable.GetEnumerator() => _array.GetEnumerator();

        public int IndexOf(T item)
        {
            int pos = -1;
            for (int i = 0; i < _size; i++)
            {
                if (_array[i].Equals(item))
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public int LastIndexOf(T item)
        {
            int pos = -1;
            for (int i = _size - 1; i >= 0; i--)
            {
                if (_array[i].Equals(item))
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public void Insert(int index, T item)
        {
            if (index > _size || index < 0) throw new IndexOutOfRangeException("The index is outside the bounds of the collection");

            if (_size < _capacity)
            {
                for (int i = 0; i <= _size - index; i++)
                {
                    _array[_size - i] = _array[_size - i - 1];
                }
                _size++;
                _array[index] = item;
            }
            else
            {
                AddCapacity();
                for (int i = 0; i <= _size - index; i++)
                {
                    _array[_size - i] = _array[_size - i - 1];
                }
                _array[index] = item;
            }
        }

        public bool Remove(T item)
        {
            bool check = Contains(item);
            if (check == true && _size < _capacity)
            {
                for (int i = IndexOf(item); i < _size - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
                _size--;
                return true;
            }
            else if (check == true && _size >= _capacity)
            {
                AddCapacity();
                for (int i = IndexOf(item); i < _size - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
                _size -= 2;
                return true;
            }
            else return false;

        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _size) throw new IndexOutOfRangeException("Incorrect Index");
            for (int i = index; i < _size - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _size--;
        }
    }
}
