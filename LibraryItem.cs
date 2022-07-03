using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    abstract class LibraryItem
    {
        protected string groupCode;
        protected string title;
        protected int id;

        protected LibraryItem(int id, string groupCode, string title)
        {
            this.id = id;
            this.groupCode = groupCode;
            this.title = title;
        }
        public int Id() { return id; }

        public string Title() { return title; }
        public string GroupCode() { return groupCode; }
        public abstract string Desc();
        public abstract string GetExtraInfo();

        public abstract bool IsSame(LibraryItem it);
    }
}
