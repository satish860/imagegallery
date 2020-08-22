using System.Text.Json.Serialization;

namespace ImageGallery.Pages
{
    public class ImageOfDayModel
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("title")]
        public string Caption { get; set; }

        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }
    }
}