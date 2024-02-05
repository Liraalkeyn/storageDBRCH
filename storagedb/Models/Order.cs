using System;
using System.Collections.Generic;

namespace storagedb.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string NameOfOrder { get; set; } = null!;

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
