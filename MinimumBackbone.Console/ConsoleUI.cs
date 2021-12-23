using GraphLogic;
using System;

namespace MinimumBackboneConsole
{
    public class ConsoleUI
    {
        public void EntryPoint()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\..\TestFiles\test.txt");

            Graph graph = new Graph();
            foreach (string line in lines)
            {
                string[] splitted = line.Split();
                Edge edge = new Edge(splitted[0], splitted[1], Int32.Parse(splitted[2]));
                graph.Add(edge);
            }
            Console.WriteLine("Your graph: ");
            Console.WriteLine(graph.ToString());

            KraskalsAlgorithm algorithm = new KraskalsAlgorithm();
            graph = algorithm.FindMinimumBackbone(graph);
            Console.WriteLine("Minimum backbone: ");
            Console.WriteLine(graph.ToString());
        }
    }
}
