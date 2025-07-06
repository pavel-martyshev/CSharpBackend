using Microsoft.EntityFrameworkCore;
using ShopEF.Database.Models;
using ShopEF.Database.Repositories.Interfaces;

namespace ShopEF.Database.Repositories;

internal class OrderRepository(DbContext db) : BaseRepository<Order>(db), IOrderRepository
{
}
