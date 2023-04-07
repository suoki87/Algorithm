using System;

namespace ConsoleApp1
{
    public class OurPassword
    {
        // static void Main( string[] args )
        // {
        //     var v = solution( "aukks", "wbqd", 5 );
        //     Console.WriteLine( $"값 : {v}" );
        // }

        static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public static int GetNextIndex( int curIndex, int offset )
        {
            return (curIndex + offset) % alphabet.Length;
        }

        public static string solution(string s, string skip, int count) {
            string answer = "";
            foreach( var c in s )
            {
                var cIndex = alphabet.IndexOf( c );
                int index = cIndex;
                int jumpCount = 0;

                while( true )
                {
                    index = GetNextIndex( index, 1 );
                    var nextChar = alphabet[index];
                    if( skip.Contains( nextChar )) {
                        continue;
                    }

                    jumpCount++;
                    if( jumpCount >= count )
                        break;
                }
                answer += alphabet[index];
            }
            return answer;
        }
    }
}