namespace ShopEF.Database.Repositories.Interfaces;

internal interface IRepository<T> where T : class
{
    public void Create(T entity);

    public void Update(T entity);

    public void Delete(T entity);

    public T[] GetAll();

    public T? GetById(int id);
}
