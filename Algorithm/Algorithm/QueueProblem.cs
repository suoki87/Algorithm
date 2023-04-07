using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class QueueProblem
    {
        public static int solution(int[] queue1, int[] queue2) {
            int answer = 0;

            var list = new List<int>();
            list.AddRange( queue1 );
            list.AddRange( queue2 );

            int c1 = queue1.Length;
            int c2 = queue2.Length;

            //두 큐를 한줄로 놓고 포인터 두개로 놓고서 포인터가 이동하는것이 마치 dequeue enqueue 하는것과 동일.

            //while()
            {

                answer++;
            }

            return answer;
        }


        // static void Main( string[] args )
        // {
        //     var d = solution( new int[]{ 3, 3, 3, 3 } , new int[]{3, 3, 21, 3} );
        //     Console.WriteLine( d );
        // }
    }
}


// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// public class Solution {
//
//     public int solution(int[] queue1, int[] queue2) {
//         int answer = 0;
//
//         var q1 = new Queue<int>( queue1 );
//         var q2 = new Queue<int>( queue2 );
//
//         int max = ( q1.Count - 1 ) + ( q1.Count +  q2.Count );
//
//         double s1 = q1.Sum();
//         double s2 = q2.Sum();
//         double total = s1 + s2;
//         if( total % 2 != 0 ) {
//             return - 1;
//         }
//
//         while( s1 != s2 )
//         {
//             int c1 = q1.Count;
//             int c2 = q2.Count;
//
//             if( s1 > s2 ) {
//                 int v1 = q1.Dequeue();
//                 q2.Enqueue( v1 );
//                 s1 -= v1;
//                 s2 += v1;
//             } else {
//                 int v2 = q2.Dequeue();
//                 q1.Enqueue( v2 );
//                 s1 += v2;
//                 s2 -= v2;
//             }
//             answer++;
//             if( answer >= max )
//                 return -1;
//         }
//         return answer;
//     }
// }