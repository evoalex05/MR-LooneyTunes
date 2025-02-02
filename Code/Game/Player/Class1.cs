namespace Player;

public class Player
{
    public string Name { get; }
    public int X { get; set; }
    public int Y { get; set; }
    public Player(string name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }
    
}