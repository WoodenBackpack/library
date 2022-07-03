using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Book : LibraryItem
    {
        public Book(string title, string author, int id) : base(id, "BOOK", title)
        {
            this.author = author;
        }

        private string author;

        public string Author() { return author; }
        public override string Desc()
        {
            return "Book " + id.ToString() + " AUTHOR: " + author + " TITLE: " + title;
        }
        public override bool IsSame(LibraryItem it)
        {
            if (it.GroupCode() == "BOOK")
            {
                Book book = (Book)it;
                if (book.Author() == author &&
                    book.Title() == title)
                {
                    return true;
                }
            }
            return false;
        }

        public override string GetExtraInfo()
        {
            return author;
        }

    }
}

