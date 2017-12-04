using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Json
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Person
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        //[JsonIgnore]
        [JsonConverter(typeof(BoolConvert))]
        public bool IsMarry { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(ChinaDateTimeConverter))]
        public DateTime Birthday { get; set; }
    }
}
