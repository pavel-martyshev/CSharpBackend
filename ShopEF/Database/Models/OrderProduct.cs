﻿using System.Diagnostics.Contracts;

namespace ShopEF.Database.Models;

public class OrderProduct : BaseModel
{
    public int ProductsCount { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}