
using ArrayListClass;
using LinkedListClass;

namespace GraphLogic
{
    public class KraskalsAlgorithm
    {
        public ArrayList<Set> Sets;
        private Graph _innerGraph;
        private Graph _resultGraph;

        public Graph FindMinimumBackbone()
        {
            _innerGraph.Sort();

            _innerGraph.ToSets(this);
            
            return _resultGraph;
        }

        

        public Set Contains(string vertex)
        {
            for (int i = 0; i < Sets.GetLength(); i++)
            {
                if (Sets.Get(i).Vertex == vertex) return Sets.Get(i);
            }
            return null;
        }
    }
}
