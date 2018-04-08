using BooksAndMore.Catalogue.Domain.Model.Books;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Linq;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping.ValueGenerators
{
    public class AverageRatingValueGenerator : ValueGenerator<decimal>
    {
        public override bool GeneratesTemporaryValues => false;

        public override decimal Next(EntityEntry entry)
        {
            if (entry == null)
            {
                throw new System.ArgumentNullException(nameof(entry));
            }

            var book = entry.Entity as Book;
            return book != null ?
                (decimal)book.Reviews.Select(review => review.Rating).DefaultIfEmpty(0).Average() :
                0;
        }        
    }
}
