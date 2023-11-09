using System;
using System.Collections.Generic;

namespace csharpAPI.Model;

public partial class Store
{
    public int Id { get; set; }

    public string Loc { get; set; }

    public virtual ICollection<ClientOrder> ClientOrders { get; set; } = new List<ClientOrder>();

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
}
