using BooksAndMore.Catalogue.Domain.Model.Authors;
using BooksAndMore.Catalogue.Domain.Model.Publishers;
using System.Collections.Generic;
using System.Linq;

namespace BooksAndMore.Catalogue.Domain.Model.Books
{
    public class IllustratedBook : Book
    {
        public virtual ICollection<BookIllustrator> Illustrators { get; private set; }

        private IllustratedBook()
        {
            Illustrators = new HashSet<BookIllustrator>();
        }

        public IllustratedBook(string title, string isbn, string description, Publisher publisher, IList<Author> authors, IList<Illustrator> illustrators) : 
            base(title, isbn, description, publisher, authors)
        {
            Illustrators = GetBookIllustrators(illustrators);
        }

        protected IList<BookIllustrator> GetBookIllustrators(IList<Illustrator> illustrators)
        {
            return illustrators?.Select(author => new BookIllustrator(this, author)).ToList();
        }
    }
}
