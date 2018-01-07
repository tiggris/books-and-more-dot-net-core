using BooksAndMore.Catalogue.Domain.Common;

namespace BooksAndMore.Catalogue.Domain.Model.Books.Reviews
{
    public class Review : IEntity<int>
    {
        public int Id { get; private set; }
        public string ReviewerName { get; private set; }
        public string ReviewText { get; private set; }
    }
}
