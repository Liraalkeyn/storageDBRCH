using System;
using System.Collections.Generic;

namespace storagedb.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string NameOfEmployee { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
