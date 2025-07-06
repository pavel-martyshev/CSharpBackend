namespace ShopEF.Dto;

internal class CustomerSpendingDto
{
    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public decimal SpendingSum { get; set; }
}
