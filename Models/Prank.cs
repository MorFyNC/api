using System;
using System.Collections.Generic;

namespace APIkvalik.Models;

public partial class Prank
{
    public int Id { get; set; }

    public int? Name { get; set; }

    public virtual ICollection<PranksPet> PranksPets { get; set; } = new List<PranksPet>();
}
