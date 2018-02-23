using BooksAndMore.Catalogue.Domain.Model.Authors;
using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Domain.Model.Publishers;
using BooksAndMore.Catalogue.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BooksAndMore.Catalogue.Web.Api.Infrastructure.Data
{
    public static class DbContextExtensions
    {
        public static void EnsureSeedData(this BooksCatalogueContext context)
        {
            if (!context.Authors.Any())
            {
                context.Authors.AddRange(new List<Author>
                {
                    new Author("Adam", "Mickiewicz"),
                    new Author("Juliusz", "Słowacki"),
                    new Author("William", "Shakespeare"),
                    new Author("H.P", "Lovecraft")
                });
            }

            if(!context.Publishers.Any())
            {
                context.Publishers.AddRange(new List<Publisher> {
                    new Publisher("Wydawnictwo Rebis"),
                    new Publisher("Czarna Owca"),
                    new Publisher("Wydawnictwo Znak")
                });
            }

            if(!context.Books.Any())
            {
                var publishers = context.Publishers.Local.ToList();
                var authors = context.Authors.Local.ToList();

                var book = new Book("Pan Tadeusz", "9788388736919", null, publishers[0], new[] { authors[0] });
                book.AddReview(3);
                book.AddReview(3);
                book.AddReview(5);
                book.AddReview(5);
                context.Books.Add(book);

                book = new Book("Dziady", "9788373899285", "Epopeja narodowa", publishers[0], new[] { authors[0] });
                book.AddReview(2);
                book.AddReview(3);
                context.Books.Add(book);

                book = new Book("Sonety Krymskie", "9781500143640", null, publishers[1], new[] { authors[0] });
                book.AddReview(1);
                context.Books.Add(book);

                book = new Book("Konrad Wallenrod", "9781498181334", null, publishers[2], new[] { authors[0] });
                book.AddReview(3);
                book.AddReview(4);
                context.Books.Add(book);

                book = new Book("Balladyna ", "9788377916605", "O zjawach i ambicji", publishers[1], new[] { authors[1] });
                book.AddReview(1);
                book.AddReview(2);
                book.AddReview(2);
                book.AddReview(3);
                book.AddReview(4);
                book.AddReview(3);
                book.AddReview(4);
                book.AddReview(5);
                context.Books.Add(book);

                book = new Book("Anhelli", "9780313208287", null, publishers[0], new[] { authors[1] });
                book.AddReview(1);
                book.AddReview(2);
                book.AddReview(3);
                book.AddReview(5);
                context.Books.Add(book);

                book = new Book("Książka, której nigdy nie było", "9876543210112", null, publishers[2], new[] { authors[0], authors[1] });
                book.AddReview(3);
                book.AddReview(1);
                book.AddReview(4);
                context.Books.Add(book);

                book = new Book("Makbet", "9788496509290", "Krew na rękach", publishers[1], new[] { authors[2] });
                book.AddReview(3);                
                context.Books.Add(book);

                book = new Book("Hamlet", "9781348101864", "Dramat duchów", publishers[1], new[] { authors[2] });
                book.AddReview(4);
                context.Books.Add(book);

                book = new Book("Romeo i Julia", "9781387317844", null, publishers[0], new[] { authors[2] });
                book.AddReview(2);
                book.AddReview(2);
                book.AddReview(1);
                book.AddReview(5);
                context.Books.Add(book);

                book = new Book("Ryszard III", "9789510422311", null, publishers[0], new[] { authors[2] });
                book.AddReview(5);
                book.AddReview(5);
                context.Books.Add(book);

                book = new Book("Wiele hałasu o nic", "9781480297890", null, publishers[2], new[] { authors[2] });
                context.Books.Add(book);
            }

            context.SaveChanges();
        }        
    }
}
