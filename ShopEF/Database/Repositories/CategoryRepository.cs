using Microsoft.EntityFrameworkCore;
using ShopEF.Database.Models;
using ShopEF.Database.Repositories.Interfaces;
using ShopEF.Dto;

namespace ShopEF.Database.Repositories;

internal class CategoryRepository(DbContext db) : BaseRepository<Category>(db), ICategoryRepository
{
    public List<CategoryWithSoldProductsDto> GetCategoryWithSoldProducts()
    {
        return _dbSet
            .Select(c => new CategoryWithSoldProductsDto
            {
                Name = c.Name,
                SoldProductsCount = c.Products
                    .SelectMany(p => p.OrderProduct)
                    .Sum(x => x.ProductCount)
            })
            .OrderByDescending(x => x.SoldProductsCount)
            .ToList();
    }
}
