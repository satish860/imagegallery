using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Imageoftheday.Models
{
    public class ImageofDay
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("title")]
        public string Caption { get; set; }

        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }
    }
}
