
using LinkedListClass;
using System;
using System.Collections;

namespace GraphLogic
{
    public class Graph
    {
        private LinkedList<Edge> _graph;
        
        public Graph()
        {
            _graph = new LinkedList<Edge>();
        }

        public Graph(Edge val)
        {
            _graph = new LinkedList<Edge>(val);
        }

        public Graph(Edge[] val)
        {
            _graph = new LinkedList<Edge>(val);
        }

        public int GetLength() => _graph.GetLength();
        public bool Contains(Edge edge) => _graph.Contains(edge);


        public override string ToString()
        {
            Edge[] graph = _graph.ToArray();
            string result = string.Empty;

            for (int i = 0; i < graph.Length; i++)
            {
                result += $"{graph[i].VertexA} {graph[i].VertexB} {graph[i].EdgeWeight}\n";
            }

            return result;
        }

        public void RemoveAt(int idx)
        {
            try
            {
                _graph.RemoveAt(idx);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
        
        public void Sort()
        {
            Edge[] graph = _graph.ToArray();
            MergeSort.Sort(graph);
            _graph = new LinkedList<Edge>(graph);
        }
    }
}
