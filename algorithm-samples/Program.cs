using System;

namespace AlgorithmsSamplesh1
{
    class Program
    {
        private int n;
        private int[][] e;
        private bool[] used;
        
        public int[] bfs(int l = 0)
        {
            Queue q = new Queue(n);
            int[] dist = new int[n];
            dist[l] = 0;
            q.Push(l);
            while (!q.Empty)
            {
                int v = q.Pop();
                foreach (int u in e[v])
                {
                    if (dist[u] == -1)
                    {
                        q.Push(u);
                        dist[u] = dist[v] + 1;
                    }
                }
            }

            return dist;
        }

        public void dfs(int v)
        {
            used[v] = false;
            foreach (int u in e[v])
            {
                if (!used[u])
                {
                    dfs(u);
                }
            }
        }
        
        static void Main(string[] args)
        {

            
        }
    }
}