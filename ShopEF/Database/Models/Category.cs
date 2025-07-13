namespace ShopEF.Database.Models;

public class Category : BaseModel
{
    public string Name { get; set; } = null!;

    public virtual List<Product> Products { get; set; } = [];
}