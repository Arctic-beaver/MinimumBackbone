using System;

namespace LinkedListClass
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node()
        {

        }

        public Node(T val)
        {
            Data = val;
        }
    }
}
