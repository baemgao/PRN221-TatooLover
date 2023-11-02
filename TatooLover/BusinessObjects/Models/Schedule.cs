using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Schedule
{
    public int? ScheduleId { get; set; }

    public int? ArtistId { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan TimeFrom { get; set; }

    public TimeSpan TimeTo { get; set; }

    public int? Status { get; set; }

    public virtual Artist? Artist { get; set; } = null!;

}
