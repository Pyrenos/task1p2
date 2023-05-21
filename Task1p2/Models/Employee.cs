namespace Task1p2.Models;

public class Employee
{
    public required string Name { get; set; } = string.Empty;
    public required HashSet<Role> Roles { get; set; } = null;
    public HashSet<Case> Cases { get; set; } = new HashSet<Case>();
    public int MaxCases { get; set; } = 1;

    public Role HighRole
    {
        get
        {
            return TaskManagment.Instance.RolesTopDown.First(r => Roles.Contains(r));
        }
    }
}