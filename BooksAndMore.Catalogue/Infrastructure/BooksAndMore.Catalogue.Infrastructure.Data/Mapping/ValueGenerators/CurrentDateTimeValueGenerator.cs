using BooksAndMore.Catalogue.Domain.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping.ValueGenerators
{
    public class CurrentDateTimeValueGenerator : ValueGenerator<DateTime>
    {
        public override bool GeneratesTemporaryValues => false;

        public override DateTime Next(EntityEntry entry)
        {
            return DateTimeProvider.CurrentDateTime;
        }
    }
}
