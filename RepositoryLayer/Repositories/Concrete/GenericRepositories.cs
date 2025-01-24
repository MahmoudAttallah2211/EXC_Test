using CoreLayer.BaseEntities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.context;
using RepositoryLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Concrete
{
    public class GenericRepositories<T> : IGenericRepositories<T> where T : class, IBaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepositories(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddEntityAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAllListAsync()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> Predicate)
        {
            return _context.Set<T>().Where(Predicate).ToList();
        }

        public async Task<T> GetEntityByIDAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }

    //public async Task AddEntityAsync(T entity)
    //{
    //    await _context.Set<T>().AddAsync(entity);
    //    await _context.SaveChangesAsync();
    //}

    //public void UpdateEntity(T entity)
    //{
    //    _context.Set<T>().Update(entity);
    //    _context.SaveChanges();
    //}

    //public void DeleteEntity(T entity)
    //{
    //    _context.Set<T>().Remove(entity);
    //    _context.SaveChanges();
    //}

    //public IQueryable<T> GetAllEntityList()
    //{
    //    return _context.Set<T>();
    //}

    //public IEnumerable<T> Where(Expression<Func<T, bool>> Predicate)
    //{
    //    return _context.Set<T>().Where(Predicate).ToList();
    //}

    //public async Task<T> GetEntityByIDAsync(int id)
    //{
    //    return await _context.Set<T>().FindAsync(id);
    //}

    //IQueryable<T> IGenericRepositories<T>.GetAllListAsync()
    //{
    //    throw new NotImplementedException();
    //}

    //T IGenericRepositories<T>.GetById(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //IEnumerable<T> IGenericRepositories<T>.GetAll()
    //{
    //    throw new NotImplementedException();
    //}


    //public async Task AddEntityAsync(T entity)
    //{
    //    await _dbSet.AddAsync(entity);
    //    await _context.SaveChangesAsync();
    //}

    //public async Task UpdateEntityAsync(T entity)
    //{
    //    _dbSet.Update(entity);
    //    await _context.SaveChangesAsync();
    //}

    //public async Task DeleteEntityAsync(T entity)
    //{
    //    _dbSet.Remove(entity);
    //    await _context.SaveChangesAsync();
    //}

    //public async Task<List<T>> GetAllEntityListAsync()
    //{
    //    return await _dbSet.AsNoTracking().ToListAsync();
    //}

    //public IEnumerable<T> FindEntities(Expression<Func<T, bool>> predicate)
    //{
    //    return _dbSet.Where(predicate).ToList();
    //}

    //public async Task<T> GetEntityByIDAsync(int id)
    //{
    //    var entity = await _dbSet.FindAsync(id);
    //    if (entity == null)
    //    {
    //        throw new KeyNotFoundException($"Entity with ID {id} not found.");
    //    }
    //    return entity;
    //}

    //public void UpdateEntity(T entity)
    //{
    //    throw new NotImplementedException();
    //}

    //public void DeleteEntity(T entity)
    //{
    //    throw new NotImplementedException();
    //}

    //public IQueryable<T> GetAllEntityList()
    //{
    //    throw new NotImplementedException();
    //}

    //public IEnumerable<T> Where(Expression<Func<T, bool>> Predicate)
    //{
    //    throw new NotImplementedException();
    //}

    //public void Add(T entity)
    //{
    //    throw new NotImplementedException();
    //}

    //public void Remove(T entity)
    //{
    //    throw new NotImplementedException();
    //}

    //public T GetById(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //public IEnumerable<T> GetAll()
    //{
    //    throw new NotImplementedException();
    //}

    //IQueryable<T> IGenericRepositories<T>.GetAllListAsync()
    //{
    //    throw new NotImplementedException();
    //}

    //object IGenericRepositories<T>.GetAllListAsync()
    //{
    //    throw new NotImplementedException();
    //}

    //public void UpdateEntity(T entity)
    //{
    //    throw new NotImplementedException();
    //}

    //public void DeleteEntity(T entity)
    //{
    //    throw new NotImplementedException();
    //}

    //public IQueryable<T> GetAllEntityList()
    //{
    //    throw new NotImplementedException();
    //}

    //public IEnumerable<T> where(Expression<Func<T, bool>> Predicate)
    //{
    //    throw new NotImplementedException();
    //}
}

