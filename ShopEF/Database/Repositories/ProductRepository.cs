using Microsoft.EntityFrameworkCore;
using ShopEF.Database.Models;
using ShopEF.Database.Repositories.Interfaces;
using ShopEF.Dto;

namespace ShopEF.Database.Repositories;

internal class ProductRepository(DbContext db) : BaseRepository<Product>(db), IProductRepository
{
    public TopProductDto? GetTopProduct()
    {
        return _db.Set<OrderProduct>()
            .GroupBy(op => op.Product.Name)
            .Select(g => new TopProductDto
            {
                Name = g.Key,
                OrdersQuantity = g.Sum(op => op.ProductCount)
            })
            .OrderByDescending(x => x.OrdersQuantity)
            .FirstOrDefault();
    }
}
