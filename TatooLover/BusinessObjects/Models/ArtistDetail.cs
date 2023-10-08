using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class ArtistDetail
{
    public int ArtistDetailId { get; set; }

    public int ArtistId { get; set; }

    public int ServiceId { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
