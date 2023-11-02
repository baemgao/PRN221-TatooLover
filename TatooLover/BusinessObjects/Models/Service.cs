using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public int? StudioId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Time { get; set; }

    public double Price { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<ArtistDetail> ArtistDetails { get; set; } = new List<ArtistDetail>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Studio? Studio { get; set; }
}
