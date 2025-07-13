namespace ShopEF.Database.Repositories.Interfaces;

internal interface IUnitOfWork : IDisposable
{
    public void Save();

    public void BeginTransaction();

    public void RollbackTransaction();
}
