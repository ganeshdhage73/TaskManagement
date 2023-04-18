using System;
using System.Collections.Generic;

namespace TaskManagement.Models;

public partial class TblTaskActivity
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public int Priority { get; set; }

    public int Status { get; set; }

    public int AssignedTo { get; set; }

    public DateTime TaskCreatedOn { get; set; }

    public int EstimatedTime { get; set; }

    public int? ActualTime { get; set; }
}
