using System.Collections.Generic;

namespace BooksAndMore.Catalogue.Application.Queries.BooksSearchQuery
{
    public interface IBooksSearchQuery
    {
        IList<BooksSearchListItem> SearchBooks(string searchTerm);
    }
}
