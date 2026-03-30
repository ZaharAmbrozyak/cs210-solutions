namespace Kruskal;

class Program
{
    static void Main(string[] args)
    {
        StreamReader reader = new("input.txt");
        using StreamWriter writer = new("../../../output.txt");
        
        Console.SetIn(reader);
        Console.SetOut(writer);

        var n = int.Parse(Console.ReadLine()!);
        var m = int.Parse(Console.ReadLine()!);

        var edges = new List<Edge>();
        
        for (var i = 0; i < m; i++)
        {
            string[] elements = Console.ReadLine()!.Split();
            var weight = int.Parse(elements[0]);
            var from = int.Parse(elements[1]);
            var to = int.Parse(elements[2]);
            
            edges.Add(new Edge(from, to, weight));
        }
        var sortedEdges = edges.OrderBy(e => e.Weight).ToList();
        var minSpanTree = new List<Edge>();
        for (var i = 0; i < edges.Count; i++)
        {
            if (!bfs(i))
                minSpanTree.Add(sortedEdges[i]);
        }

        var span = 0;
        foreach (var edge in minSpanTree)
        {
            span += edge.Weight;
            Console.WriteLine(edge.From + "->" + edge.To);
        }
        Console.WriteLine("Min span = " + span);
        bool bfs(int end)
        {
            var visited = new bool[n];
            var queue = new Queue<int>();
            if (minSpanTree.Count == 0)
                return false;
            var start = minSpanTree[0].From;
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var v = queue.Dequeue();
                visited[v] = true;
                for (var i = 0; i < m; i++)
                {
                    if (!visited[i] && (minSpanTree[i].From == v || minSpanTree[i].To == v))
                    {
                        queue.Enqueue(i);
                    }
                }
            }

            return visited[end];
        }
    }
    
}

class Edge(int from, int to, int weight)
{
    public readonly int From = from;
    public readonly int To = to;
    public readonly int Weight = weight;
}