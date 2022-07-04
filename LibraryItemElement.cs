using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class LibraryItemElement
    {
        public LibraryItemElement(LibraryItem item, int number)
        {
            Item = item;
            Num = number;
        }
        [JsonConverter(typeof(LibraryItemConverter))]
        public LibraryItem Item { get; set; }
        public int Num { get; set; }
    }
}
