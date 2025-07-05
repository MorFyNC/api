using System;
using System.Collections.Generic;

namespace APIkvalik.Models;

public partial class MedKartum
{
    public int Id { get; set; }

    public int PetId { get; set; }

    public DateTime Date { get; set; }

    public string? Vaccine { get; set; }

    public string? Disease { get; set; }

    public string? Medicine { get; set; }

    public string? Advice { get; set; }

    public virtual Pet Pet { get; set; } = null!;
}
