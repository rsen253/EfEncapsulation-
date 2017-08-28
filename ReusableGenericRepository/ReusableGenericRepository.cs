using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ReusableGenericRepository
{

    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DbContext _context;
        internal DbSet<TEntity> _dbset;

        public GenericRepository(DbContext dbContext)
        {
            _context = dbContext;
            _dbset = dbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> All()
        {
            return _dbset.AsNoTracking().ToList();
        }

        public TEntity FindByKey(int? id)
        {
            return _dbset.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = FindByKey(id);
            _dbset.Remove(entity);
        }
    }
}

