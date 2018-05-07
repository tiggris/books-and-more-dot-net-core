﻿using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Tests
{
    [TestClass]
    public class BooksQueryTests : TestBase
    {
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            _context.EnsureSeedData();
            ReloadContext();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            _context.Books.RemoveRange(_context.Books.ToList());
            _context.SaveChanges();
        }

        [TestMethod]
        public void BooksQuery_Should_ReturnBooks_When_QueryByAuthor()
        {
            // Arrange
            const string author = "Mickiewicz";

            // Act
            var result = _context.Books
                .Where(book => book.BookAuthors.Any(bookAuthor => bookAuthor.Author.FullName.Contains(author)))
                .ToList();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
            Assert.IsTrue(result.All(book => book.BookAuthors.Any(bookAuthor => bookAuthor.Author.FullName == "Adam Mickiewicz")));
        }

        [TestMethod]
        public void BooksQuery_Should_ReturnBooksWithRelatedEntities_When_LazyLoadingEnabled()
        {
            // Act
            var result = _context.Books
                .ToList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            foreach (var book in result)
            {
                Assert.IsNotNull(book);
                Assert.IsNotNull(book.Publisher);
                Assert.IsNotNull(book.Reviews.Any());
                Assert.IsNotNull(book.BookAuthors);
                foreach (var bookAuthor in book.BookAuthors)
                {
                    Assert.IsNotNull(bookAuthor.Author);
                }
            }
        }

        [TestMethod]
        public void BooksQuery_Should_ReturnIllustratedBookWithRelatedEntities_When_EagerLoadRelatedEntities_And_OfTypeSpecified()
        {
            // Act
            var result = _context.Books.OfType<IllustratedBook>()
                .Include(book => book.Publisher)
                .Include(book => book.Reviews)
                .Include(book => book.BookAuthors)
                    .ThenInclude(bookAuthor => bookAuthor.Author)
                .Include(book => book.BookIllustrators)
                    .ThenInclude(bookIllustrator => bookIllustrator.Illustrator)
                .ToList();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            foreach(var book in result)
            {
                Assert.IsNotNull(book);
                Assert.IsNotNull(book.Publisher);
                Assert.IsNotNull(book.Reviews.Any());
                Assert.IsNotNull(book.BookAuthors);
                foreach(var bookAuthor in book.BookAuthors)
                {
                    Assert.IsNotNull(bookAuthor.Author);
                }
                foreach (var bookIllustrator in book.BookIllustrators)
                {
                    Assert.IsNotNull(bookIllustrator.Illustrator);
                }
            }
        }

        [TestMethod]
        public void BooksQuery_Should_ReturnBookWithGeneratedProperty_When_QueriedByTitle()
        {
            // Arrange
            const string title = "Anhelli";

            // Act
            var result = _context.Books
                .Where(book => book.Title == title)
                .SingleOrDefault();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((decimal)2.75, result.AverageRating);
        }

        [Ignore]
        [TestMethod]
        public void RatedBookQuery_Should_ReturnRatedBooks_When_QueryByTitle()
        {
            // Act
            var result = _context.RatedBooks
                .Where(ratedBook => ratedBook.Title == "Anhelli")
                .SingleOrDefault();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((decimal)2.75, result.AverageRating);
        }

        [TestMethod]
        public void BooksQuery_Should_ReturnBookWithReviewsCountCalculatedWithUserDefinedFunction_When_QueriedByTitle()
        {
            // Arrange
            const string title = "Anhelli";

            // Act
            var result = _context.Books
                .Where(book => EF.Functions.Like(book.Title, title))
                .Select(book => new
                {
                    book.Id,
                    ReviewsCount = _context.ReviewsCount(book.Id)
                }).SingleOrDefault();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.ReviewsCount);
        }

        [TestMethod]
        public void BookQuery_Should_ReturnOnlyActiveBooks_When_QueryFiltersNotIgnored()
        {
            // Act
            var result = _context.Books.ToList();

            // Assert
            Assert.IsNotNull(result);
            foreach (var book in result)
            {
                Assert.AreEqual(State.Active, book.State);
            }
        }

        [TestMethod]
        public void BookQuery_Should_ReturnNull_When_QueryFiltersNotIgnored_And_BookIsDeleted()
        {
            // Act
            var result = _context.Books
                .Where(book => book.Title == "Makbet")
                .SingleOrDefault();

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void BookQuery_Should_ReturnBook_When_QueryFiltersIgnored_And_BookIsDeleted()
        {
            // Act
            var result = _context.Books
                .Where(book => book.Title == "Makbet")
                .IgnoreQueryFilters()
                .SingleOrDefault();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(State.Deleted, result.State);
        }

        [TestMethod]
        public void BookQuery_Should_ReturnIllustratedBooks_When_OfTypeSpecified()
        {
            // Act
            var result = _context.Books.OfType<IllustratedBook>().ToList();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void BookQuery_Should_ReturnBookWithAuhorsAndIllustrators_When_AuthorsAndIllustratorsEagerLoaded()
        {
            // Act
            var result = _context.Books
                .Include(book => book.BookAuthors)
                    .ThenInclude(bookAuthor => bookAuthor.Author)
                .Include(book => (book as IllustratedBook).BookIllustrators)
                    .ThenInclude(bookIllustrator => bookIllustrator.Illustrator)
                .Where(book => book.Title == "Mały Książę")
                .SingleOrDefault();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.BookAuthors);
            Assert.IsTrue(result.BookAuthors.Any());
            Assert.AreEqual("Antoine de Saint-Exupéry", result.BookAuthors.First().Author.FullName);
            Assert.IsNotNull((result as IllustratedBook).BookIllustrators);
            Assert.IsTrue((result as IllustratedBook).BookIllustrators.Any());
            Assert.AreEqual("Antoine de Saint-Exupéry", (result as IllustratedBook).BookIllustrators.First().Illustrator.FullName);
        }
    }
}