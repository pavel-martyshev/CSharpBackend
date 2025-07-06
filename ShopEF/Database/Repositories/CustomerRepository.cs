using Microsoft.EntityFrameworkCore;
using ShopEF.Database.Models;
using ShopEF.Database.Repositories.Interfaces;
using ShopEF.Dto;

namespace ShopEF.Database.Repositories;

internal class CustomerRepository(DbContext db) : BaseRepository<Customer>(db), ICustomerRepository
{
    public List<CustomerSpendingDto> GetCustomersSpending()
    {
        return _dbSet
            .Select(c => new CustomerSpendingDto
            {
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                LastName = c.LastName,
                SpendingSum = c.Orders
                    .SelectMany(o => o.Products)
                    .Sum(p => p.Price)
            })
            .ToList();
    }
}
