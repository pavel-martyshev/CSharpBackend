using Microsoft.EntityFrameworkCore;
using ShopEF.Database.Models;
using ShopEF.Database.Repositories.Interfaces;

namespace ShopEF.Database.Repositories;

internal class OrderProductRepository(DbContext db) : BaseRepository<OrderProduct>(db), IOrderProductRepository
{
}
