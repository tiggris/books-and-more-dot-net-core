using BooksAndMore.Catalogue.Domain.Model.Books;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Linq;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public class AverageRatingValueGenerator : ValueGenerator<double>
    {
        public override bool GeneratesTemporaryValues => false;

        public override double Next(EntityEntry entry)
        {
            if (entry == null)
            {
                throw new System.ArgumentNullException(nameof(entry));
            }

            var book = entry.Entity as Book;
            return book != null ?
                book.Reviews.Select(review => review.Rating).DefaultIfEmpty(0).Average() :
                0;
        }        
    }
}
