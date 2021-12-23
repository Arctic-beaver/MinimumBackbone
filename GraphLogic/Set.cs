using ArrayListClass;

namespace GraphLogic
{
    public class Set
    {
        public Graph SetGraph;
        public ArrayList<string> Vertices;

        public Set(Edge edge)
        {
            SetGraph = new Graph(edge);

            Vertices = new ArrayList<string>();        
            Vertices.Add(edge.VertexA);
            Vertices.Add(edge.VertexB);
        }

        public void Union(Set set)
        {
            SetGraph.Add(set.SetGraph);
        }

        public bool Contains(string vertex)
        {
            for (int i = 0; i < Children.GetLength(); i++)
            {
                if (Children.Get(i) == vertex) return true;
            }
            return false;
        }
    }
}
