using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int BookingId { get; set; }

    public string? Note { get; set; }

    public int Status { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
