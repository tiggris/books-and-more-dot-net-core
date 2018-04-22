using System;

namespace BooksAndMore.Catalogue.Domain.Common
{
    public class DateTimeProvider
    {
        public static DateTime CurrentDateTime => DateTime.UtcNow;
    }
}
