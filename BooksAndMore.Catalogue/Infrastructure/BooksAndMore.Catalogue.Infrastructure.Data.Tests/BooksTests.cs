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
        [TestInitialize]
        public void Initialize()
        {
            ReloadContext();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Books.RemoveRange(_context.Books.ToList());
            _context.SaveChanges();
        }

        [TestMethod]
        public void CreateBookTest()
        {
            // Arrange
            var author = new Author("Harlan", "Coben");
            var publisher = new Publisher("Wydawnictwo Znak");
            var book = new Book("Nie mów nikomu", "9785170628032", "Niez³y thriller", publisher, new List<Author> { author });

            // Act
            _context.Add(book);
            _context.SaveChanges();
            ReloadContext();

            // Assert
            var result = _context.Books.Find(book.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(book.Id, result.Id);
        }

        [TestMethod]
        public void UpdateBookTest()
        {
            // Arrange
            const string newTitle = "Nie mów nikomu!";
            var author = new Author("Harlan", "Coben");
            var publisher = new Publisher("Wydawnictwo Znak");
            var book = new Book("Nie mów nikomu", "9785170628032", "Niez³y thriller", publisher, new List<Author> { author });
            _context.Add(book);
            _context.SaveChanges();
            ReloadContext();

            // Act
            book = _context.Books.Find(book.Id);
            book.Update(newTitle, book.Isbn, book.Description);
            _context.SaveChanges();
            ReloadContext();

            // Assert
            var result = _context.Books.Find(book.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(newTitle, result.Title);
        }

        [TestMethod]
        public void UpdateAttachedBookTest()
        {
            // Arrange
            const string newTitle = "Nie mów nikomu!";
            var author = new Author("Harlan", "Coben");
            var publisher = new Publisher("Wydawnictwo Znak");
            var book = new Book("Nie mów nikomu", "9785170628032", "Niez³y thriller", publisher, new List<Author> { author });
            _context.Add(book);
            _context.SaveChanges();
            ReloadContext();

            // Act
            _context.Books.Attach(book);
            book.Update(newTitle, book.Isbn, book.Description);
            _context.SaveChanges();
            ReloadContext();

            // Assert
            var result = _context.Books.Find(book.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(newTitle, result.Title);
        }

        [TestMethod]
        public void DeleteBookTest()
        {
            // Arrange
            var author = new Author("Harlan", "Coben");
            var publisher = new Publisher("Wydawnictwo Znak");
            var book = new Book("Nie mów nikomu", "9785170628032", "Niez³y thriller", publisher, new List<Author> { author });
            _context.Add(book);
            _context.SaveChanges();
            ReloadContext();

            // Act
            _context.Books.Remove(book);
            _context.SaveChanges();
            ReloadContext();

            // Assert
            var result = _context.Books.Find(book.Id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteAttachedBookTest()
        {
            // Arrange
            var author = new Author("Harlan", "Coben");
            var publisher = new Publisher("Wydawnictwo Znak");
            var book = new Book("Nie mów nikomu", "9785170628032", "Niez³y thriller", publisher, new List<Author> { author });
            _context.Add(book);
            _context.SaveChanges();
            ReloadContext();

            // Act
            var bookToRemove = new Book(book.Id, book.Isbn);
            _context.Books.Remove(bookToRemove);
            _context.SaveChanges();
            ReloadContext();

            // Assert
            var result = _context.Books.Find(book.Id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AddReviewsOnCreateTest()
        {
            // Arrange
            var author = new Author("Harlan", "Coben");
            var publisher = new Publisher("Wydawnictwo Znak");
            var book = new Book("Nie mów nikomu", "9785170628032", "Niez³y thriller", publisher, new List<Author> { author });
            book.AddReview(3, "Jakiœ goœæ", "Œrednia ksi¹¿ka");
            book.AddReview(5, "Coben lover", "Œwietna powieœæ!");
            book.AddReview(1, "Krytyk literatury", "Mog³o byæ lepiej");

            // Act
            _context.Add(book);
            _context.SaveChanges();
            ReloadContext();

            // Assert
            var result = _context.Books.Find(book.Id);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Reviews.Any());
            Assert.AreEqual(3, result.Reviews.Count);
            Assert.IsNotNull(result.Reviews.Single(review => review.Rating == 1));
            Assert.IsNotNull(result.Reviews.Single(review => review.Rating == 3));
            Assert.IsNotNull(result.Reviews.Single(review => review.Rating == 5));
        }

        [TestMethod]
        public void AddReviewsTest()
        {
            // Arrange
            var author = new Author("Harlan", "Coben");
            var publisher = new Publisher("Wydawnictwo Znak");
            var book = new Book("Nie mów nikomu", "9785170628032", "Niez³y thriller", publisher, new List<Author> { author });
            _context.Add(book);
            _context.SaveChanges();
            ReloadContext();

            // Act
            book.AddReview(3, "Jakiœ goœæ", "Œrednia ksi¹¿ka");
            book.AddReview(5, "Coben lover", "Œwietna powieœæ!");
            book.AddReview(1, "Krytyk literatury", "Mog³o byæ lepiej");
            _context.Books.Attach(book);
            _context.SaveChanges();
            ReloadContext();

            // Assert
            var result = _context.Books.Find(book.Id);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Reviews.Any());
            Assert.AreEqual(3, result.Reviews.Count);
            Assert.IsNotNull(result.Reviews.Single(review => review.Rating == 1));
            Assert.IsNotNull(result.Reviews.Single(review => review.Rating == 3));
            Assert.IsNotNull(result.Reviews.Single(review => review.Rating == 5));
        }
    }
}
