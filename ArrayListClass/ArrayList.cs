using System;

namespace ArrayListClass 
{
    public class ArrayList<T>
    {
        private T[] _array;

        private int FilledLength;

        public ArrayList()
        {
            _array = new T[10];
            FilledLength = 0;
        }

        public ArrayList(T element)
        {
            _array = new T[10];
            _array[0] = element;
            FilledLength = 1;
        }

        public ArrayList(T[] givenArray)
        {
            _array = givenArray;
            FilledLength = _array.Length;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < FilledLength; i++)
            {
                str += $"{_array[i]} ";
            }
            return str;
        }

        public int GetLength()
        {
            return FilledLength;
        }

        public T[] ToArray()
        {
            T[] outputArray = new T[FilledLength];
            for (int i = 0; i < FilledLength; i++)
            {
                outputArray[i] = _array[i];
            }
            return outputArray;
        }

        private void ShiftArrayElementsForward(int numberOfPositionsToShift, int positionStartShift)
        {
            while (FilledLength + numberOfPositionsToShift > _array.Length) Resize();
            for (int i = FilledLength + numberOfPositionsToShift - 1; i >= numberOfPositionsToShift + positionStartShift; i--)
            {
                _array[i] = _array[i - numberOfPositionsToShift];
            }
            FilledLength += numberOfPositionsToShift;
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
            if (FilledLength == _array.Length) Resize();
            _array[FilledLength] = val;
            FilledLength += 1;
        }

        public void AddLast(ArrayList<T> list)
        {
            while (FilledLength + list.GetLength() > _array.Length) Resize();
            for (int i = FilledLength, j = 0; i < FilledLength + list.GetLength(); j++, i++)
            {
                _array[i] = list.Get(j);
            }
            FilledLength += list.GetLength();
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
            if (idx > FilledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            if (idx < FilledLength)
            {
                ShiftArrayElementsForward(1, idx);
            }
            else if (FilledLength == _array.Length)
            {
                Resize();
                FilledLength += 1;
            }
            _array[idx] = val;
        }

        public void AddAt(int idx, ArrayList<T> list)
        {
            if (idx > FilledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            if (idx < FilledLength)
            {
                ShiftArrayElementsForward(list.GetLength(), idx);
            }
            else if (FilledLength == _array.Length)
            {
                while (FilledLength + list.GetLength() > _array.Length) Resize();
                FilledLength += list.GetLength();
            }
            for (int i = idx, j = 0; i < list.GetLength() + idx; j++, i++)
            {
                _array[i] = list.Get(j);
            }
        }

        public void Set(int idx, T val)
        {
            if (idx >= FilledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            _array[idx] = val;
        }

        private void ShiftArrayElementsBackward(int numberOfPositionsToShift, int positionStartShift)
        {
            while (FilledLength + numberOfPositionsToShift > _array.Length) Resize();
            for (int i = positionStartShift; i < FilledLength - numberOfPositionsToShift; i++)
            {
                _array[i] = _array[i + numberOfPositionsToShift];
            }
            FilledLength -= numberOfPositionsToShift;
            ResizeMinimize();
        }

        private void ResizeMinimize()
        {
            bool isClear = false;
            if (FilledLength == 0)
            {
                FilledLength = 10;
                isClear = true;
            }
            while (FilledLength <= (_array.Length * 2) / 3)
            {
                T[] smallerArray = new T[(_array.Length * 2) / 3];

                for (int i = 0; i < FilledLength; i++)
                {
                    smallerArray[i] = _array[i];
                }
                _array = smallerArray;
            }
            if (isClear) FilledLength = 0;
        }

        public void RemoveFirst()
        {
            ShiftArrayElementsBackward(1, 0);
        }

        public void RemoveLast()
        {
            FilledLength -= 1;
            ResizeMinimize();
        }

        public void RemoveAt(int idx)
        {
            if (idx >= FilledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            if (idx == 0) RemoveFirst();
            else if (idx == FilledLength - 1) RemoveLast();
            else
            {
                ShiftArrayElementsBackward(1, idx);
            }
        }

        public void RemoveFirstMultiple(int n)
        {
            if (n > FilledLength) throw new ArgumentException("Wrong amount: we don't have such amount of elements!");
            if (n < 0) throw new ArgumentException("Wrong amount: amount must be positive!");
            if (n == FilledLength)
            {
                FilledLength = 0;
                ResizeMinimize();
            }
            else ShiftArrayElementsBackward(n, 0);
        }

        public void RemoveLastMultiple(int n)
        {
            if (n > FilledLength) throw new ArgumentException("Wrong amount: we don't have such amount of elements!");
            if (n < 0) throw new ArgumentException("Wrong amount: amount must be positive!");
            if (n == FilledLength)
            {
                FilledLength = 0;
                ResizeMinimize();
            }
            else
            {
                FilledLength -= n;
                ResizeMinimize();
            }
        }

        public void RemoveAtMultiple(int idx, int n)
        {
            if (idx + n >= FilledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            if (n < 0) throw new ArgumentException("Wrong amount: amount must be positive!");

            if (idx + n == FilledLength - 1) RemoveLastMultiple(n);
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
            for (int i = 0; i < FilledLength; i++)
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
            return _array[FilledLength - 1];
        }

        public T Get(int idx)
        {
            if (idx >= FilledLength) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
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
            for (int i = 0; i < FilledLength / 2; i++)
            {
                Swap(i, FilledLength - 1 - i);
            }
        }
    }
}