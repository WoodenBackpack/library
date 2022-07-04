using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WpfApp1
{
    internal class MyJsonSerializer<T>
    {
        public T Deserialize(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public string Serialize(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
