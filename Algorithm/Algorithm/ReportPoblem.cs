using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class ReportPoblem
    {
        public static int[] solution(string[] id_list, string[] report, int k) {
            int[] answer = new int[id_list.Length];

            report = report.Distinct().ToArray();

            var reports = new Dictionary<string, List<string>>(); //신고받은자, 신고자들( 수가 곧 횟수 )
            foreach( var key in report )
            {
                string[] splits = key.Split( ' ' );
                var reporter = splits[0];
                var target = splits[1];

                if( reports.TryGetValue( target, out var reporters) == false )
                {
                    reporters = new List<string>();
                    reports.Add( target, reporters );
                }
                reporters.Add( reporter );
            }

            foreach( var reporters in reports.Values )
            {
                if( reporters.Count < k ) {
                    continue;
                }

                foreach( var reporter in reporters ) {
                    var idx = Array.IndexOf( id_list, reporter );
                    answer[idx] += 1;
                }
            }

            return answer;
        }

        // static void Main( string[] args )
        // {
        //     string[] ids = new string[] { "muzi", "frodo", "apeach", "neo" };
        //     string[] reports = new string[] { "muzi frodo", "apeach frodo", "frodo neo", "muzi neo", "apeach muzi" };
        //     int k = 2;
        //     var res = solution( ids, reports, k );
        //     foreach( var r in res ) {
        //         Console.WriteLine( r );
        //     }
        // }
    }
}