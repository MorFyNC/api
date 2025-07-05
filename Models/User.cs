using System;
using System.Collections.Generic;

namespace APIkvalik.Models;

public partial class User
{
    public int Id { get; set; }

    public int? IdRole { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }
}
