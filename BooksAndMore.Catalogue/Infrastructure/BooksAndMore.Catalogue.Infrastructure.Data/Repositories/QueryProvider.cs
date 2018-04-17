using System.Linq;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Repositories
{
    public class QueryProvider : Domain.Common.Data.IQueryProvider
    {
        private readonly BooksCatalogueContext _dataContext;

        public QueryProvider(BooksCatalogueContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _dataContext.Set<T>();
        }
    }
}
