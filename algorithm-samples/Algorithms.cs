using System;

namespace AlgorithmsSamplesh1
{
    
    class Algorithms
    {
        
        static void Main(string[] args)
        {
            int n, m;
            List<int>[] graph;
            bool[] used;

            List<int> GetPath(int[] from, int finish)
            {
                List<int> path = new List<int>();
                for (int i = finish; i != -1; i = from[i])
                {
                    path.Add(i);
                }

                path.Reverse();
                
                return path;
            }
            (int[], int[]) bfs(int start = 0)
            {
                Queue<int> q = new Queue<int>();
                int[] dist = new int[n];
                int[] from = new int[n];
                
                Array.Fill(from, -1);
                Array.Fill(dist, int.MaxValue);
                
                dist[start] = 0;
                q.Enqueue(start);
                while (q.Count > 0)
                {
                    int v = q.Dequeue();
                    foreach (int to in graph[v])
                    {
                        if (dist[to] > dist[v] + 1)
                        {
                            q.Enqueue(to);
                            from[to] = v;
                            dist[to] = dist[v] + 1;
                        }
                    }
                }

                return (dist, from);
            }

            void dfs(int v)
            {
                used[v] = true;
                foreach (int u in graph[v])
                {
                    if (!used[u])
                    {
                        dfs(u);
                    }
                }
            }
            
            StreamReader reader = new StreamReader("input.txt");
            Console.SetIn(reader);
                
            using StreamWriter writer = new StreamWriter("../../../output.txt");
            Console.SetOut(writer);
                
            n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());

            
            used = new bool[n];
            graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < m; i++)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int a = int.Parse(parts[0]);
                int b = int.Parse(parts[1]);

                graph[a].Add(b);
                graph[b].Add(a);
            }
            
            int startNode = int.Parse(Console.ReadLine());
            
            var (distance, parents) = bfs(startNode);
            List<int> myPath = GetPath(parents, 4);

            foreach (var node in distance)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
            foreach (var node in myPath)
            {
                Console.Write(node + " ");
            }
            

        }
    }
}