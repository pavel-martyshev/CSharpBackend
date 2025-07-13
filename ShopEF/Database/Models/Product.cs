namespace ShopEF.Database.Models;

public class Product : BaseModel
{
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual List<Category> Categories { get; set; } = [];

    public virtual List<OrderProduct> OrderProducts { get; set; } = [];
}