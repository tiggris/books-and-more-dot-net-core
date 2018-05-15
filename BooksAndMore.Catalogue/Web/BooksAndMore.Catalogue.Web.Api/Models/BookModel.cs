using System.Collections.Generic;

namespace BooksAndMore.Catalogue.Web.Api.Models
{
    public class BookModel
    {
        public class AuthorModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class PublisherModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class ReviewModel
        {
            public int Id { get; set; }
            public decimal Rating { get; set; }
            public string ReviewerName { get; set; }
            public string ReviewText { get; set; }
        }

        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public bool IsIllustrated { get; set; }
        public decimal AverageRating { get; set; }
        public PublisherModel Publisher { get; set; }
        public IList<AuthorModel> Authors { get; set; }
        public IList<ReviewModel> Reviews { get; set; }
    }
}
