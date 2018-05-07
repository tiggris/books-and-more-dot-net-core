using BooksAndMore.Catalogue.Domain.Model.Authors;
using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Domain.Model.Publishers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Tests
{
    [TestClass]
    public class BooksTests : TestBase
    {
        private const string _isbn = "9782266165716";

        [TestCleanup]
        public void Cleanup()
        {
            using (var context = CreateNewContext())
            {
                var book = FindBook(context);
                if(book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
            }
        }

        [TestMethod]
        public void AddBook_Should_AddBookToDatabase()
        {
            // Arrange
            var book = CreateBook();

            // Act
            using (var context = CreateNewContext())
            {
                context.Add(book);
                context.SaveChanges();
            }

            // Assert
            using (var context = CreateNewContext())
            {
                var result = context.Books.Find(book.Id);
                Assert.IsNotNull(result);
                Assert.AreEqual(book.Id, result.Id);
            }
        }

        [TestMethod]
        public void UpdateRetrievedBook_Should_UpdateBookInDatabase()
        {
            // Arrange
            const string newTitle = "Chirurg!";

            using (var context = CreateNewContext())
            {
                var book = CreateBook();
                context.Add(book);
                context.SaveChanges();
            }

            // Act
            using (var context = CreateNewContext())
            {
                var book = FindBook(context);
                book.Update(newTitle, book.Isbn, book.Description);
                context.SaveChanges();
            }

            // Assert
            using (var context = CreateNewContext())
            {
                var result = FindBook(context);
                Assert.IsNotNull(result);
                Assert.AreEqual(newTitle, result.Title);
            }
        }

        [TestMethod]
        public void UpdateAttachedBook_Should_UpdateBookInDatabase()
        {
            // Arrange
            const string newTitle = "Chirurg!";
            var book = CreateBook();

            using (var context = CreateNewContext())
            {
                context.Add(book);
                context.SaveChanges();
            }

            // Act
            using (var context = CreateNewContext())
            {
                context.Books.Attach(book);
                book.Update(newTitle, book.Isbn, book.Description);
                context.SaveChanges();
            }

            // Assert
            using (var context = CreateNewContext())
            {
                var result = FindBook(context);
                Assert.IsNotNull(result);
                Assert.AreEqual(newTitle, result.Title);
            }
        }

        [TestMethod]
        public void UpdateBook_Should_UpdateBookInDatabase()
        {
            // Arrange
            const string newTitle = "Chirurg!";
            var book = CreateBook();

            using (var context = CreateNewContext())
            {
                context.Add(book);
                context.SaveChanges();
            }

            // Act
            using (var context = CreateNewContext())
            {
                book.Update(newTitle, book.Isbn, book.Description);
                context.Books.Update(book);
                context.SaveChanges();
            }

            // Assert
            using (var context = CreateNewContext())
            {
                var result = FindBook(context);
                Assert.IsNotNull(result);
                Assert.AreEqual(newTitle, result.Title);
            }
        }

        [TestMethod]
        public void RemoveBook_Should_DeleteBookInDatabase()
        {
            // Arrange
            var book = CreateBook();

            using (var context = CreateNewContext())
            {
                context.Add(book);
                context.SaveChanges();
            }

            // Act
            using (var context = CreateNewContext())
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }

            // Assert
            using (var context = CreateNewContext())
            {
                var result = FindBook(context);
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void RemoveAttachedBook_Should_DeleteBookInDatabase()
        {
            // Arrange
            var book = CreateBook();

            using (var context = CreateNewContext())
            {
                context.Add(book);
                context.SaveChanges();
            }

            // Act
            using (var context = CreateNewContext())
            {
                var bookToRemove = new Book(book.Id, book.Isbn);
                context.Books.Remove(bookToRemove);
                context.SaveChanges();
            }

            // Assert
            using (var context = CreateNewContext())
            {
                var result = FindBook(context);
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void AddReviewsOnCreatedBook_Should_CreateBookWithReviewsAndAverageRating()
        {
            // Arrange
            var book = CreateBook();
            book.AddReview(3, "Jakiœ goœæ", "Œrednia ksi¹¿ka");
            book.AddReview(5, "Coben lover", "Œwietna powieœæ!");
            book.AddReview(1, "Krytyk literatury", "Mog³o byæ lepiej");

            // Act
            using (var context = CreateNewContext())
            {
                context.Add(book);
                context.SaveChanges();
            }

            // Assert
            using (var context = CreateNewContext())
            {
                var result = FindBook(context);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Reviews.Any());
                Assert.AreEqual(3, result.Reviews.Count);
                Assert.IsNotNull(result.Reviews.Single(review => review.Rating == 1));
                Assert.IsNotNull(result.Reviews.Single(review => review.Rating == 3));
                Assert.IsNotNull(result.Reviews.Single(review => review.Rating == 5));
                Assert.AreEqual(3, result.AverageRating);
            }
        }

        [TestMethod]
        public void AddReviewsOnAttachedBook_Should_CreateReviewsInDatabase()
        {
            // Arrange
            var book = CreateBook();
            using (var context = CreateNewContext())
            {
                context.Add(book);
                context.SaveChanges();
            }

            // Act
            using (var context = CreateNewContext())
            {
                book.AddReview(3, "Jakiœ goœæ", "Œrednia ksi¹¿ka");
                book.AddReview(5, "Coben lover", "Œwietna powieœæ!");
                book.AddReview(1, "Krytyk literatury", "Mog³o byæ lepiej");
                context.Books.Attach(book);
                context.SaveChanges();
            }

            // Assert
            using (var context = CreateNewContext())
            {
                var result = FindBook(context);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Reviews.Any());
                Assert.AreEqual(3, result.Reviews.Count);
                Assert.IsNotNull(result.Reviews.Single(review => review.Rating == 1));
                Assert.IsNotNull(result.Reviews.Single(review => review.Rating == 3));
                Assert.IsNotNull(result.Reviews.Single(review => review.Rating == 5));
            }
        }

        private Book CreateBook()
        {
            var author = new Author("Tess", "Gerritsen");
            var publisher = new Publisher("Wydawnictwo Literackie");
            var book = new Book("Chirurg", _isbn, "Niez³y thriller", publisher, new List<Author> { author });
            return book;
        }

        private Book FindBook(BooksCatalogueContext context)
        {
            return context.Books.SingleOrDefault(book => book.Isbn == _isbn);
        }
    }
}
