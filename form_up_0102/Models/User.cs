using System;
using System.Collections.Generic;

namespace form_up_0102.Models;

public partial class User
{
    public int Id { get; set; }

    public int IdRole { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public virtual Role Roles { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
