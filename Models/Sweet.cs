using System;
using System.Collections.Generic;

namespace APIkvalik.Models;

public partial class Sweet
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Feed> Feeds { get; set; } = new List<Feed>();
}
