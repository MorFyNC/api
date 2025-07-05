using System;
using System.Collections.Generic;

namespace APIkvalik.Models;

public partial class Train
{
    public int Id { get; set; }

    public int PetId { get; set; }

    public string? Trick { get; set; }

    public DateTime Date { get; set; }

    public virtual Pet Pet { get; set; } = null!;
}
