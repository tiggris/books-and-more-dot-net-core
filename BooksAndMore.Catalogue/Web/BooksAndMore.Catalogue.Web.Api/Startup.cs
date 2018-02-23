using BooksAndMore.Catalogue.Infrastructure.Data;
using BooksAndMore.Catalogue.Web.Api.Infrastructure.Data;
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
            services.AddDbContext<BooksCatalogueContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString(_connectionStringName),
                    sqlServerOptions => sqlServerOptions.MigrationsAssembly(_migrationsAssemblyName)));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<BooksCatalogueContext>().Database.Migrate();
                    serviceScope.ServiceProvider.GetService<BooksCatalogueContext>().EnsureSeedData();
                }
            }

            app.UseMvc();
        }
    }
}
