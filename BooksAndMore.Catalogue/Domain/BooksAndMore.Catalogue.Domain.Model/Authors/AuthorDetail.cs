using System;
using System.Collections.Generic;
using System.Text;

namespace BooksAndMore.Catalogue.Domain.Model.Authors
{
    public class AuthorDetail
    {
        public int Id { get; private set; }
        public string Bio { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public virtual Author Author { get; private set; }

        protected AuthorDetail() { }

        public AuthorDetail(string bio, DateTime? birthDate)
        {
            Bio = bio;
            BirthDate = birthDate;
        }
    }
}
