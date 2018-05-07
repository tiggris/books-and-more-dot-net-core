namespace BooksAndMore.Catalogue.Domain.Model.Authors
{
    public class Illustrator : Author
    {
        protected Illustrator(): base() { }

        public Illustrator(string firstName, string lastName, string bio = null) : 
            base(firstName, lastName, bio)
        {
        }
    }
}
