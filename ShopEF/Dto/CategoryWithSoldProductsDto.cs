namespace ShopEF.Dto;

internal class CategoryWithSoldProductsDto
{
    public string Name { get; set; } = null!;

    public int SoldProductsCount { get; set; }
}
