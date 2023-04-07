using System;
using System.Collections.Generic;

//BFS / Dijkstra's 문제.
namespace ConsoleApp1
{
    public class MazeProblem
    {
        // static void Main( string[] args )
        // {
        //     var s = new Solution();
        //
        //
        //     //var v = s.solution( new string[] { "SOOOL", "XXXXO", "OOOOO", "OXXXX", "OOOOE" } );
        //     //var v = s.solution( new string[] { "LOOXS","OOOOX","OOOOO","OOOOO","EOOOO" } );
        //     //var v = s.solution( new string[] { "SOOOO","XXXXX","LOOOO","XXXXX","EOOOO" } );
        //     //var v = s.solution( new string[] { "XXXXL", "XOOSX", "XXXXX", "XXXOO", "EXXXX", "XXXXX" } );
        //     var v = s.solution( new string[]
        //     {
        //         "OOOOOL",
        //         "OXOXOO",
        //         "OOSXOX",
        //         "OXXXOX",
        //         "EOOOOX"
        //     } );
        //     Console.WriteLine( $"값 : {v}" );
        // }
    }


    public class Solution
    {
        private int[][] directions = new int[][] {
            new int[] {1, 0}, // up
            new int[] {-1, 0},  // down
            new int[] {0, -1}, // left
            new int[] {0, 1}   // right
        };

        public int solution( string[] maps )
        {
            int height = maps.Length;
            int width = maps[0].Length;

            int startX = -1, startY = -1; // starting position
            int leverX = -1, leverY = -1; // lever position
            int exitX = -1, exitY = -1; // exit position

            // Find the positions of starting point, lever, and exit
            for( int y = 0; y < height; y++ )
            {
                for( int x = 0; x < width; x++ )
                {
                    if( maps[y][x] == 'S' )
                    {
                        startY = y;
                        startX = x;
                    } else if( maps[y][x] == 'L' )
                    {
                        leverX = x;
                        leverY = y;
                    } else if( maps[y][x] == 'E' )
                    {
                        exitX = x;
                        exitY = y;
                    }
                }
            }

            // Create a distance matrix to keep track of the minimum distance from starting point to other points
            int[,] dist = new int[height, width];
            for( int i = 0; i < height; i++ )
            {
                for( int j = 0; j < width; j++ )
                {
                    dist[i, j] = Int32.MaxValue;
                }
            }

            dist[startY, startX] = 0;

            // Use Dijkstra's algorithm to find the shortest path from starting point to lever and from lever to exit


            MinHeap<(int, int)> pq = new MinHeap<(int, int)>();
            pq.Enqueue( ( 0, startY * width + startX ) ); // Enqueue the starting position
            while( pq.Count > 0 )
            {
                ( int distance, int pos ) = pq.Dequeue();
                int y = pos / width;
                int x = pos % width;
                if( distance > dist[y, x] )
                    continue; // Skip if we've already found a shorter path to this point

                foreach( int[] dir in directions )
                {
                    int nX = x + dir[1];
                    int nY = y + dir[0];

                    if( nY < 0 || nY >= height || nX < 0 || nX >= width )
                        continue; // Skip if out of bounds

                    if( maps[nY][nX] == 'X' )
                        continue; // Skip if wall
                    int nd = distance + 1;
                    //if( maps[nx][ny] == 'L' )
                    //    nd++; // If this is the lever, add 1 to distance
                    if( nd < dist[nY, nX] )
                    {
                        dist[nY, nX] = nd;
                        pq.Enqueue( ( nd, nY * width + nX ) );
                    }
                }
            }

            // Check if we can escape the maze and return the minimum time
            int ans = dist[leverY, leverX] + dist[exitY, exitX];
            return ans >= Int32.MaxValue ? -1 : ans;
        }
    }

    public class MinHeap<T> where T : IComparable<T> {
        private List<T> heap = new List<T>();

        public void Enqueue(T item) {
            heap.Add(item);
            int i = heap.Count - 1;
            while (i > 0) {
                int p = (i - 1) / 2;
                if (heap[p].CompareTo(item) <= 0) break;
                heap[i] = heap[p];
                i = p;
            }
            heap[i] = item;
        }

        public T Dequeue() {
            T item = heap[0];
            int n = heap.Count - 1;
            heap[0] = heap[n];
            heap.RemoveAt(n);
            n--;
            int i = 0;
            while (true) {
                int l = 2 * i + 1, r = 2 * i + 2, c = i;
                if (l <= n && heap[l].CompareTo(heap[c]) < 0) c = l;
                if (r <= n && heap[r].CompareTo(heap[c]) < 0) c = r;
                if (c == i) break;
                T tmp = heap[i];
                heap[i] = heap[c];
                heap[c] = tmp;
                i = c;
            }
            return item;
        }

        public T Peek() {
            return heap[0];
        }

        public int Count {
            get { return heap.Count; }
        }

        public bool IsEmpty {
            get { return heap.Count == 0; }
        }
    }

    class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> _heap = new List<T>();
        public void Enqueue(T data)
        {
            // 힙의 맨 끝에 새로운 데이터를 삽입한다.
            _heap.Add(data);

            int now = _heap.Count - 1;
            // 도장깨기를 시작
            while (now >0)
            {
                // 도장깨기를 시도
                int next = (now -1) / 2;
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break; //실패

                // 두 값을 교체한다
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치를 이동한다
                now = next;
            }
        }

        public T Dequeue()
        {
            // 반환할 데이터를 따로 저장
            T ret = _heap[0];

            // 마지막 데이터를 루트로 이동한다
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            // 역으로 내려가는 도장깨기 시작
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;
                // 왼쪽 값이 현재 값보다 크면 왼쪽으로 이동
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;
                // 오른쪽 값이 현재 값(왼쪽 값 포함)보다 크면 오른쪽으로 이동
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                // 왼쪽/오른쪽 모두 현재값보다 작으면 종료
                if (next == now)
                    break;

                // 두 값을 교체한다
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;
                // 검사 위치를 이동한다
                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count;
        }
    }
}