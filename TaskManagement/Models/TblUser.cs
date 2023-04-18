using System;
using System.Collections.Generic;

namespace TaskManagement.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;
}
