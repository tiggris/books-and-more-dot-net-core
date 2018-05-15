using System.Collections.Generic;

namespace BooksAndMore.Catalogue.Application.Queries.BooksQuery
{
    public interface IBooksQuery
    {
        IList<BooksListItem> GetBooks(int pageIndex, int pageSize);
    }
}
