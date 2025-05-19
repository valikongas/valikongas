using System.Linq.Expressions;



namespace Db_papildomai
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> Find(Expression <Func<T,bool>> predicate);
        public int Save(T entity);


    }
}
