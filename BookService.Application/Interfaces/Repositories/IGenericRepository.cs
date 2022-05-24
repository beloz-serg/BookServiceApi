using System.Collections.Generic;

namespace BookService.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TKey id);
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Delete(TKey id);
    }
}
