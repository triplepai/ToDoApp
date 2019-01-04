
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Models
{
    public class ToDoModel
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
