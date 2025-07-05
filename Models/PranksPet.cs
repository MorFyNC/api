using System;
using System.Collections.Generic;

namespace APIkvalik.Models;

public partial class PranksPet
{
    public int Id { get; set; }

    public int? PetId { get; set; }

    public int? PrankId { get; set; }

    public virtual Pet? Pet { get; set; }

    public virtual Prank? Prank { get; set; }
}
