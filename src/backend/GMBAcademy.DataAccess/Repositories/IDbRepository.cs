using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMBAcademy.Domain.Entities.Base;

namespace GMBAcademy.DataAccess.Repositories
{
    public interface IDbRepository
    {
        Task<Guid> Create<T>(T entity) where T : class, IEntity;

        Task<IEnumerable<Guid>> CreateRange<T>(ICollection<T> entities) where T : class, IEntity;

        void Update<T>(T entity) where T : class, IEntity;

        void UpdateRange<T>(ICollection<T> entities) where T : class, IEntity;

        void Delete<T>(T entity) where T : class, IEntity;

        void DeleteRange<T>(ICollection<T> entity) where T : class, IEntity;

        IQueryable<T> Query<T>() where T : class, IEntity;

        IQueryable<T> QueryWithInActive<T>() where T : class, IEntity;

        Task Commit();
    }
}
