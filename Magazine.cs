using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Magazine : LibraryItem
    {
        public Magazine(string title, string number, int id) : base(id, "MAG", title)
        {
            MagNumber = number;
        }
        [JsonProperty("number ")]
        private string MagNumber { get; set; }

        public override string Desc()
        {
            return "MAGAZINE: " + Id.ToString() + ",NUMBER: " + MagNumber + ",TITLE: " + Title;
        }

        public override bool IsSame(LibraryItem it)
        {
            if (it.GroupCode == "MAG")
            {
                Magazine thesis = (Magazine)it;
                if (thesis.MagNumber == MagNumber &&
                    thesis.Title == Title)
                {
                    return true;
                }
            }
            return false;
        }

        public override string GetExtraInfo()
        {
            return MagNumber;
        }
    }
}
