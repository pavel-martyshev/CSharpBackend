namespace ShopEF.Database.Model;

public class Customer : BaseModel
{
    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual List<Order> Orders { get; set; } = [];
}