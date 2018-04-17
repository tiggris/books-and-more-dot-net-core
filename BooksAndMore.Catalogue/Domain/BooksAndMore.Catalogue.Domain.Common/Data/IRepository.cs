using BooksAndMore.Catalogue.Domain.Common.Model;

namespace BooksAndMore.Catalogue.Domain.Common.Data
{
    public interface IRepository<TEntity> where TEntity: IEntity
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity Find(params object[] keys);
    }
}