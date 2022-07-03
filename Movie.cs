using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Movie : LibraryItem
    {
        public Movie(string title, string director, int id) : base(id, "MOV", title)
        {
            this.director = director;
        }

        private string director;

        public string Director() { return director; }

        public override string Desc()
        {
            return "MOVIE " + id.ToString() + " DIRECTOR: " + director + " TITLE: " + title;
        }

        public override bool IsSame(LibraryItem it)
        {
            if (it.GroupCode() == "MOV")
            {
                Movie movie = (Movie)it;
                if (movie.Director() == director &&
                    movie.Title() == title)
                {
                    return true;
                }
            }
            return false;
        }

        public override string GetExtraInfo()
        {
            return director;
        }
    }
}
