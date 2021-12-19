
namespace GraphLogic
{
    public class Edge
    {
        public int EdgeWeight { get; private set; }
        public string VertexA { get; private set; }
        public string VertexB { get; private set; }


        public Edge(string vertexA, string vertexB, int weight )
        {
            VertexA = vertexA;
            VertexB = vertexB;
            EdgeWeight = weight; 
        }


    }
}
