using BooksAndMore.Catalogue.Domain.Model.Authors;
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
    public class AuthorsQueryTests : TestBase
    {
        [TestMethod]
        public void AuthorQuery_Should_ReturnAuthorWithoutDetails_When_NotLazyOrEagerLoaded()
        {
            Author result = null;
            using (var context = CreateNewContext(true))
            {
                // Act
                result = context.Authors
                    .OrderBy(author => author.Id)
                    .FirstOrDefault();
            }

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Adam Mickiewicz", result.FullName);
            Assert.IsNull(result.AuthorDetail);
        }

        [TestMethod]
        public void AuthorQuery_Should_ReturnAuthorWithDetails_When_LazyLoaded()
        {
            using (var context = CreateNewContext(enableLazyLoading: true))
            {
                // Act
                var result = context.Authors
                    .OrderBy(author => author.Id)
                    .FirstOrDefault();

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual("Adam Mickiewicz", result.FullName);
                Assert.IsNotNull(result.AuthorDetail);
                Assert.IsNotNull(result.AuthorDetail.Bio);
                Assert.AreEqual(new DateTime(1798, 12, 24), result.AuthorDetail.BirthDate);
            }
        }

        [TestMethod]
        public void AuthorQuery_Should_ReturnAuthorWithDetails_When_EagerLoaded()
        {
            Author result = null;
            using (var context = CreateNewContext())
            {
                // Act
                result = context.Authors
                    .Include(author => author.AuthorDetail)
                    .OrderBy(author => author.Id)
                    .FirstOrDefault();
            }

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Adam Mickiewicz", result.FullName);
            Assert.IsNotNull(result.AuthorDetail);
            Assert.IsNotNull(result.AuthorDetail.Bio);
            Assert.AreEqual(new DateTime(1798, 12, 24), result.AuthorDetail.BirthDate);
        }

        [TestMethod]
        public void AuthorDetailQuery_Should_ReturnAuthorDetails()
        {
            using (var context = CreateNewContext())
            {
                // Act
                var result = context.AuthorDetails
                    .OrderBy(authorDetail => authorDetail.Id)
                    .FirstOrDefault();

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Bio);
                Assert.AreEqual(new DateTime(1798, 12, 24), result.BirthDate);
            }
        }

        [TestMethod]
        public void AuthorQuery_Should_ReturnAuthorsWithNumberOfBooks_When_GroupByAuthor()
        {
            using (var context = CreateNewContext())
            {
                // Act
                var result = context.Authors
                    .SelectMany(author => author.BookAuthors)
                    .GroupBy(bookAuthor => bookAuthor.Author)
                    .Select(bookAuthor => new
                    {
                        Author = bookAuthor.Key,
                        BooksCount = bookAuthor.Count()
                    })
                    .OrderByDescending(bookAuthor => bookAuthor.BooksCount)
                    .ToList();

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(5, result.Count);
                Assert.AreEqual("Adam Mickiewicz", result.First().Author.FullName);
                Assert.AreEqual(5, result.First().BooksCount);
            }
        }
    }
}
