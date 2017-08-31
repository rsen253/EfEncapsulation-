using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Linq;

namespace SharedKernel.Data
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

        public IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProrperties)
        {
            return GetAllIncluding(includeProrperties).ToList();
        }

        public IEnumerable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity,object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return query.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> result = _dbset.AsNoTracking().Where(predicate).ToList();
            return result;
        }

        public TEntity FindByKey(int? id)
        {
            //return _dbset.Find(id);

            //We need to inherite IEntity for get the Id property in the SingleOrDefault or default function
            //return _dbset.AsNoTracking().SingleOrDefault(c => c.Id == id);

            var lamda = Utilities.BuildLambdaForFindByKey<TEntity>(id);

            return _dbset.AsNoTracking().SingleOrDefault(lamda);

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

        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = _dbset.AsNoTracking();

            return includeProperties.Aggregate
                (queryable, (current, includePro) => current.Include(includePro));
        }
    }
}

