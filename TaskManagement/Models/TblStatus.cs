﻿using System;
using System.Collections.Generic;

namespace TaskManagement.Models;

public partial class TblStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;
}
