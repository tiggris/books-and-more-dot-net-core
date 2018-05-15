using System.Collections.Generic;

namespace BooksAndMore.Catalogue.Application.Queries.TopBooksQuery
{
    public class TopBooksList
    {
        public IEnumerable<TopBooksListItem> Books { get; set; }
        public int BooksCount { get; set; }
    }
}
