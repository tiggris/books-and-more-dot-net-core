using BooksAndMore.Catalogue.Domain.Common.Model;

namespace BooksAndMore.Catalogue.Domain.Model.Publishers
{
    public class Address: ValueObject
    {
        public string Street { get; private set; }
        public string Building { get; private set; }
        public string Apartment { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }

        private Address() { }

        internal Address(string street, string building, string apartment, string city, string zipCode, string country)
        {
            Street = street;
            Building = building;
            Apartment = apartment;
            City = city;
            ZipCode = zipCode;
            Country = country;
        }
    }
}
