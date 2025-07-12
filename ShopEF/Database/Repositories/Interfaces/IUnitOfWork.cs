namespace ShopEF.Database.Repositories.Interfaces;

internal interface IUnitOfWork : IDisposable
{
    public CategoryRepository CategoryRepository { get; }

    public ProductRepository ProductRepository { get; }

    public CustomerRepository CustomerRepository { get; }

    public OrderRepository OrderRepository { get; }

    public void Save();

    public void BeginTransaction();

    public void RollbackTransaction();
}
