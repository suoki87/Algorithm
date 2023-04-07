using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static int Min(int a, int b)
        {
            return a > b ? b : a;
        }

        public static int MinPathSum(int[][] grid)
        {
            int row = grid.Length;
            int col = grid[0].Length;

            int[][] arr = new int[row][];
            for( int i = 0; i < row; i++ ) {
                arr[i] = new int[col];
            }
            arr[0][0] = grid[0][0];
            arr[1][0] = grid[1][0] + arr[0][0];
            arr[0][1] = grid[0][1] + arr[0][0];

            for(int y = 0; y < row; y++ ){
                for(int x = 0; x < col; x++)
                {
                    if( x == 0 && y == 0 )
                        continue;
                    if( y == 0 ) {
                        arr[y][x] = grid[y][x] + arr[y][x - 1];
                    }
                    else if( x == 0 ) {
                        arr[y][x] = grid[y][x] + arr[y - 1][x];
                    } else
                    {
                        arr[y][x] = grid[y][x] + Min( arr[y - 1][x], arr[y][x-1] );
                    }
                    Console.WriteLine( arr[y][x] );
                }
                Console.WriteLine();
            }
            return arr[row - 1][col - 1];
        }

        // static void Main( string[] args )
        // {
        //     // var grid = new List<List<int>>();
        //     // grid.Add( new List<int>() { 1,3,1 });
        //     // grid.Add( new List<int>() { 1,5,1 });
        //     // grid.Add( new List<int>() { 4,2,1 });
        //
        //     int[][] grid = new int[3][];
        //     grid[0] = new int[3]{ 1, 3, 1 };
        //     grid[1] = new int[3]{ 1, 5, 1 };
        //     grid[2] = new int[3]{ 4, 2, 1 };
        //
        //     for( int y = 0; y < 3; y++ )
        //     {
        //         for( int x = 0; x  < 3; x++ )
        //         {
        //             Console.Write( $"{x},{y}:{grid[y][x]}" );
        //             Console.Write( $" " );
        //         }
        //         Console.WriteLine();
        //     }
        //
        //     //1 4 5
        //     //2 7 6
        //     //6 8 7
        //
        //     int min = MinPathSum( grid );
        //     Console.WriteLine( $" Answer : {min}" );
        // }
    }
}