using System;
using System.Collections.Generic;

namespace APIkvalik.Models;

public partial class Feed
{
    public int Id { get; set; }

    public int PetId { get; set; }

    public int SweetId { get; set; }

    public TimeOnly Time { get; set; }

    public int Count { get; set; }

    public bool IsCompleted { get; set; }

    public virtual Pet Pet { get; set; } = null!;

    public virtual Sweet Sweet { get; set; } = null!;
}
