using BooksAndMore.Catalogue.Domain.Common.Model;
using BooksAndMore.Catalogue.Domain.Model.Authors;
using BooksAndMore.Catalogue.Domain.Model.Books.Reviews;
using BooksAndMore.Catalogue.Domain.Model.Publishers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace BooksAndMore.Catalogue.Domain.Model.Books
{
    public class Book : IEntity<int>, IAuditable
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Isbn { get; private set; }
        public string Description { get; private set; }
        public decimal AverageRating { get; private set; }
        public bool IsIllustrated { get; private set; }
        public State State { get; private set; }
        public Publisher Publisher { get; private set; }
        public ObservableCollection<BookAuthor> BookAuthors { get; private set; }
        public ObservableCollection<Review> Reviews { get; private set; }

        //public event PropertyChangedEventHandler PropertyChanged;

        protected Book()
        {
            Reviews = new ObservableCollection<Review>();
            BookAuthors = new ObservableCollection<BookAuthor>();
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
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Reviews)));
        }

        public void Delete()
        {
            State = State.Deleted;
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
        }

        protected ObservableCollection<BookAuthor> GetBookAuthors(IList<Author> authors)
        {
            var bookAuthors = authors?.Select(author => new BookAuthor(this, author)).ToList();
            return new ObservableCollection<BookAuthor>(bookAuthors);
        }        
    }
}