using System;
using System.Collections.Generic;

namespace StudentPortal.Models;

public partial class TblLog
{
    public int LogId { get; set; }

    public int StudentId { get; set; }

    public string? Info { get; set; }

    public virtual Student Student { get; set; } = null!;
}
