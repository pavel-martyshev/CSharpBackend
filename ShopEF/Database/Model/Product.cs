namespace ShopEF.Database.Model;

public class Product : BaseModel
{
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual List<Category> Categories { get; set; } = [];

    public virtual List<CategoryProduct> CategoryProduct { get; set; } = [];

    public virtual List<Order> Orders { get; set; } = [];

    public virtual List<OrderProduct> OrderProduct { get; set; } = [];
}