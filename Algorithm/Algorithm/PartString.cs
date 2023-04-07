using System;

namespace ConsoleApp1
{
    public class PartString
    {

        public static int solution(string t, string p) {
            int answer = 0;

            long valueP = long.Parse( p );
            int lp = p.Length;

            for( int i = 0; i < t.Length - lp + 1; i++ )
            {
                var sub = t.Substring( i, lp );
                long value = long.Parse( sub );
                if( value <= valueP ) {
                    answer++;
                }
            }
            return answer;
        }
        //
        // static void Main( string[] args )
        // {
        //     // string t = "3141592";
        //     // string p = "271";
        //     //
        //     string t = "10203";
        //     string p = "15";
        //
        //     var res = solution( t, p );
        //     Console.WriteLine( res );
        // }
    }
}