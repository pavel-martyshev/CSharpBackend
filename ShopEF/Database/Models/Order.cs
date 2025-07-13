namespace ShopEF.Database.Models;

public class Order : BaseModel
{
    public DateTimeOffset Date { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual List<OrderProduct> OrderProducts { get; set; } = [];
}