//머쓱이는 태어난 지 11개월 된 조카를 돌보고 있습니다.
//조카는 아직 "aya", "ye", "woo", "ma" 네 가지 발음과
//네 가지 발음을 조합해서 만들 수 있는 발음밖에 하지 못하고
//연속해서 같은 발음을 하는 것을 어려워합니다.
//문자열 배열 babbling이 매개변수로 주어질 때,
//머쓱이의 조카가 발음할 수 있는 단어의 개수를 return하도록 solution 함수를 완성해주세요.

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

    public class Babbling
    {
        public static int solution(string[] babbling) {
            int answer = 0;

            var says = new string[] {
                "aya", "ye", "woo", "ma"
            };

            foreach( var word in babbling )
            {
                int saidIndex = -1;
                string result = word;

                for( int i = 0; i < says.Length; i++ )
                {
                    var say = says[i];
                    if( result.StartsWith( say ) ) {
                        if( saidIndex == i ) {
                            break;
                        }
                        result = result.Remove( 0, say.Length );
                        saidIndex = i;
                        i = -1;
                    }
                }

                if( string.IsNullOrEmpty( result ) ) {
                    answer++;
                }
            }
            return answer;
        }

        // static void Main( string[] args )
        // {
        //     var babblings = new string[]
        //     {
        //         "ayaye", "uuu", "yeye", "yemawoo", "ayaayaa",
        //     };
        //
        //     var res = solution( babblings );
        //     Console.WriteLine( res );
        // }
    }
}