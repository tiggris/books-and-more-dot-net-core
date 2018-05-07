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
        private const string _migrationsAssemblyName = "BooksAndMore.Catalogue.Infrastructure.Data.Migrations";
        protected static DbContextOptionsBuilder<BooksCatalogueContext> _optionsBuilder;

        static TestBase()
        {
            _connectionString = $"Server=(localdb)\\mssqllocaldb;Database=BooksCatalogue.DotNetCore_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {            
            _optionsBuilder = GetOptionsBuilder();
            using (var context = CreateNewContext())
            {
                context.Database.Migrate();
            }            
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            using (var context = CreateNewContext())
            {
                context.Database.EnsureDeleted();
            }
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
                .UseSqlServer(_connectionString, 
                    sqlServerOptions => sqlServerOptions.MigrationsAssembly(_migrationsAssemblyName))
                .UseInternalServiceProvider(serviceProvider);

            return optionsBuilder;
        }

        protected static BooksCatalogueContext CreateNewContext()
        {
            return new BooksCatalogueContext(_optionsBuilder.Options);
        }
    }
}
