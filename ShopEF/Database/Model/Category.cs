namespace ShopEF.Database.Model;

public class Category : BaseModel
{
    public string Name { get; set; } = null!;

    public virtual List<Product> Products { get; set; } = [];
}