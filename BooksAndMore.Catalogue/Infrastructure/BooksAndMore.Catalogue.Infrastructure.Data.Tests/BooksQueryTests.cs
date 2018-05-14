using BooksAndMore.Catalogue.Domain.Model.Books;
using BooksAndMore.Catalogue.Domain.Model.Books.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Tests
{
    [TestClass]
    public class BooksQueryTests : TestBase
    {
        [TestMethod]
        public void BooksQuery_Should_ReturnBooksWithAuthors_When_QueryByAuthor_And_LazyLoadingEnabled()
        {
            using (var context = CreateNewContext(enableLazyLoading: true))
            {
                // Arrange
                const string author = "Mickiewicz";

                // Act
                var result = context.Books
                    .Where(book => book.BookAuthors.Any(bookAuthor => bookAuthor.Author.FullName.Contains(author)))
                    .ToList();

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(5, result.Count());
                Assert.IsTrue(result.All(book => book.BookAuthors.Any(bookAuthor => bookAuthor.Author.FullName == "Adam Mickiewicz")));
            }
        }

        [TestMethod]
        public void BooksQuery_Should_ReturnBooksWithRelatedEntities_When_LazyLoadingEnabled()
        {
            using (var context = CreateNewContext(enableLazyLoading: true))
            {
                // Act
                var result = context.Books.ToList();

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
        }

        [TestMethod]
        public void BooksQuery_Should_ReturnIllustratedBookWithRelatedEntities_When_EagerLoadRelatedEntities_And_OfTypeSpecified()
        {
            // Act
            ICollection<IllustratedBook> result;
            using (var context = CreateNewContext())
            {
                result = context.Books.OfType<IllustratedBook>()
                   .Include(book => book.Publisher)
                   .Include(book => book.Reviews)
                   .Include(book => book.BookAuthors)
                       .ThenInclude(bookAuthor => bookAuthor.Author)
                   .Include(book => book.BookIllustrators)
                       .ThenInclude(bookIllustrator => bookIllustrator.Illustrator)
                   .ToList();
            }

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            foreach (var book in result)
            {
                Assert.IsNotNull(book);
                Assert.IsNotNull(book.Publisher);
                Assert.IsNotNull(book.Reviews);
                Assert.IsNotNull(book.BookAuthors);
                foreach (var bookAuthor in book.BookAuthors)
                {
                    Assert.IsNotNull(bookAuthor.Author);
                }
                foreach (var bookIllustrator in book.BookIllustrators)
                {
                    Assert.IsNotNull(bookIllustrator.Illustrator);
                }
            }
        }

        [Ignore]
        [TestMethod]
        public void RatedBookQuery_Should_ReturnRatedBooks_When_QueryByTitle()
        {
            // Act
            RatedBook result;
            using (var context = CreateNewContext())
            {
                result = context.RatedBooks
                    .Where(ratedBook => ratedBook.Title == "Anhelli")
                    .SingleOrDefault();
            }

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
            dynamic result;
            using (var context = CreateNewContext())
            {
                result = context.Books
                    .Where(book => EF.Functions.Like(book.Title, title))
                    .Select(book => new
                    {
                        book.Id,
                        ReviewsCount = context.ReviewsCount(book.Id)
                    }).SingleOrDefault();
            }

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.ReviewsCount);
        }

        [TestMethod]
        public void BookQuery_Should_ReturnOnlyActiveBooks_When_QueryFiltersNotIgnored()
        {
            // Act
            ICollection<Book> result;
            using (var context = CreateNewContext())
            {
                result = context.Books.ToList();
            }

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
            Book result;
            using (var context = CreateNewContext())
            {
                result = context.Books
                    .Where(book => book.Title == "Makbet")
                    .SingleOrDefault();
            }

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void BookQuery_Should_ReturnBook_When_QueryFiltersIgnored_And_BookIsDeleted()
        {
            // Act
            Book result;
            using (var context = CreateNewContext())
            {
                result = context.Books
                    .Where(book => book.Title == "Makbet")
                    .IgnoreQueryFilters()
                    .SingleOrDefault();
            }

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(State.Deleted, result.State);
        }

        [TestMethod]
        public void BookQuery_Should_ReturnIllustratedBooks_When_OfTypeSpecified()
        {
            // Act
            ICollection<IllustratedBook> result;
            using (var context = CreateNewContext())
            {
                result = context.Books.OfType<IllustratedBook>().ToList();
            }

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void BookQuery_Should_ReturnBookWithAuhorsAndIllustrators_When_AuthorsAndIllustratorsEagerLoaded()
        {
            // Act
            Book result;
            using (var context = CreateNewContext())
            {
                result = context.Books
                    .Include(book => book.BookAuthors)
                        .ThenInclude(bookAuthor => bookAuthor.Author)
                    .Include(book => (book as IllustratedBook).BookIllustrators)
                        .ThenInclude(bookIllustrator => bookIllustrator.Illustrator)
                    .Where(book => book.Title == "Mały Książę")
                    .SingleOrDefault();
            }

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.BookAuthors);
            Assert.IsTrue(result.BookAuthors.Any());
            Assert.AreEqual("Antoine de Saint-Exupéry", result.BookAuthors.First().Author.FullName);
            Assert.IsNotNull((result as IllustratedBook).BookIllustrators);
            Assert.IsTrue((result as IllustratedBook).BookIllustrators.Any());
            Assert.AreEqual("Antoine de Saint-Exupéry", (result as IllustratedBook).BookIllustrators.First().Illustrator.FullName);
        }

        [TestMethod]
        public void BookQuery_Should_ReturnAnonymousType_When_QueriedWithProjection()
        {
            using (var context = CreateNewContext())
            {
                // Act
                var result = context.Books
                    .Select(book => new
                    {
                        book.Id,
                        book.Isbn,
                        book.Title,
                        Authors = book.BookAuthors
                            .Select(bookAuthor => bookAuthor.Author).ToList(),
                        ReviewsCount = book.Reviews.Count()
                    })
                    .Where(book => book.Title == "Książka, której nigdy nie było")
                    .SingleOrDefault();

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Authors);
                Assert.IsTrue(result.Authors.Any());
                Assert.AreEqual("Adam Mickiewicz", result.Authors.First().FullName);
                Assert.AreEqual("Juliusz Słowacki", result.Authors.Last().FullName);
            }
        }

        [TestMethod]
        public void BookQuery_Should_ReturnBooksWithPublisher_When_ExplicitlyLoaded()
        {
            using (var context = CreateNewContext())
            {
                // Arrange
                var result = context.Books
                    .Where(book => book.Title == "Książka, której nigdy nie było")
                    .SingleOrDefault();

                // Act
                context.Entry(result)
                    .Collection(book => book.BookAuthors)
                    .Load();

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.BookAuthors);
                Assert.IsTrue(result.BookAuthors.Any());
            }
        }

        [TestMethod]
        public void BookQuery_Should_ReturnReviewsCount_When_ExplicitlyQueried()
        {
            using (var context = CreateNewContext())
            {
                // Arrange
                var result = context.Books
                    .Where(book => book.Title == "Książka, której nigdy nie było")
                    .SingleOrDefault();

                // Act                
                var count = context.Entry(result)
                    .Collection(book => book.Reviews)
                    .Query()
                    .Where(review => review.Rating > 2)
                    .Count();

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(2, count);
            }
        }

        [TestMethod]
        public void BookQuery_Should_ReturnReviewsCount_When_ClientSideCalculated()
        {
            using (var context = CreateNewContext())
            {
                // Arrange
                Func<ICollection<Review>, decimal> average =
                    reviews => reviews
                            .Select(review => (decimal?)review.Rating)
                            .Average() ?? 0;

                // Act
                var result = context.Books
                    .Where(book => book.Reviews.Any())
                    .Select(book => new
                    {
                        book.Id,
                        book.Title,
                        AverateRating = average(book.Reviews)
                    })
                    .OrderBy(book => book.Id)
                    .ToList();

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result);
                Assert.AreEqual(10, result.Count);
                Assert.AreEqual((decimal)4.0, result.First().AverateRating);
                Assert.AreEqual((decimal)5.0, result.Last().AverateRating);
            }
        }

        [TestMethod]
        public void BookQuery_Should_ReturnBooksWithAverageRating_When_QueriedWithProjection()
        {
            using (var context = CreateNewContext())
            {
                // Act
                var result = context.Books
                    .Select(book => new
                    {
                        book.Id,
                        book.Isbn,
                        book.Title,
                        AverageRating = book.Reviews
                            .Select(review => (decimal?)review.Rating)
                            .Average(),
                        //AverageRating = book.Reviews
                        //    .Select(review => review.Rating)
                        //    .DefaultIfEmpty(0)
                        //    .Average()
                    })
                    .OrderBy(book => book.Id)
                    .ToList();

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(13, result.Count);
                Assert.AreEqual((decimal)4.0, result.First().AverageRating);
                Assert.IsNull(result.Last().AverageRating);
            }
        }

        [TestMethod]
        public void BookQuery_Should_ReturnOnlyIllustratedBooks_When_FilterByIsIllustrated()
        {
            using (var context = CreateNewContext())
            {
                // Act
                var result = context.Books
                    .Where(book => book.IsIllustrated)
                    .ToList();

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.Count);
                Assert.AreEqual("Mały Książę", result.First().Title);
                Assert.AreEqual("Kubuś Puchatek", result.Last().Title);
            }
        }
    }
}
