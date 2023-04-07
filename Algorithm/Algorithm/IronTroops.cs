using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    // 강철부대의 각 부대원이 여러 지역에 뿔뿔이 흩어져 특수 임무를 수행 중입니다.
    // 지도에서 강철부대가 위치한 지역을 포함한 각 지역은 유일한 번호로 구분되며,
    // 두 지역 간의 길을 통과하는 데 걸리는 시간은 모두 1로 동일합니다.
    // 임무를 수행한 각 부대원은 지도 정보를 이용하여 최단시간에 부대로 복귀하고자 합니다.
    // 다만 적군의 방해로 인해, 임무의 시작 때와 다르게 되돌아오는 경로가 없어져 복귀가 불가능한 부대원도 있을 수 있습니다.
    //
    //강철부대가 위치한 지역을 포함한 총지역의 수 n,
    //두 지역을 왕복할 수 있는 길 정보를 담은 2차원 정수 배열 roads,
    //각 부대원이 위치한 서로 다른 지역들을 나타내는 정수 배열 sources,
    //강철부대의 지역 destination이 주어졌을 때, 주어진 sources의 원소 순서대로 강철부대로
    //복귀할 수 있는 최단시간을 담은 배열을 return하는 solution 함수를 완성해주세요.
    //복귀가 불가능한 경우 해당 부대원의 최단시간은 -1입니다.

    public class IronTroops
    {

        // static void Main( string[] args )
        // {
        //     var roads = new int[,]
        //     {
        //         { 1, 2 },
        //         { 2, 3 },
        //     };
        //
        //     var sources = new int[] { 2, 3 };
        //     int destination = 1;
        //     int n = 3;
        //
        //     var res = solution( n, roads, sources, destination);
        //     for( int i = 0; i < res.Length; i++ )
        //     {
        //         Console.WriteLine( res[i] );
        //     }
        // }
        //
        // static void Main( string[] args )
        // {
        //     var roads = new int[,]
        //     {
        //         { 1, 2 },
        //         { 1, 4 },
        //         { 2, 4 },
        //         { 2, 5 },
        //         { 4, 5 },
        //     };
        //
        //     var sources = new int[] { 1, 3, 5 };
        //     int destination = 5;
        //     int n = 5;
        //
        //     var res = solution( n, roads, sources, destination);
        //     for( int i = 0; i < res.Length; i++ )
        //     {
        //         Console.WriteLine( res[i] );
        //     }
        // }

        static int[] solution(int n, int[,] roads, int[] sources, int destination)
        {
            int[] answer = new int[sources.Length];
            Dictionary<int, List<int>> adjs = new Dictionary<int, List<int>>();

            for (int i = 1; i <= n; i++) {
                adjs[i] = new List<int>();
            }

            for( int i = 0; i < roads.GetLength( 0 ); i++ ) {
                int u = roads[i, 0];
                int v = roads[i, 1];
                adjs[u].Add(v);
                adjs[v].Add(u);
            }

            for( int i = 0; i < sources.Length; i++ ) {
                int start = sources[i];
                answer[i] = ShortestDistanceBFS( n, adjs, start, destination );
            }
            return answer;
        }

        static int ShortestDistanceBFS(int n , Dictionary<int, List<int>> adjs, int start, int end)
        {
            if( start == end )
                return 0;

            bool[] visited = new bool[n + 1];
            int[] distance = new int[n + 1];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;
            distance[start] = 0;

            while (queue.Count > 0)
            {
                int cur = queue.Dequeue();

                foreach (int adjVertex in adjs[cur])
                {
                    if (!visited[adjVertex])
                    {
                        visited[adjVertex] = true;
                        distance[adjVertex] = distance[cur] + 1;
                        queue.Enqueue(adjVertex);

                        if (adjVertex == end) {
                            return distance[adjVertex];
                        }
                    }
                }
            }
            return -1;
        }
    }
}