using Newtonsoft.Json;
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
            Item = item;
            Name = name;
            Surname = surname;
        }
        [JsonProperty]
        public LibraryItem Item { get; }
        [JsonProperty]
        public string Name { get; }
        [JsonProperty]
        public string Surname { get; }
    }
}
