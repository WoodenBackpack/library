using Newtonsoft.Json;
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
            Director = director;
        }
        [JsonProperty("Director ")]
        private string Director { get; set; }


        public override string Desc()
        {
            return "MOVIE: " + Id.ToString() + ",DIRECTOR: " + Director + ",TITLE: " + Title;
        }

        public override bool IsSame(LibraryItem it)
        {
            if (it.GroupCode == "MOV")
            {
                Movie movie = (Movie)it;
                if (movie.Director == Director &&
                    movie.Title == Title)
                {
                    return true;
                }
            }
            return false;
        }

        public override string GetExtraInfo()
        {
            return Director;
        }
    }
}
