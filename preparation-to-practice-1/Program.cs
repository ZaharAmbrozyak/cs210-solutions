using System;

namespace AlgorithmsSamplesh1
{
    public class ArrayList
    {
        private int[] _array = new int[10];
        private int _pointer = 0;

        public void Add(int element)
        {
            _array[_pointer] = element;
            _pointer += 1;

            if (_pointer == _array.Length)
            {
                var extendedArray = new int[_array.Length * 2];
                for (var i = 0; i < _array.Length; i++)
                {
                    extendedArray[i] = _array[i];
                }

                _array = extendedArray;
            }
        }
        public void Remove(int element)
        {
            for (int i = 0; i < _pointer; i++)
            {
                if (_array[i] == element)
                {
                    for (int j = i; j < _pointer - 1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }

                    _pointer -= 1;
                    return;
                }
            }
        }

        public int GetAt(int index)
        {
            return _array[index];
        }

        public int IndexOf(int element)
        {
            for (var i = 0; i < _array.Length; i++)
            {
                if (_array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int Count()
        {
            return _pointer;
        }
    }

    public class Stack
    {
        private const int Capacity = 50;

        private string[] _array = new string[Capacity];

        private int _pointer;

        public void Push(string value)
        {
            if (_pointer == _array.Length)
            {
                throw new Exception("Stack overflowed");
            }

            _array[_pointer] = value;
            _pointer++;
        }

        public string Pull()
        {
            if (_pointer == 0)
            {
                return null;
            }

            var value = _array[_pointer];
            _pointer--;
            return value;
        }
    }

    public class Queue
    {
        private int[] _array = new int[50];
        private int _pointer = 0;

        public void Add(int element)
        {
            if (_pointer == _array.Length)
            {
                throw new Exception("Queue overflowed!");
            }
            _array[_pointer] = element;
            _pointer++;
            
        }

        public int Pull()
        {
            if (_pointer == 0)
            {
                return -1;
            }

            int element = _array[0];
            for(var i = 1; i < _array.Length; i++)
            {
                _array[i - 1] = _array[i];
            }

            _pointer -= 1;
            return element;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Preparation for lesson 1");
            
        }
    }
}