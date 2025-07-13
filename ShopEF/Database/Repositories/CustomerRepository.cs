using Microsoft.EntityFrameworkCore;
using ShopEF.Database.Models;
using ShopEF.Database.Repositories.Interfaces;
using ShopEF.Dto;

namespace ShopEF.Database.Repositories;

internal class CustomerRepository(DbContext db) : BaseRepository<Customer>(db), ICustomerRepository
{
    public List<CustomerSpendingDto> GetCustomersSpendings()
    {
        return DbSet
            .Select(c => new CustomerSpendingDto
            {
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                LastName = c.LastName,
                SpendingSum = Math.Round(c.Orders
                    .SelectMany(o => o.OrderProducts)
                    .Sum(op => op.Product.Price * op.ProductsCount), 2, MidpointRounding.AwayFromZero)
            })
            .ToList();
    }
}
