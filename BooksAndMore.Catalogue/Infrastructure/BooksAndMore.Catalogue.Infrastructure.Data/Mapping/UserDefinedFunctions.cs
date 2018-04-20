using Microsoft.EntityFrameworkCore;
using System;

namespace BooksAndMore.Catalogue.Infrastructure.Data.Mapping
{
    public static class UserDefinedFunctions
    {
        [DbFunction]
        public static int ReviewsCount(int bookId)
        {
            throw new Exception();
        }
    }
}
