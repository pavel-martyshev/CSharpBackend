namespace ShopEF.Database.Model;

public class CategoryProduct
{
    public int CategoryId { get; set; }

    public int ProductId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}