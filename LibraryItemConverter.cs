using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WpfApp1
{
    class LibraryItemConverter : JsonConverter<LibraryItem>
    {
        public override void WriteJson(JsonWriter writer, LibraryItem value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Desc());
        }

        public override LibraryItem ReadJson(JsonReader reader, Type objectType, LibraryItem existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string s = (string)reader.Value;
            List<string> splitted = s.Split(',').ToList();
            int number = int.Parse(splitted[0].Split(':')[1]);
            string title = splitted[2].Split(':')[1];
            string extra = splitted[1].Split(':')[1];
            string type = splitted[0].Split(':')[0];
            if (type == "MAGAZINE")
            {
                return new Magazine(title, extra, number);
            } else if (type == "THESIS")
            {
                return new Thesis(title, extra, number);
            }
            else if (type == "BOOK")
            {
                return new Book(title, extra, number);
            }
            else if (type == "MOVIE")
            {
                return new Movie(title, extra, number);
            }
            return null; 
        }
    }
}
