using Microsoft.EntityFrameworkCore;
using ShopEF.Database.Repositories.Interfaces;

namespace ShopEF.Database.Repositories;

internal class UnitOfWork(DbContext db) : IUnitOfWork
{
    public CategoryRepository CategoryRepository => new(db);

    public ProductRepository ProductRepository => new(db);

    public CustomerRepository CustomerRepository => new(db);

    public OrderRepository OrderRepository => new(db);

    private readonly DbContext _db = db;

    public void Dispose()
    {
        if (_db.Database.CurrentTransaction != null)
        {
            _db.Database.RollbackTransaction();
        }

        _db.Dispose();
    }

    public void Save()
    {
        if (_db.Database.CurrentTransaction != null)
        {
            _db.Database.CommitTransaction();
        }

        _db.SaveChanges();
    }

    public void InitDb()
    {
        _db.Database.EnsureDeleted();
        _db.Database.Migrate();
    }

    public void BeginTransaction()
    {
        _db.Database.BeginTransaction();
    }

    public void RollbackTransaction()
    {
        _db.Database.RollbackTransaction();
    }
}
