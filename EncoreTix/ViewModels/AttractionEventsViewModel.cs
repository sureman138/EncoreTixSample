using EncoreTix.Models;
using System.Text.Json.Serialization;

namespace EncoreTix.ViewModels
{
    public class AttractionEventsViewModel
    {
        [JsonPropertyName("_embedded")]
        public AttractionEventsEmbedded Embedded { get; set; }
        public string AttractionName { get; set; }
        public string? TwitterUrl { get; set; }
        public string? SpotifyUrl { get; set; }
        public string? YouTubeUrl { get; set; }
        public string? HomePageUrl { get; set; }

        public string? AttractionImageUrl
        {
            get
            {
                if (Embedded?.Events != null && Embedded?.Events.Count > 0)
                {
                    var attractionImageUrl = Embedded.Events.FirstOrDefault()?.EventEmbeddedDetails.Attractions?.Where(a => a.Name == AttractionName).FirstOrDefault()?.Images?.FirstOrDefault()?.Url;
                    return attractionImageUrl;
                }
                return null;
            }
        }
    }

    public class AttractionEventsEmbedded
    {
        public List<AttractionEvent> Events { get; set; }
    }
}
