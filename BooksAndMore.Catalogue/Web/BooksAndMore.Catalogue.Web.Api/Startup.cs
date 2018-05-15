using BooksAndMore.Catalogue.Application.Queries.BooksQuery;
using BooksAndMore.Catalogue.Application.Queries.BooksSearchQuery;
using BooksAndMore.Catalogue.Application.Queries.TopBooksQuery;
using BooksAndMore.Catalogue.Domain.Common.Data;
using BooksAndMore.Catalogue.Infrastructure.Data;
using BooksAndMore.Catalogue.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksAndMore.Catalogue.Web.Api
{
    public class Startup
    {
        private const string _connectionStringName = "BooksCatalogueDb";
        private const string _migrationsAssemblyName = "BooksAndMore.Catalogue.Infrastructure.Data.Migrations";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkProxies();
            services.AddDbContext<BooksCatalogueContext>(options =>
                options
                .UseSqlServer(Configuration.GetConnectionString(_connectionStringName),
                    sqlServerOptions => sqlServerOptions.MigrationsAssembly(_migrationsAssemblyName))
                .UseLazyLoadingProxies());

            services.AddMvc();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IQueryProvider, QueryProvider>();
            services.AddScoped<ITopBooksQuery, TopBooksQuery>();
            services.AddScoped<IBooksSearchQuery, BooksSearchQuery>();
            services.AddScoped<IBooksQuery, BooksQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var booksCatalogueContext = serviceScope.ServiceProvider.GetService<BooksCatalogueContext>();
                    booksCatalogueContext.Database.Migrate();
                    //booksCatalogueContext.EnsureSeedData();
                }
            }

            app.UseMvc();
        }
    }
}
