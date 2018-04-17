using System.Linq;

namespace BooksAndMore.Catalogue.Domain.Common.Data
{
    public interface IQueryProvider
    {
        IQueryable<T> Query<T>() where T: class;
    }
}