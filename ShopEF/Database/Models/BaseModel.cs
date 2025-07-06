namespace ShopEF.Database.Models;

public class BaseModel
{
    public int Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public bool IsDeleted { get; set; }
}