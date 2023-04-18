using System;
using System.Collections.Generic;

namespace TaskManagement.Models;

public partial class TblPriority
{
    public int PriorityId { get; set; }

    public string PriorityName { get; set; } = null!;
}
