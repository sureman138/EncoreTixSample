using EncoreTix.Models;
using System.Text.Json.Serialization;

namespace EncoreTix.ViewModels
{
    public class AttractionEventsViewModel
    {
        [JsonPropertyName("_embedded")]
        public AttractionEventsEmbedded Embedded { get; set; }
        public string AttractionName { get; set; }
        public string PreviousKeyword { get; set; }
        public string? ImageUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? SpotifyUrl { get; set; }
        public string? YouTubeUrl { get; set; }
        public string? HomePageUrl { get; set; }
    }

    public class AttractionEventsEmbedded
    {
        public List<AttractionEvent> Events { get; set; }
    }
}
