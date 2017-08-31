using System;
using System.Linq.Expressions;

namespace SharedKernel.Data
{
    public static class Utilities
    {
        public static Expression<Func<TEntity,bool>> BuildLambdaForFindByKey<TEntity>(int? id)
        {
            //Get the type of the entity
            var item = Expression.Parameter(typeof(TEntity), "entity");
            //Add 'Id' with the key type[Like type Customer so it will return CustomerId] 
            var property = Expression.Property(item, typeof(TEntity).Name + "Id");
            //Getting the value of Id
            var value = Expression.Constant(id);
            //Assign the valueto the newly created property [In case CustomerId == value]
            var equal = Expression.Equal(property, value);
            var lamda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
            return lamda;
        }
    }
}
