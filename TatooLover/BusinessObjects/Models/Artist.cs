using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Artist
{
    public int ArtistId { get; set; }

    public int StudioId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Avatar { get; set; }

    public string? Certificate { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<ArtistDetail> ArtistDetails { get; set; } = new List<ArtistDetail>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Studio Studio { get; set; } = null!;
}
