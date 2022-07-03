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
            this.number = number;
        }

        private string number;

        public string Number() { return number; }

        public override string Desc()
        {
            return "MAGAZINE " + id.ToString() + " NUMBER: " + Number() + " TITLE: " + title;
        }

        public override bool IsSame(LibraryItem it)
        {
            if (it.GroupCode() == "MAG")
            {
                Magazine thesis = (Magazine)it;
                if (thesis.Number() == Number() &&
                    thesis.Title() == title)
                {
                    return true;
                }
            }
            return false;
        }

        public override string GetExtraInfo()
        {
            return Number();
        }
    }
}
