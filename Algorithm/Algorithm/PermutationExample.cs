using System;

namespace ConsoleApp1
{
    //c# 으로 구현해보는 순열
    public class PermutationExample
    {
        /// <summary>
        /// 이런식으로 재귀를 타면 깊이 우선 탐색을 하게된다.
        /// 순열은 재귀에 탈출조건 없어도 더이상 돌곳이 없어서 자동 종료됨.
        /// 순열은 중복 호출되는 경우의 수가 있음. visited 가 필요함.
        /// </summary>
        /// <param name="arr"> 소스 </param>
        /// <param name="depth"> 뎁스 0부터시작하면 전체를돈다. </param>
        /// <param name="n"> 요소의 개수 </param>
        /// <param name="k"> 뽑아서 줄세울 칸의 개수. </param>
        public static void Permutation(int[] arr, int depth, int n, int k) {

            Console.WriteLine($"[Call Perm] depth : {depth} >>");
            foreach( var value in arr ) {
                Console.Write( value );
            }
            Console.WriteLine("");

            // if (depth == k) { // 한번 depth 가 k로 도달하면 사이클이 돌았음. 출력함.
            //     return;
            // }
            for (int i = depth; i < n; i++) {
                ( arr[i], arr[depth] ) = ( arr[depth], arr[i] );
                Permutation(arr, depth + 1, n, k);
                ( arr[i], arr[depth] ) = ( arr[depth], arr[i] );
            }
        }
        //
        // static void Main( string[] args )
        // {
        //     int[] arr = new int[]
        //     {
        //         1, 2, 3, 4,
        //     };
        //     Permutation( arr, 0, arr.Length, arr.Length );
        // }
    }
}