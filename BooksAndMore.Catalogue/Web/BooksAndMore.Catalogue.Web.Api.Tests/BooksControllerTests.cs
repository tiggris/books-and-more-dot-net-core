using BooksAndMore.Catalogue.Application.Queries.BooksQuery;
using BooksAndMore.Catalogue.Application.Queries.BooksSearchQuery;
using BooksAndMore.Catalogue.Application.Queries.TopBooksQuery;
using BooksAndMore.Catalogue.Web.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BooksAndMore.Catalogue.Web.Api.Tests
{
    [TestClass]
    public class BooksControllerTests
    {
        private TestServer _server;
        private HttpClient _client;

        [TestInitialize]
        public void TestInitialize()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            _server = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [TestMethod]
        public async Task GetBooks_Should_Return_5BooksOrderedByTitle()
        {
            // Arrange
            var response = await _client.GetAsync("/api/books");
            response.EnsureSuccessStatusCode();

            // Act
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IList<BooksListItem>>(responseString);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
            Assert.AreEqual("Anhelli", result.First().Title);
            Assert.AreEqual("Konrad Wallenrod", result.Last().Title);
        }

        [TestMethod]
        public async Task GetBook_Should_Return_BookWithPublisherAuthorsAndReviews()
        {
            // Arrange
            var response = await _client.GetAsync("/api/books/1");
            response.EnsureSuccessStatusCode();

            // Act
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BookModel>(responseString);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Pan Tadeusz", result.Title);
            Assert.IsNotNull(result.Publisher);
            Assert.AreEqual("Wydawnictwo Rebis", result.Publisher.Name);
            Assert.IsTrue(result.Authors.Any());
            Assert.AreEqual("Adam Mickiewicz", result.Authors.First().Name);
            Assert.IsTrue(result.Reviews.Any());
            Assert.AreEqual(3, result.Reviews.First().Rating);
        }

        [TestMethod]
        public async Task GetTop10Books_Should_Return_Top10BooksWithHighestRating()
        {
            // Arrange
            var response = await _client.GetAsync("/api/books/top10");
            response.EnsureSuccessStatusCode();

            // Act
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TopBooksList>(responseString);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(13, result.BooksCount);
            Assert.AreEqual(10, result.Books.Count());
            Assert.IsNotNull(result.Books);
            Assert.AreEqual("Ryszard III", result.Books.First().Title);
        }

        [TestMethod]
        public async Task SearchBooks_Should_Return_SearchedBooks()
        {
            // Arrange
            var response = await _client.GetAsync("/api/books/search?term=Adam");
            response.EnsureSuccessStatusCode();

            // Act
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IList<BooksSearchListItem>>(responseString);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual("Pan Tadeusz", result.First().Title);
        }
    }
}
