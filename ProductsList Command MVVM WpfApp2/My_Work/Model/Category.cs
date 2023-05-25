using System;
using System.Collections.Generic;

namespace ProductsList_Command_MVVM_WpfApp2.My_Work.Model;

public partial class Category
{
    public int Id { get; set; }

    public string Category1 { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
