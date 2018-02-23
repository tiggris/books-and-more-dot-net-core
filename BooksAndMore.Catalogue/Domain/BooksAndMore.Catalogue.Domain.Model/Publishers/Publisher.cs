using BooksAndMore.Catalogue.Domain.Common;

namespace BooksAndMore.Catalogue.Domain.Model.Publishers
{
    public class Publisher : IEntity<int>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        private string AddressStreet { get; set; }
        private string AddressBuilding { get; set; }
        private string AddressApartment { get; set; }
        private string AddressCity { get; set; }
        private string AddressZipCode { get; set; }
        private string AddressCountry { get; set; }

        public Address Address
        {
            get
            {
                return new Address(AddressStreet, AddressBuilding, AddressApartment, AddressCity, AddressZipCode, AddressCountry);
            }
            set
            {
                if(value != null)
                {
                    AddressStreet = value.Street;
                    AddressBuilding = value.Building;
                    AddressApartment = value.Apartment;
                    AddressCity = value.City;
                    AddressZipCode = value.ZipCode;
                    AddressCountry = value.Country;
                }
            }
        }

        private Publisher() { }

        public Publisher(string name, Address address = null)
        {
            Name = name;
            Address = address;
        }
    }
}