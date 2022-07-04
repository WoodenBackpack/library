using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [JsonConverter(typeof(LibraryItemConverter))]
    abstract class LibraryItem
    {
        
        [JsonProperty]
        public string GroupCode { get; set; }
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public int Id { get; set; }
        
        [JsonConstructor]
        protected LibraryItem(int id, string groupCode, string title)
        {
            Id = id;
            GroupCode = groupCode;
            Title = title;
        }
        public abstract string Desc();
        public abstract string GetExtraInfo();

        public abstract bool IsSame(LibraryItem it);
    }


}
