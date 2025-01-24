using CoreLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Abstract
{
    public interface IGenericRepositories<T> where T : class, IBaseEntity
    {
        Task AddEntityAsync(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
        IQueryable<T> GetAllListAsync();
        IEnumerable<T> Where(Expression<Func<T, bool>> Predicate);
        Task<T> GetEntityByIDAsync(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
