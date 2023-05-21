namespace Task1p2.Models;

public class Case
{
    public required string Topic { get; set; }

    public Employee? AssignedTo
    {
        get
        {
            return TaskManagment.Instance.Employees.FirstOrDefault(e => e.Cases.Contains(this));
        }
    }

    public bool dispatchCase()
    {
        Employee? assignedTo = AssignedTo;
        Role relevantRole = null;
        if (assignedTo != null)
        {
            relevantRole = TaskManagment.Instance.RolesTopDown.First(r => assignedTo.Roles.Contains(r)).SubordinateOf;
        }
        else
        {
            relevantRole = TaskManagment.Instance.RolesTopDown.Last();
        }
        Employee? relevantEmployee =
            TaskManagment.Instance.Employees
                .FirstOrDefault(e => e.Roles.Contains(relevantRole) && e.Cases.Count < e.MaxCases);
        if (relevantEmployee != null)
        {
            if (assignedTo != null)
            {
                assignedTo.Cases.Remove(this);
            }
            relevantEmployee.Cases.Add(this);
            return true;
        }
        return false;
    }
}