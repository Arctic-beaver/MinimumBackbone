using System;

namespace ArrayListClass
{
    public class ArrayList<T>
    {
        private T[] _array;

        private int _filledLength;

        public ArrayList()
        {
            _array = new T[10];
            _filledLength = 0;
        }

        public ArrayList(T element)
        {
            _array = new T[10];
            _array[0] = element;
            _filledLength = 1;
        }

        public ArrayList(T[] givenArray)
        {
            _array = givenArray;
            _filledLength = _array.Length;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < _filledLength; i++)
            {
                str += $"{_array[i]} ";
            }
            return str;
        }

        public int GetLength()
        {
            return _filledLength;
        }

        public T[] ToArray()
        {
            T[] outputArray = new T[_filledLength];
            for (int i = 0; i < _filledLength; i++)
            {
                outputArray[i] = _array[i];
            }
            return outputArray;
        }

        private void ShiftArrayElementsForward(int numberOfPositionsToShift, int positionStartShift)
        {
            while (_filledLength + numberOfPositionsToShift > _array.Length) Resize();
            for (int i = _filledLength + numberOfPositionsToShift - 1; i >= numberOfPositionsToShift + positionStartShift; i--)
            {
                _array[i] = _array[i - numberOfPositionsToShift];
            }
            _filledLength += numberOfPositionsToShift;
        }

        private void Resize()
        {
            T[] biggerArray = new T[(_array.Length * 3) / 2];

            for (int i = 0; i < _array.Length; i++)
            {
                biggerArray[i] = _array[i];
            }
            _array = biggerArray;
        }

        public void AddFirst(T val)
        {
            ShiftArrayElementsForward(1, 0);
            _array[0] = val;
        }

        public void AddFirst(ArrayList<T> list)
        {
            ShiftArrayElementsForward(list.GetLength(), 0);
            for (int i = 0; i < list.GetLength(); i++)
            {
                _array[i] = list.Get(i);
            }
        }

        public void AddLast(T val)
        {
            if (_filledLength == _array.Length) Resize();
            _array[_filledLength] = val;
            _filledLength += 1;
        }

        public void AddLast(ArrayList<T> list)
        {
            while (_filledLength + list.GetLength() > _array.Length) Resize();
            for (int i = _filledLength, j = 0; i < _filledLength + list.GetLength(); j++, i++)
            {
                _array[i] = list.Get(j);
            }
            _filledLength += list.GetLength();
        }

        public void Add(T val)
        {
            AddLast(val);
        }

        public void Add(ArrayList<T> list)
        {
            AddLast(list);
        }

        public void AddAt(int idx, T val)
        {
            if (idx > _filledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            if (idx < _filledLength)
            {
                ShiftArrayElementsForward(1, idx);
            }
            else if (_filledLength == _array.Length)
            {
                Resize();
                _filledLength += 1;
            }
            _array[idx] = val;
        }

        public void AddAt(int idx, ArrayList<T> list)
        {
            if (idx > _filledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            if (idx < _filledLength)
            {
                ShiftArrayElementsForward(list.GetLength(), idx);
            }
            else if (_filledLength == _array.Length)
            {
                while (_filledLength + list.GetLength() > _array.Length) Resize();
                _filledLength += list.GetLength();
            }
            for (int i = idx, j = 0; i < list.GetLength() + idx; j++, i++)
            {
                _array[i] = list.Get(j);
            }
        }

        public void Set(int idx, T val)
        {
            if (idx >= _filledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            _array[idx] = val;
        }

        private void ShiftArrayElementsBackward(int numberOfPositionsToShift, int positionStartShift)
        {
            while (_filledLength + numberOfPositionsToShift > _array.Length) Resize();
            for (int i = positionStartShift; i < _filledLength - numberOfPositionsToShift; i++)
            {
                _array[i] = _array[i + numberOfPositionsToShift];
            }
            _filledLength -= numberOfPositionsToShift;
            ResizeMinimize();
        }

        private void ResizeMinimize()
        {
            bool isClear = false;
            if (_filledLength == 0)
            {
                _filledLength = 10;
                isClear = true;
            }
            while (_filledLength <= (_array.Length * 2) / 3)
            {
                T[] smallerArray = new T[(_array.Length * 2) / 3];

                for (int i = 0; i < _filledLength; i++)
                {
                    smallerArray[i] = _array[i];
                }
                _array = smallerArray;
            }
            if (isClear) _filledLength = 0;
        }

        public void RemoveFirst()
        {
            ShiftArrayElementsBackward(1, 0);
        }

        public void RemoveLast()
        {
            _filledLength -= 1;
            ResizeMinimize();
        }

        public void RemoveAt(int idx)
        {
            if (idx >= _filledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            if (idx == 0) RemoveFirst();
            else if (idx == _filledLength - 1) RemoveLast();
            else
            {
                ShiftArrayElementsBackward(1, idx);
            }
        }

        public void RemoveFirstMultiple(int n)
        {
            if (n > _filledLength) throw new ArgumentException("Wrong amount: we don't have such amount of elements!");
            if (n < 0) throw new ArgumentException("Wrong amount: amount must be positive!");
            if (n == _filledLength)
            {
                _filledLength = 0;
                ResizeMinimize();
            }
            else ShiftArrayElementsBackward(n, 0);
        }

        public void RemoveLastMultiple(int n)
        {
            if (n > _filledLength) throw new ArgumentException("Wrong amount: we don't have such amount of elements!");
            if (n < 0) throw new ArgumentException("Wrong amount: amount must be positive!");
            if (n == _filledLength)
            {
                _filledLength = 0;
                ResizeMinimize();
            }
            else
            {
                _filledLength -= n;
                ResizeMinimize();
            }
        }

        public void RemoveAtMultiple(int idx, int n)
        {
            if (idx + n >= _filledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            if (n < 0) throw new ArgumentException("Wrong amount: amount must be positive!");

            if (idx + n == _filledLength - 1) RemoveLastMultiple(n);
            else ShiftArrayElementsBackward(n, idx);
        }

        public int RemoveFirst(T val)
        {
            int index = IndexOf(val);
            if (index != -1)
            {
                RemoveAt(index);
            }
            return index;
        }


        public int RemoveAll(T val) //- удалить все элементы, равные val(вернуть кол-во удалённых элементов)
        {
            int amount = 0;
            while (RemoveFirst(val) != -1)
            {
                amount += 1;
            }
            return amount;
        }

        public bool Contains(T val) //- проверка, есть ли элемент в списке
        {
            if (IndexOf(val) != -1) return true;
            else return false;
        }

        public int IndexOf(T val) //- вернёт индекс первого найденного элемента, равного val(или -1, если элементов с таким значением в списке нет)
        {
            for (int i = 0; i < _filledLength; i++)
            {
                //return position
                if (_array[i].Equals(val)) return i;
            }
            //if we haven't got such an element
            return -1;
        }

        public T GetFirst()
        {
            return _array[0];
        }

        public T GetLast()
        {
            return _array[_filledLength - 1];
        }

        public T Get(int idx)
        {
            if (idx >= _filledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            return _array[idx];
        }

        private void Swap(int indexF, int indexSec)
        {
            T tmp = _array[indexF];
            _array[indexF] = _array[indexSec];
            _array[indexSec] = tmp;
        }

        public void Reverse()
        {
            for (int i = 0; i < _filledLength / 2; i++)
            {
                Swap(i, _filledLength - 1 - i);
            }
        }
    }
}