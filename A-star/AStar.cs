namespace A_star;

public class AStar
{
    private static int GetHeuristic(Node a, Node b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    public static List<Node> FindPath(Node start, Node target, List<Node> allNodes)
    {
        var openList = new List<Node> { start };
        var closedList = new HashSet<Node>();

        while (openList.Count > 0)
        {
            var current = openList.OrderBy(n => n.F).First();

            if (current == target)
            {
                var path = new List<Node>();
                while (current != null)
                {
                    path.Add(current);
                    current = current.Parent;
                }

                path.Reverse();
                return path;
            }

            openList.Remove(current);
            closedList.Add(current);

            foreach (var neighbor in GetNeighbors(current, allNodes))
            {
                if (!neighbor.IsWalkable || closedList.Contains(neighbor))
                    continue;

                int newMovementCostToNeighbor = current.G + 1;

                if (newMovementCostToNeighbor < neighbor.G || !openList.Contains(neighbor))
                {
                    neighbor.G = newMovementCostToNeighbor;
                    neighbor.H = GetHeuristic(neighbor, target);
                    neighbor.Parent = current;

                    if (!openList.Contains(neighbor))
                    {
                        openList.Add(neighbor);
                    }
                }
            }
        }

        return new List<Node>();
    }

    private static List<Node> GetNeighbors(Node current, List<Node> allNodes)
    {
        return allNodes.Where(n =>
            (Math.Abs(n.X - current.X) == 1 && n.Y == current.Y) ||
            (Math.Abs(n.Y - current.Y) == 1 && n.X == current.X)).ToList();
    }
}