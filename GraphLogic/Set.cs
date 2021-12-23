using ArrayListClass;

namespace GraphLogic
{
    public class Set
    {
        public string Vertex { get; set; }

        public ArrayList<string> Children;

        public int Weight { get; set; }

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
