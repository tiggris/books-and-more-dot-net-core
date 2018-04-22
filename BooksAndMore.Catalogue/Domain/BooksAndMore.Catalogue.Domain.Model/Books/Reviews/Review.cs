using BooksAndMore.Catalogue.Domain.Common.Model;
using System;

namespace BooksAndMore.Catalogue.Domain.Model.Books.Reviews
{
    public class Review : IEntity<int>
    {
        private string _reviewEncodedText;

        public int Id { get; private set; }
        public int Rating { get; private set; }
        public string ReviewerName { get; private set; }
        public string ReviewText => _reviewEncodedText;
        public DateTime CreateDate { get; private set; }

        protected Review() { }

        internal Review(int rating, string reviewerName = null, string reviewText = null)
        {
            Rating = rating;
            ReviewerName = reviewerName;
            SetReviewText(reviewText);
        }

        public void SetReviewText(string text)
        {
            if(!string.IsNullOrWhiteSpace(text))
            {
                _reviewEncodedText = Uri.EscapeDataString(text);
            }
        }
    }
}
