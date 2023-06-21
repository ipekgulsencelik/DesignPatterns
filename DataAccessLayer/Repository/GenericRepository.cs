using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }
        
        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
        }

        public void MultiUpdate(List<T> entity)
        {
            _context.UpdateRange(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}