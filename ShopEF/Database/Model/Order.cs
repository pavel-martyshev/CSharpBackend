namespace ShopEF.Database.Model;

public class Order : BaseModel
{
    public DateTimeOffset Date { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual List<Product> Products { get; set; } = [];

    public virtual List<OrderProduct> OrderProduct { get; set; } = [];
}