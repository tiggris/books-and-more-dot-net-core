using BooksAndMore.Catalogue.Domain.Common.Model;
using BooksAndMore.Catalogue.Domain.Model.Books;
using System;
using System.Collections.Generic;

namespace BooksAndMore.Catalogue.Domain.Model.Authors
{
    public class Author : IEntity<int>
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get; private set; }
        public AuthorType AuthorType { get; private set; }
        public virtual AuthorDetail AuthorDetail { get; private set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; private set; }

        protected Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public Author(string firstName, string lastName, string bio = null, DateTime? birthDate = null) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            AuthorDetail = new AuthorDetail(bio, birthDate);
        }
    }
}
