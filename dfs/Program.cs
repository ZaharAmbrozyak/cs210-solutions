namespace dfs;

class Program
{
    static void Main(string[] args)
    {
        int[] visited;
        List<int>[] graph;
        
        void dfs(int v)
        {
            visited[v] = 1;
            foreach (int to in graph[v])
            {
                if (visited[to] == 0)
                {
                    dfs(to);
                }
            }
        }
    
        StreamReader reader = new StreamReader("input.txt");
        Console.SetIn(reader);

        using StreamWriter writer = new StreamWriter("../../../output.txt");
        Console.SetOut(writer);

        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        visited = new int[n];
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
            a--;
            b--;
            graph[a].Add(b);
            graph[b].Add(a);
        }

        int startNode = int.Parse(Console.ReadLine());
        
        dfs(startNode);
        foreach (int i in visited)
        {
            Console.Write(i + " ");
        }
    }
}