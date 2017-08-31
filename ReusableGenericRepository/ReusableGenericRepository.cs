using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ReusableGenericRepository
{
    //This repo is not being used 
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

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity,bool>> predicate)
        {
            IEnumerable<TEntity> result = _dbset.AsNoTracking().Where(predicate).ToList();
            return result;
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

