namespace A_star;

public class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public int G { get; set; }
    public int H { get; set; }
    public int F => G + H;
    public Node Parent { get; set; }
    public bool IsWalkable { get; set; } = true;

    public Node(int x, int y)
    {
        X = x;
        Y = y;
    }
}