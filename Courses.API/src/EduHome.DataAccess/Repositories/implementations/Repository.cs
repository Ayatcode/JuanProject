using EduHome.Core.Interfaces;
using EduHome.DataAccess.Context;
using EduHome.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.DataAccess.Repositories.implementations;

public class Repository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table =>_context.Set<T>();

    public async Task Create(T entity)
    {
        await Table.AddAsync(entity);
    }



    public IQueryable<T> FindAll()
    {
       return  Table.AsQueryable().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return Table.Where(expression).AsNoTracking();
    }

    public T? FindByID(int id)
    {
        return Table.Find(id);
    }



    public void Update(T entity)
    {
        Table.Update(entity);
    }
    public void Delete(T entity)
    {
        Table.Remove(entity);
    }

    public async Task SaveAsync()
    {
        await  _context.SaveChangesAsync();
    }
}
