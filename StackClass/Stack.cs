using LinkedListClass;
using System;

namespace StackClass
{
    public class Stack<T>
    {
        public LinkedList<T> list = new LinkedList<T>();

        public void Push(T data)
        {
            list.AddLast(data);
        }

        public T Pop()
        {
            T result = list.GetLast();
            list.RemoveLast();
            return result;
        }

        public T Peek()
        {
            return list.GetLast();
        }

        public bool Contains(T data)
        {
            return list.Contains(data);
        }

        public int AmountOfEl()
        {
            return list.GetLength();
        }

        public void Finish()
        {
            list.Free();
        }
    }
}