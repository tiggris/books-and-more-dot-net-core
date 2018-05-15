using System;
using System.Collections.Generic;
using System.Text;

namespace BooksAndMore.Catalogue.Application.Queries.BooksQuery
{
    public class BooksListItem
    {
        public class BookAuthor
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class BookPublisher
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
        }

        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public bool IsIllustrated { get; set; }
        public decimal AverageRating { get; set; }
        public BookPublisher Publisher { get; set; }
        public IList<BookAuthor> Authors { get; set; }
    }
}
