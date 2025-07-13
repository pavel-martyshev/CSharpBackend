using Microsoft.EntityFrameworkCore;
using ShopEF.Database.Repositories.Interfaces;

namespace ShopEF.Database.Repositories;

internal class UnitOfWork(DbContext db) : IUnitOfWork
{
    private bool _disposed;

    private readonly DbContext _db = db ?? throw new ArgumentNullException(nameof(db));

    public CategoryRepository CategoryRepository
    {
        get
        {
            ObjectDisposedException.ThrowIf(_disposed, db);
            return new CategoryRepository(db);
        }
    }

    public ProductRepository ProductRepository
    {
        get
        {
            ObjectDisposedException.ThrowIf(_disposed, db);
            return new ProductRepository(db);
        }
    }

    public CustomerRepository CustomerRepository
    {
        get
        {
            ObjectDisposedException.ThrowIf(_disposed, db);
            return new CustomerRepository(db);
        }
    }

    public OrderRepository OrderRepository
    {
        get
        {
            ObjectDisposedException.ThrowIf(_disposed, db);
            return new OrderRepository(db);
        }
    }

    public OrderProductRepository OrderProductRepository
    {
        get
        {
            ObjectDisposedException.ThrowIf(_disposed, db);
            return new OrderProductRepository(db);
        }
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        if (_db.Database.CurrentTransaction != null)
        {
            _db.Database.RollbackTransaction();
        }

        _db.Dispose();
        _disposed = true;
    }

    public void Save()
    {
        ObjectDisposedException.ThrowIf(_disposed, db);

        if (_db.Database.CurrentTransaction != null)
        {
            _db.Database.CommitTransaction();
        }

        _db.SaveChanges();
    }

    public void BeginTransaction()
    {
        ObjectDisposedException.ThrowIf(_disposed, db);
        _db.Database.BeginTransaction();
    }

    public void RollbackTransaction()
    {
        ObjectDisposedException.ThrowIf(_disposed, db);
        _db.Database.RollbackTransaction();
    }
}
