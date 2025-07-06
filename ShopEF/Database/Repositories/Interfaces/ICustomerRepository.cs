using ShopEF.Database.Models;
using ShopEF.Dto;

namespace ShopEF.Database.Repositories.Interfaces;

internal interface ICustomerRepository : IRepository<Customer>
{
    public List<CustomerSpendingDto> GetCustomersSpending();
}
