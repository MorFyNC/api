using System;
using System.Collections.Generic;

namespace APIkvalik.Models;

public partial class Pet
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TypeId { get; set; }

    public int Age { get; set; }

    public int BattleRating { get; set; }

    public int? Karma { get; set; }

    public virtual ICollection<Feed> Feeds { get; set; } = new List<Feed>();

    public virtual ICollection<MedKartum> MedKarta { get; set; } = new List<MedKartum>();

    public virtual ICollection<PranksPet> PranksPets { get; set; } = new List<PranksPet>();

    public virtual ICollection<Train> Trains { get; set; } = new List<Train>();

    public virtual Type Type { get; set; } = null!;
}
