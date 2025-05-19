

using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq.Expressions;

namespace Db_papildomai
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly GenericDBContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(GenericDBContext dBContext)
        {
            _dbContext = dBContext;
            _dbSet = dBContext.Set<T>();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public int Save(T entity)
        {
            if (entity.Id == null)
            {
                _dbSet.Add(entity);
            }
            else
            {
                _dbSet.Update(entity);
            }
            _dbContext.SaveChanges();
            return entity.Id;
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
