using BooksAndMore.Catalogue.Domain.Common;

namespace BooksAndMore.Catalogue.Domain.Model.Publishers
{
    public class Publisher : IEntity<int>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string AddressStreet { get; private set; }
        public string AddressBuilding { get; private set; }
        public string AddressApartment { get; private set; }
        public string AddressCity { get; private set; }
        public string AddressZipCode { get; private set; }
        public string AddressCountry { get; private set; }
    }
}