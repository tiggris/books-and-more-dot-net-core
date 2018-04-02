using BooksAndMore.Catalogue.Domain.Model.Books;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping.ValueGenerators
{
    public class DefaultStateValueGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {
            return State.Active.ToString();
        }
    }
}
