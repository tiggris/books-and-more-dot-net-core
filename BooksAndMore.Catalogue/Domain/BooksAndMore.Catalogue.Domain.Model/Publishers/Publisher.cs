using BooksAndMore.Catalogue.Domain.Common.Model;

namespace BooksAndMore.Catalogue.Domain.Model.Publishers
{
    public class Publisher : IEntity<int>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }

        private Publisher() { }

        public Publisher(string name, string street = null, string building = null, string apartment = null, string city = null, string zipCode = null, string country = null)
        {
            Name = name;
            SetAddress(street, building, apartment, city, zipCode, country);
        }

        public void SetAddress(string street, string building, string apartment, string city, string zipCode, string country)
        {
            Address = new Address(street, building, apartment, city, zipCode, country);
        }
    }
}