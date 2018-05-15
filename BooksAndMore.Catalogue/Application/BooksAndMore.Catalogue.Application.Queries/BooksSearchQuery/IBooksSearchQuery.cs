using System.Collections.Generic;

namespace BooksAndMore.Catalogue.Application.Queries.BooksSearchQuery
{
    public interface IBooksSearchQuery
    {
        IList<BooksListItem> SearchBooks(string searchTerm);
    }
}
