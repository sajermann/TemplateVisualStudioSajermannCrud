using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using $ext_rootnamespace$.$safeprojectname$.Interfaces;
using $ext_rootnamespace$.$safeprojectname$.Context;

namespace $ext_rootnamespace$.$safeprojectname$
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    private readonly MyContext _context;
    private DbSet<T> _entities;


    public GenericRepository(MyContext context)
    {
      _context = context;
      _entities = context.Set<T>();
    }

    public async Task<List<T>> Find(
      Expression<Func<T, bool>> where = null,
      List<Expression<Func<T, object>>> includes = null,
      //Expression<Func<object, object>>[] thenIncludes = null,
      Expression<Func<T, T>> selects = null,
      Expression<Func<T, object>> orderByDesc = null,
      Expression<Func<T, object>> orderByAsc = null,
      int pageNumber = 0,
      int itemsPerPage = 0
      )
    {
      List<T> results;
      IQueryable<T> query = _entities.AsNoTracking();
      if (where != null) query = query.Where(where);

      if (includes != null)
      {
        foreach (var item in includes)
          query = query.Include(item);
      }

      if (selects != null) query = query.Select(selects);
      if (orderByDesc != null) query = query.OrderByDescending(orderByDesc);
      if (orderByAsc != null) query = query.OrderBy(orderByAsc);
      if (pageNumber > 0) query = query.Skip((pageNumber - 1) * itemsPerPage);
      if (itemsPerPage > 0) query = query.Take(itemsPerPage);
      results = await query.ToListAsync();
      return results;
    }


    // O update deve se remover manualmente os dados nas tabelas de relacionamentos, o objeto relacionado deve entrar aqui
    // com todas informa��es preenchidas, pois ele ser� atualizado tamb�m e n�o s� o objeto principal
    public async Task<T> AddOrUpdate(T entity)
    {

      if (!_entities.Any(e => e == entity))
      {
        _entities.Attach(entity);
      }
      else
      {
        _context.Update(entity);
      }
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task Delete(T entity)
    {
      _context.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteRange(List<T> entity)
    {
      _context.RemoveRange(entity);
      await _context.SaveChangesAsync();
    }
  }
}