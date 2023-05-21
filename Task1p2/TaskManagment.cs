using Task1p2.Models;

namespace Task1p2;

public sealed class TaskManagment
{
    private static TaskManagment instance = null;
    private static readonly object padlock = new object();

    public List<Role> RolesTopDown { get; set; }
    public List<Employee> Employees { get; set; }
    public List<Case> Cases { get; set; }
    
    TaskManagment()
    {
        Role director = new Role()
        {
            Name = "director"
        };

        Role accountManager = new Role()
        {
            Name = "account manager",
            SubordinateOf = director
        };

        Role backoffice = new Role()
        {
            Name = "backoffice",
            SubordinateOf = accountManager
        };

        RolesTopDown = new List<Role>() { director, accountManager, backoffice };
        Employees = new List<Employee>()
        {
            new Employee()
            {
                Name = "Klaus",
                Roles = new HashSet<Role>() { director },
                MaxCases = 1
            },
            new Employee()
            {
                Name = "Dieter",
                Roles = new HashSet<Role>() { accountManager },
                MaxCases = 2
            },
            new Employee()
            {
                Name = "Fred",
                Roles = new HashSet<Role>() { backoffice },
                MaxCases = 1
            },
            new Employee()
            {
                Name = "Mick",
                Roles = new HashSet<Role>() { backoffice },
                MaxCases = 1
            },
        };

        Cases = new List<Case>()
        {
            new Case()
            {
                Topic = "Topic1",
            },
            new Case()
            {
                Topic = "Topic2",
            },
            new Case()
            {
                Topic = "Topic3",
            },
            new Case()
            {
                Topic = "Topic4",
            },
            new Case()
            {
                Topic = "Topic5",
            },
            new Case()
            {
                Topic = "Topic6",
            },
        };
    }
    
    public override string ToString() {
        return string.Join("\n", Cases.Select(c => $"Case: {c.Topic}, AssignedTo: {(c.AssignedTo != null ? c.AssignedTo.Name + " (" + c.AssignedTo.HighRole.Name + ")" : "")}" ));
    }

    public static TaskManagment Instance
    {
        get
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new TaskManagment();
                    }
                }
            }
            return instance;
        }
    }
}