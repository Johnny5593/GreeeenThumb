using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
}

public class Repository<T> : IRepository<T> where T : class
{
    private readonly YourDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(YourDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }
}

public interface IUnitOfWork
{
    void SaveChanges();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly YourDbContext _context;

    public UnitOfWork(YourDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
