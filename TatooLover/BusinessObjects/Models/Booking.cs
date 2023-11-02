using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int CustomerId { get; set; }

    public int ArtistId { get; set; }
    public int ServiceId { get; set; }

    public double Price { get; set; }

    public DateTime BookingDate { get; set; }

    public DateTime BookingDateTime { get; set; }

    public string? Note { get; set; }

    public int? Point { get; set; }

    public string? ArtistFeedBack { get; set; }

    public string? ServiceFeedBack { get; set; }

    public int Status { get; set; } = 0;

    public virtual Artist Artist { get; set; } = null!;

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual Service Service { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
