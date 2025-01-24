using RepositoryLayer.Repositories.Abstract;
using CoreLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        void Commit();

        Task CommitAsync();

        IGenericRepositories<T>GetGenericRepository<T>() where T : class, IBaseEntity;

        ValueTask DisposeASync();
    }
}
