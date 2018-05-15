using BooksAndMore.Catalogue.Application.Queries.BooksSearchQuery;
using BooksAndMore.Catalogue.Application.Queries.TopBooksQuery;
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
            var result = JsonConvert.DeserializeObject<IList<BooksListItem>>(responseString);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual("Pan Tadeusz", result.First().Title);
        }
    }
}
