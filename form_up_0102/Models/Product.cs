using System;
using System.Collections.Generic;

namespace form_up_0102.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Art { get; set; } = null!;

    public int IdType { get; set; }

    public int IdMeasure { get; set; }

    public decimal Price { get; set; }

    public int IdSupplier { get; set; }

    public int IdManufacturer { get; set; }

    public int IdCategory { get; set; }

    public int Discount { get; set; }

    public int CointInStock { get; set; }

    public string Description { get; set; } = null!;

    public string? PhotoUrl { get; set; }

    public virtual Category Categores { get; set; } = null!;

    public virtual Manufacturer Manufacturers { get; set; } = null!;

    public virtual Measure Measures { get; set; } = null!;

    public virtual Supplier Suppliers { get; set; } = null!;

    public virtual ProductType ProductTypes { get; set; } = null!;

    public virtual ICollection<ProductsOrder> ProductsOrders { get; set; } = new List<ProductsOrder>();
}
