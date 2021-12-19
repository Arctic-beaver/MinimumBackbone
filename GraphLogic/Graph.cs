
using LinkedListClass;

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


    }
}
