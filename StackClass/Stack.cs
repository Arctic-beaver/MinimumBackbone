using LinkedListClass;
using System;

namespace StackClass
{
    public class Stack<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public void Push(T data)
        {
            _list.AddLast(data);
        }

        public T Pop()
        {
            T result = _list.GetLast();
            _list.RemoveLast();
            return result;
        }

        public T Peek()
        {
            return _list.GetLast();
        }

        public bool Contains(T data)
        {
            return _list.Contains(data);
        }

        public int GetLength()
        {
            return _list.GetLength();
        }

        public void Finish()
        {
            _list.Free();
        }
    }
}