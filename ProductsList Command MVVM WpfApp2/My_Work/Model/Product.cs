using System;
using System.Collections.Generic;

namespace ProductsList_Command_MVVM_WpfApp2.My_Work.Model;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Idcategory { get; set; }

    public int Idmanufactorer { get; set; }

    public decimal Price { get; set; }

    public int Iddiscount { get; set; }

    public virtual Category IdcategoryNavigation { get; set; } = null!;

    public virtual Discount IddiscountNavigation { get; set; } = null!;

    public virtual Manufactorer IdmanufactorerNavigation { get; set; } = null!;
}
