using System;

namespace LinkedListClass
{
    public class LinkedList<T> 
    {

        private Node<T> _head;
        private Node<T> _tail;

        public LinkedList()
        {
            _head = null;
            _tail = null;
        }

        public LinkedList(T val)
        {
            InitHeadAndTail();
            Node<T> newNode = new Node<T>(val);
            _head = newNode;
            _tail = newNode;
        }

        public LinkedList(T[] array)
        {
            InitHeadAndTail();
            if (array.Length == 0) return;

            Node<T> shovel = new Node<T>(array[0]);
            _head = shovel;

            for (int i = 1; i < array.Length; i++)
            {
                shovel.Next = new Node<T>(array[i]);
                shovel = shovel.Next;
            }
            _tail = shovel;
        }

        public void Print()
        {
            Console.WriteLine();
            string str = ToString();
            Console.WriteLine(str);
        }

        public override string ToString()
        {
            Node<T> shovel = _head;
            string str = "";
            while (shovel != null)
            {
                str += $"{shovel.Data} ";
                shovel = shovel.Next;
            }
            return str;
        }

        private void InitHeadAndTail()
        {
            _head = new Node<T>();
            _tail = new Node<T>();
        }

        public int GetLength()
        {
            int length = 0;

            Node<T> shovel = _head;
            while (shovel != null)
            {
                length += 1;
                shovel = shovel.Next;
            }

            return length;
        }

        public T[] ToArray()
        {
            int length = GetLength();
            if (length == 0) return new T[] { };

            T[] array = new T[length];
            Node<T> shovel = _head;
            for (int i = 0; i < length; i++)
            {
                array[i] = shovel.Data;
                shovel = shovel.Next;
            }

            return array;
        }

        public void AddFirst(T val)
        {
            Node<T> newNode = new Node<T>(val);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head = newNode;
            }
        }

        public void AddFirst(LinkedList<T> list)
        {
            if (list is LinkedList<T>)
            {
                list._tail.Next = _head;
                _head = list._head;
                if (_tail == null) _tail = list._tail;
            }
            else return;
        }

        public void AddLast(T val)
        {
            Node<T> newNode = new Node<T>(val);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
        }

        public void AddLast(LinkedList<T> list)
        {
            if (_head == null)
            {
                _head = list._head;
                _tail = list._tail;
            }
            else
            {
                _tail.Next = list._head;
                _tail = list._tail;
            }
        }


        public void AddAt(int idx, T val)
        {
            if (idx == 0)
            {
                AddFirst(val);
                return;
            }

            Node<T> previous = GetNode(idx - 1);
            if (previous == _tail)
            {
                AddLast(val);
            }
            else
            {
                Node<T> newNode = new Node<T>(val);
                newNode.Next = previous.Next;
                previous.Next = newNode;
            }
        }

        public void AddAt(int idx, LinkedList<T> list)
        {
            if (idx == 0)
            {
                AddFirst(list);
                return;
            }

            Node<T> previous = GetNode(idx - 1);
            if (previous == _tail)
            {
                AddLast(list);
            }
            else
            {
                list._tail.Next = previous.Next;
                previous.Next = list._head;
            }
        }

        public void Set(int idx, T val)
        {
            Node<T> changing = GetNode(idx);
            changing.Data = val;
        }

        public void RemoveFirst()
        {
            if (_head == null) return;
            if (_head.Equals(_tail))
            {
                _head = null;
                _tail = null;
                return;
            }
            _head = _head.Next;
        }


        public void RemoveLast()
        {
            if (_head == null) return;
            if (_head.Equals(_tail))
            {
                _head = null;
                _tail = null;
                return;
            }
            //here in doubly make it simple
            Node<T> shovel = _head;
            while (shovel.Next.Next != null)
            {
                shovel = shovel.Next;
            }
            _tail = shovel;
            shovel.Next = null;
        }

        public void RemoveAt(int idx)
        {
            if (idx == 0)
            {
                RemoveFirst();
                return;
            }

            Node<T> removablePrev = GetNode(idx - 1);
            if (removablePrev == _tail) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (removablePrev.Next == _tail)
            {
                RemoveLast();
                return;
            }

            removablePrev.Next = removablePrev.Next.Next;
        }

        public void RemoveFirstMultiple(int n)
        {
            if (n < 0) throw new ArgumentException("Wrong amount: it must be positive!");
            int counterOfdeletedElementsAmount = 0;
            while (_head != null && counterOfdeletedElementsAmount < n)
            {
                _head = _head.Next;
                counterOfdeletedElementsAmount += 1;
            }
            if (_head == null)
            {
                _tail = null;
                //deleted all elements
            }
        }

        public void RemoveLastMultiple(int n)
        {
            if (n < 0) throw new ArgumentException("Wrong amount: it must be positive!");

            int length = GetLength();
            int index = length - n - 1;
            if (index < 0) _head = null;
            else
            {
                Node<T> lasEl = GetNode(index, length);
                lasEl.Next = null;
                _tail = lasEl;
            }
        }

        public void RemoveAtMultiple(int idx, int n)
        {
            if (n < 0) throw new ArgumentException("Wrong amount: amount must be positive!");
            if (idx == 0)
            {
                RemoveFirstMultiple(n);
                return;
            }

            int counterOfdeletedElementsAmount = 0;
            Node<T> shovel = GetNode(idx - 1);
            Node<T> copyForTail = shovel;

            while (shovel.Next != null && counterOfdeletedElementsAmount < n)
            {
                shovel.Next = shovel.Next.Next;
                counterOfdeletedElementsAmount += 1;
            }
            if (shovel == null)
            {
                //Deleted all idx to tail
                _tail = copyForTail;
            }
            else if (shovel.Next == null)
            {
                _tail = shovel;
            }
        }

        public int RemoveFirst(T val)
        {
            Node<T> shovel = _head;
            int idx = 0;

            while (shovel != null)
            {
                if (shovel.Data.Equals(val))
                {
                    RemoveAt(idx);
                    return idx;
                }
                idx += 1;
                shovel = shovel.Next;
            }
            return -1;
        }


        public int RemoveAll(T val)
        {
            Node<T> shovel = _head;
            int idx = 0;
            int counter = 0;
            Node<T> removablePrev = null;
            while (shovel != null)
            {
                if (shovel.Data.Equals(val))
                {
                    if (removablePrev == null)
                    {
                        RemoveFirst();
                    }

                    else if (shovel == _tail)
                    {
                        RemoveLast();
                    }
                    else removablePrev.Next = removablePrev.Next.Next;

                    counter += 1;
                }
                idx += 1;
                removablePrev = shovel;
                shovel = shovel.Next;
            }
            return counter;
        }

        public bool Contains(T val)
        {
            Node<T> shovel = _head;
            int idx = 0;
            while (shovel != null)
            {
                if (shovel.Data.Equals(val))
                {
                    return true;
                }
                idx += 1;
                shovel = shovel.Next;
            }
            return false;
        }

        public int IndexOf(T val)
        {
            Node<T> shovel = _head;
            int idx = 0;

            while (shovel != null)
            {
                if (shovel.Data.Equals(val))
                {
                    return idx;
                }
                idx += 1;
                shovel = shovel.Next;
            }
            return -1;
        }

        public T GetFirst()
        {
            if (_head == null) throw new IndexOutOfRangeException("Your list is empty!");
            return _head.Data;
        }

        public T GetLast()
        {
            if (_head == null) throw new IndexOutOfRangeException("Your list is empty!");
            return _tail.Data;
        }

        public Node<T> GetFirstNode()
        {
            return _head;
        }

        public Node<T> GetLastNode()
        {
            return _tail;
        }

        public Node<T> GetNextNode(Node<T> node)
        {
            return node.Next;
        }

        private Node<T> GetNode(int idx, int length)
        {
            if (idx >= length) throw new ArgumentException("Wrong position: we don't have such amount of elements!");
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");

            Node<T> shovel = _head;
            int idxReal = 0;

            while (idxReal < idx)
            {
                shovel = shovel.Next;
                idxReal += 1;
            }

            return shovel;
        }

        private Node<T> GetNode(int idx)
        {
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            int length = GetLength();
            if (idx >= length) throw new ArgumentException("Wrong position: we don't have such amount of elements!");

            Node<T> shovel = _head;
            int idxReal = 0;

            while (idxReal < idx)
            {
                shovel = shovel.Next;
                idxReal += 1;
            }

            return shovel;
        }

        public T Get(int idx)
        {
            if (idx < 0) throw new ArgumentException("Wrong position: index must be positive!");
            int length = GetLength();
            if (idx >= length) throw new ArgumentException("Wrong position: we don't have such amount of elements!");

            Node<T> shovel = _head;
            int idxReal = 0;

            while (idxReal < idx)
            {
                shovel = shovel.Next;
                idxReal += 1;
            }

            return shovel.Data;
        }

        public void Reverse()
        {
            RecursiveReverse(ref _head);
        }

        private void RecursiveReverse(ref Node<T> node)
        {
            if (node == null || node.Next == null) return;

            Node<T> left;
            Node<T> next;

            left = node;
            next = left.Next;

            RecursiveReverse(ref next);

            left.Next.Next = left;
            left.Next = null;
            node = next;
        }

        public void Free()
        {
            _head = null;
            _tail = null;
        }
    }
}
