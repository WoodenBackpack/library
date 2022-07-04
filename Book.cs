using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [JsonConverter(typeof(LibraryItemConverter))]
    internal class Book : LibraryItem
    {

        public Book(string title, string author, int id) : base(id, "BOOK", title)
        {
            Author = author;
        }
        [JsonProperty]
        private string Author { get; set; }
        public override string Desc()
        {
            return "BOOK: " + Id + ",AUTHOR: " + Author + ",TITLE: " + Title;
        }
        public override bool IsSame(LibraryItem it)
        {
            if (it.GroupCode == "BOOK")
            {
                Book book = (Book)it;
                if (book.Author == Author &&
                    book.Title == Title)
                {
                    return true;
                }
            }
            return false;
        }

        public override string GetExtraInfo()
        {
            return Author;
        }

    }
}

