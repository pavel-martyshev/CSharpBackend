﻿namespace ShopEF.Database.Models;

public class OrderProduct
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int ProductCount { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}