using BooksAndMore.Catalogue.Domain.Common;
using System;

namespace BooksAndMore.Catalogue.Domain.Model.Books.Reviews
{
    public class Review : IEntity<int>
    {
        public int Id { get; private set; }
        public int Rating { get; private set; }
        public string ReviewerName { get; private set; }
        public string ReviewText { get; private set; }
        public DateTime CreateDate { get; private set; }

        private Review() { }

        public Review(int rating, string reviewerName = null, string reviewText = null)
        {
            Rating = rating;
            ReviewerName = reviewerName;
            ReviewText = reviewText;
            CreateDate = DateTimeProvider.GetCurrentDateTime();
        }
    }
}
