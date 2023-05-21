namespace Task1p2.Models;

public class Role
{
    public required string Name { get; set; }
    public Role SubordinateOf { get; set; }
}