using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Rental
    {
        public Rental(LibraryItem item, string name, string surname)
        {
            this.item = item;
            this.name = name;
            this.surname = surname;
        }

        private LibraryItem item;
        private string name;
        private string surname;
        public LibraryItem Item() { return item; }
        public string Name() { return name; }
        public string Surname() { return surname; }
    }
}
