using System;
using System.Collections.Generic;

namespace form_up_0102.Models;

public partial class ProductType
{
    public int Id { get; set; }

    public string ProdType { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
