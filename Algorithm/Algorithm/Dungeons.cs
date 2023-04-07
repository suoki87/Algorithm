using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Dungeons
    {
        // public static void Permutation(int k, int[,] duns, int depth, int n, int r,  bool[] vistied, List<int> answers) {
        //     if (depth == r) {
        //         return;
        //     }
        //     for (int i = depth; i < n; i++) {
        //
        //         ( duns[i], duns[depth] ) = ( duns[depth], duns[i] );
        //
        //
        //         Permutation(k, duns, depth + 1, n, r, vistied, answers);
        //
        //         ( duns[i], duns[depth] ) = ( duns[depth], duns[i] );
        //
        //     }
        // }

        private static int DunPerm(int k, int[,] dungeons, bool[] isVisit) {
            int ans = 0;

            for (int i = 0; i < dungeons.GetLength( 0 ); i++) {
                if (k >= dungeons[i,0] && isVisit[i] == false) {
                    isVisit[i] = true;
                    ans = Math.Max( ans, DunPerm(k - dungeons[i,1], dungeons, isVisit));
                    isVisit[i] = false;
                }
            }

            return Math.Max(ans, GetVisitCount(isVisit));
        }

        private static int GetVisitCount( bool[] isVisit )
        {
            int count = 0;
            foreach( var v in isVisit ) {
                if( v ) count++;
            }
            return count;
        }

        public static int solution(int k, int[,] dungeons) {
            int dunCnt = dungeons.GetLength( 0 );
            bool[] visited = new bool[dunCnt];
            return DunPerm( k, dungeons, visited );
        }

        //
        // static void Main( string[] args )
        // {
        //     int k = 80;
        //
        //     int[,] dungeons = new int[,]
        //     {
        //         {80, 20},
        //         {50, 40},
        //         {30, 10},
        //     };
        //
        //     var res = solution( k, dungeons );
        //     Console.WriteLine( res );
        // }
    }

}