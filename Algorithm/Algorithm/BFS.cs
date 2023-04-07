using System.Collections.Generic;
using System;

namespace ConsoleApp1
{
    public class Graph
    {
        private int _vertexCount;
        private Dictionary<int, List<int>> _adjs = new Dictionary<int, List<int>>();

        public Graph(int vertexCount, int[,] vertices)
        {
            _vertexCount = vertexCount;
            for (int i = 1; i <= _vertexCount; i++) {
                _adjs[i] = new List<int>();
            }

            for( int i = 0; i < vertices.GetLength( 0 ); i++ ) {
                int u = vertices[i, 0];
                int v = vertices[i, 1];
                _AddEdge( u, v );
            }
        }

        void _AddEdge(int src, int dest)
        {
            _adjs[src].Add(dest);
        }

        public int ShortestDistanceBFS(int startVertex, int endVertex)
        {
            if( startVertex == endVertex )
                return 0;

            bool[] visited = new bool[_vertexCount + 1];
            int[] distance = new int[_vertexCount + 1];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startVertex);
            visited[startVertex] = true;
            distance[startVertex] = 0;

            while (queue.Count != 0)
            {
                int cur = queue.Dequeue();

                foreach (int adjVertex in _adjs[cur])
                {
                    if (!visited[adjVertex])
                    {
                        visited[adjVertex] = true;
                        distance[adjVertex] = distance[cur] + 1;
                        queue.Enqueue(adjVertex);

                        if (adjVertex == endVertex) {
                            return distance[adjVertex];
                        }
                    }
                }
            }
            return -1;
        }
    }

    // class Test
    // {
    //     static void Main(string[] args)
    //     {
    //         Graph graph = new Graph(6);
    //         graph.AddEdge(2, 5);
    //         graph.AddEdge(3, 2);
    //         graph.AddEdge(2, 1);
    //         graph.AddEdge(0, 2);
    //         graph.AddEdge(0, 1);
    //         graph.AddEdge(1, 3);
    //         graph.AddEdge(4, 1);
    //
    //         int startVertex = 0;
    //         int[] distances = graph.BFS(startVertex);
    //
    //         Console.WriteLine($"Shortest distances from vertex {startVertex}:");
    //         for (int i = 0; i < distances.Length; i++)
    //         {
    //             Console.WriteLine($"To vertex {i}: {distances[i]}");
    //         }
    //     }
    // }
}