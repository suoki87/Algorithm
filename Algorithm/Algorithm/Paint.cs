using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Paint
    {
        public static int solution(int n, int m, int[] section) {


            //하나 칠하기를 할 부분(target) 을 꺼냄
            //거기서부터 m 을 더함.
            //다음 칠할 부분을 꺼내는대  (target + m ) 보다 낮으면 계속 넘김
            //다음 꺼냄 또 거기서부터 m 을더함
            //
            int drawPos = 0;
            int drawCount = 0;
            Queue<int> q = new Queue<int>( section );
            while( q.Count > 0 )
            {
                var t = q.Dequeue();
                if( t < drawPos ) {
                    continue;
                }
                drawCount++;
                drawPos = t + m;
            }
            return drawCount;
        }

        // static void Main( string[] args )
        // {
        //     var v = solution( 5, 4, new int[] { 1, 3 } );
        //     Console.WriteLine( $"값 : {v}" );
        // }
    }
}