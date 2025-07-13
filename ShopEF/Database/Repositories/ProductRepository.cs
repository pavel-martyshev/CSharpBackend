using Microsoft.EntityFrameworkCore;
using ShopEF.Database.Models;
using ShopEF.Database.Repositories.Interfaces;
using ShopEF.Dto;

namespace ShopEF.Database.Repositories;

internal class ProductRepository(DbContext db) : BaseRepository<Product>(db), IProductRepository
{
    public TopProductDto? GetTopProduct()
    {
        return Db.Set<OrderProduct>()
            .GroupBy(op => op.ProductId)
            .Select(g => new TopProductDto
            {
                Name = g.First().Product.Name,
                OrdersQuantity = g.Sum(op => op.ProductsCount)
            })
            .OrderByDescending(x => x.OrdersQuantity)
            .FirstOrDefault();
    }
}
