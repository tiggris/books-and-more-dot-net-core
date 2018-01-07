using BooksAndMore.Catalogue.Domain.Common;

namespace BooksAndMore.Catalogue.Domain.Model.Authors
{
    public class Author : IEntity<int>
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Bio { get; private set; }
    }
}
