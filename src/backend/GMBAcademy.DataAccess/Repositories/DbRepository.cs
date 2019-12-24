using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMBAcademy.DataAccess.Contexts;
using GMBAcademy.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace GMBAcademy.DataAccess.Repositories
{
    public class DbRepository: IDbRepository
    {
        private readonly DbContext _context;

        public DbRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create<T>(T entity) where T : class, IEntity
        {
            await _context.Set<T>().AddAsync(entity);
            return entity.Id;
        }

        public async Task<IEnumerable<Guid>> CreateRange<T>(ICollection<T> entities) where T : class, IEntity
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities.Select(x => x.Id);
        }

        public void Update<T>(T entity) where T : class, IEntity =>
            _context.Update(entity);

        public void UpdateRange<T>(ICollection<T> entities) where T : class, IEntity =>
            _context.UpdateRange(entities);

        public void Delete<T>(T entity) where T : class, IEntity
        {
            var navigationProperties = _context.Model.FindEntityType(typeof(T)).GetNavigations();
            var query = _context.Set<T>().Where(x => x.Id == entity.Id);
            query = navigationProperties.Aggregate(query, (current, navigationProperty) => current.Include(navigationProperty.Name));
            var fullEntity = query.FirstOrDefault();
            _context.Remove(fullEntity ?? throw new ArgumentException());
        }

        public void DeleteRange<T>(ICollection<T> entities) where T : class, IEntity
        {
            var set = _context.Set<T>();
            foreach (var entity in entities)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    set.Attach(entity);
                }
            }

            set.RemoveRange(entities);
        }

        public IQueryable<T> Query<T>() where T : class, IEntity => 
            _context.Set<T>().Where(x => x.IsActive);

        public IQueryable<T> QueryWithInActive<T>() where T : class, IEntity => 
            _context.Set<T>();

        public Task Commit() => _context.SaveChangesAsync();
    }
}
