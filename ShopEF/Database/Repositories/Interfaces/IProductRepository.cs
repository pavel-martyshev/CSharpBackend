using ShopEF.Database.Models;
using ShopEF.Dto;

namespace ShopEF.Database.Repositories.Interfaces;

internal interface IProductRepository : IRepository<Product>
{
    public TopProductDto? GetTopProduct();
}
