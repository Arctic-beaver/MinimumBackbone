using LinkedListClass;
using System;

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

        //public void ToSets(KraskalsAlgorithm storage)
        //{
        //    Node<Edge> shovel = _graph.GetFirstNode();
        //    if (shovel == null) return;

        //    shovel = shovel.Next;

        //    while(shovel != null)
        //    {
        //        Set set = storage.Contains(shovel.Data.VertexA);
        //        if (set != null)
        //        {
        //            set.AddChild(shovel.Data.VertexB, shovel.Data.EdgeWeight);
        //        }
        //        else
        //        {
        //            Set setWhereA = null;
        //            Set setWhereB = null;
        //            for (int i = 0; i < storage.Sets.GetLength(); i++)
        //            {
        //                if (storage.Sets.Get(i).Contains(shovel.Data.VertexA))
        //                    setWhereA = storage.Sets.Get(i);
        //                if (storage.Sets.Get(i).Contains(shovel.Data.VertexB))
        //                    setWhereB = storage.Sets.Get(i);
        //            }
        //            if (setWhereA != setWhereB)
        //            {
        //                if ((setWhereA == null) && (setWhereB == null))
        //                {
        //                    Set newSet = new Set(shovel.Data.VertexA, shovel.Data.VertexB, shovel.Data.EdgeWeight);
        //                }
        //                else if ((setWhereA == null) && (setWhereB == null))
        //                {
                            
        //                }
        //            }
        //        } 
                    
        //    }
        //}

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
