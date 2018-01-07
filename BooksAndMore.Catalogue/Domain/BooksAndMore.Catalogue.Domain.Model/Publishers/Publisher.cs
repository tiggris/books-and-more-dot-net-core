using BooksAndMore.Catalogue.Domain.Common;

namespace BooksAndMore.Catalogue.Domain.Model.Publishers
{
    public class Publisher : IEntity<int>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
    }
}
