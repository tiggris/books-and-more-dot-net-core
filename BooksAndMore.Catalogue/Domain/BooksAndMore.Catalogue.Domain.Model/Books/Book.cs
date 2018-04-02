using BooksAndMore.Catalogue.Domain.Common;
using BooksAndMore.Catalogue.Domain.Model.Authors;
using BooksAndMore.Catalogue.Domain.Model.Books.Reviews;
using BooksAndMore.Catalogue.Domain.Model.Publishers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BooksAndMore.Catalogue.Domain.Model.Books
{
    public class Book : IEntity<int>, IAuditable, INotifyPropertyChanged
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Isbn { get; private set; }
        public string Description { get; private set; }
        public decimal AverageRating { get; private set; }
        public bool IsIllustrated { get; private set; }
        public State State { get; private set; }
        public Publisher Publisher { get; private set; }
        public ICollection<BookAuthor> BookAuthors { get; private set; }
        public ICollection<Review> Reviews { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected Book()
        {
            Reviews = new HashSet<Review>();
        }        

        public Book(string title, string isbn, string description, Publisher publisher, IList<Author> authors): this()
        {
            Title = title;
            Isbn = isbn;
            Description = description;
            Publisher = publisher;
            BookAuthors = GetBookAuthors(authors);
        }

        public void AddReview(int rating, string reviewerName = null, string reviewText = null)
        {
            if(!Enumerable.Range(1, 5).Contains(rating))
            {
                throw new ArgumentException("Rating must be between 1 and 5", nameof(rating));
            }

            Reviews.Add(new Review(rating, reviewerName, reviewText));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Reviews)));
        }

        public void Delete()
        {
            State = State.Deleted;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
        }

        protected IList<BookAuthor> GetBookAuthors(IList<Author> authors)
        {
            return authors?.Select(author => new BookAuthor(this, author)).ToList();
        }        
    }
}