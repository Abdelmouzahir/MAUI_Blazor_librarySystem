using System;
using LibrarySystem.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author_FN { get; set; }
        public string Author_LN { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public bool IsSelected { get; set; }

        public Book()
        { }

        public Book(string title, string isbn,  string author_FN, string author_LN, string publisher, string genre)
        {
            Title = title;
            ISBN = isbn;
            Author_FN = author_FN;
            Author_LN = author_LN;
            Publisher = publisher;
            Genre = genre;
            IsSelected = true;
        }
    }
}