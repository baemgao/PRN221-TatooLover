using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Studio
{
    public int StudioId { get; set; }

    public string Code { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Phone { get; set; }

    public TimeSpan OpenHour { get; set; }

    public TimeSpan CloseHour { get; set; }

    public bool IsWeekendOff { get; set; }

    public int Status { get; set; }

    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
