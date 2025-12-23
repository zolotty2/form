using System;
using System.Collections.Generic;

namespace form_up_0102.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public int IdDeliveryPoint { get; set; }

    public int IdUser { get; set; }

    public int Code { get; set; }

    public int IdStatuses { get; set; }

    public virtual DeliveryPoint DeliveryPoints { get; set; } = null!;

    public virtual Status Statuses { get; set; } = null!;

    public virtual User Users { get; set; } = null!;

    public virtual ICollection<ProductsOrder> ProductsOrders { get; set; } = new List<ProductsOrder>();
}
