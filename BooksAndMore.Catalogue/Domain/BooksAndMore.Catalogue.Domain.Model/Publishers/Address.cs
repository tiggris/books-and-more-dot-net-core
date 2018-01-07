namespace BooksAndMore.Catalogue.Domain.Model.Publishers
{
    public class Address
    {
        public string Street { get; private set; }
        public string Building { get; private set; }
        public string Apartment { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
    }
}
