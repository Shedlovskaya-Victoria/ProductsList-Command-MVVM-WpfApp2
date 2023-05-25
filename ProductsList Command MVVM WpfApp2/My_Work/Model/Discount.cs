using System;
using System.Collections.Generic;

namespace ProductsList_Command_MVVM_WpfApp2.My_Work.Model;

public partial class Discount
{
    public int Id { get; set; }

    public string Discount1 { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
