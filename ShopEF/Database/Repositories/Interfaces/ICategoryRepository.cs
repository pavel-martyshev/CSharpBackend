using ShopEF.Database.Models;
using ShopEF.Dto;

namespace ShopEF.Database.Repositories.Interfaces;

internal interface ICategoryRepository : IRepository<Category>
{
    public List<CategoryWithSoldProductsDto> GetCategoriesWithSoldProducts();
}
