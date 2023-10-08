using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class BookingDetail
{
    public int BookingDetailId { get; set; }

    public int BookingId { get; set; }

    public int ServiceId { get; set; }

    public string? Description { get; set; }

    public int Status { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
