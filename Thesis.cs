using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Thesis : LibraryItem
    {
        public Thesis(string title, string authors, int id) : base(id, "THESIS", title)
        {
            this.authors = authors.Split(',').ToList();
        }

        [JsonProperty]
        private List<string> authors;

        public string Authors() {
            string output = "";
            for (int i = 0; i < authors.Count - 1; ++i)
            {
                output += authors[i] + " ";
            }
            output += authors.Last();
            return output;
        }

        public override string Desc()
        {
            return "THESIS: " + Id.ToString() + ",AUTHORS: " + Authors() + ",TITLE: " + Title;
        }

        public override bool IsSame(LibraryItem it)
        {
            if (it.GroupCode == "THESIS")
            {
                Thesis thesis = (Thesis)it;
                if (thesis.Authors() == Authors() &&
                    thesis.Title == Title)
                {
                    return true;
                }
            }
            return false;
        }

        public override string GetExtraInfo()
        {
            return Authors();
        }
    }
}
