using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class FarestNode
    {
        public static int FarthestNodes(int n, int[,] vertexes) {
            Dictionary<int, List<int>> adjs = new Dictionary<int, List<int>>();

            //Make Edges
            for (int i = 1; i <= n; i++) {
                adjs[i] = new List<int>();
            }
            for (int i = 0; i < vertexes.GetLength(0); i++) {
                int u = vertexes[i, 0];
                int v = vertexes[i, 1];
                adjs[u].Add(v);
                adjs[v].Add(u);
            }

            //BFS
            int[] distances = new int[n + 1];
            bool[] visted = new bool[n + 1];
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            visted[1] = true;
            while (q.Count > 0) {
                int u = q.Dequeue();
                foreach (int v in adjs[u]) {
                    if ( visted[v] == false ){
                        visted[v] = true;
                        q.Enqueue(v);
                        distances[v] = distances[u] + 1;
                    }
                }
            }

            //max, count
            int maxDist = distances.Max();
            return distances.Count(x => x == maxDist);
        }

        static int solution(int n, int[,] edge) {
            return FarthestNodes( n, edge );
        }

        // static void Main( string[] args )
        // {
        //     int n = 6;
        //     int[,] vertexes = new int[,]
        //     {
        //         {3, 6},
        //         {4, 3},
        //         {3, 2},
        //         {1, 3},
        //         {1, 2},
        //         {2, 4},
        //         {5, 2},
        //     };
        //
        //     var res = solution( n, vertexes );
        //     Console.WriteLine( res );
        // }
    }
}