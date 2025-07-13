using Microsoft.EntityFrameworkCore;
using ShopEF.Database.Repositories.Interfaces;

namespace ShopEF.Database.Repositories;

internal class BaseRepository<T>(DbContext db) : IRepository<T> where T : class
{
    protected readonly DbContext Db = db ?? throw new ArgumentNullException(nameof(db));

    protected readonly DbSet<T> DbSet = db.Set<T>();

    public void Create(T entity)
    {
        DbSet.Add(entity);
    }

    public void Update(T entity)
    {
        DbSet.Attach(entity);
        Db.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        if (Db.Entry(entity).State == EntityState.Detached)
        {
            DbSet.Attach(entity);
        }

        DbSet.Remove(entity);
    }

    public T[] GetAll()
    {
        return DbSet.ToArray();
    }

    public T? GetById(int id)
    {
        return DbSet.Find(id);
    }

    public virtual void Save()
    {
        Db.SaveChanges();
    }
}
