using BooksAndMore.Catalogue.Domain.Common.Data;
using BooksAndMore.Catalogue.Domain.Common.Model;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly BooksCatalogueContext _dataContext;

        public Repository(BooksCatalogueContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(TEntity entity)
        {
            _dataContext.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dataContext.Remove(entity);
        }

        public TEntity Find(params object[] keys)
        {
            return _dataContext.Find<TEntity>(keys);
        }
    }
}