using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Tests
{
    [TestClass]
    public abstract class TestBase
    {
        private static readonly string _connectionString;
        protected static BooksCatalogueContext _context;
        protected static DbContextOptionsBuilder<BooksCatalogueContext> _optionsBuilder;

        static TestBase()
        {
            _connectionString = $"Server=(localdb)\\mssqllocaldb;Database=BooksCatalogue.DotNetCore_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {            
            _optionsBuilder = GetOptionsBuilder();
            _context = new BooksCatalogueContext(_optionsBuilder.Options);
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            _context.Database.EnsureDeleted();
        }

        private static DbContextOptionsBuilder<BooksCatalogueContext> GetOptionsBuilder()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .AddEntityFrameworkProxies()
                .BuildServiceProvider();

            var optionsBuilder = new DbContextOptionsBuilder<BooksCatalogueContext>();
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(_connectionString)
                .UseInternalServiceProvider(serviceProvider);

            return optionsBuilder;
        }

        public static void ReloadContext()
        {
            _context.Dispose();
            _context = new BooksCatalogueContext(_optionsBuilder.Options);
        }
    }
}
