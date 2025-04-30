using EncoreTix.Models;
using System.Text.Json.Serialization;

namespace EncoreTix.ViewModels
{
    public class AttractionEventsViewModel
    {
        [JsonPropertyName("_embedded")]
        public AttractionEventsEmbedded Embedded { get; set; }
    }

    public class AttractionEventsEmbedded
    {
        public List<AttractionEvent> Events { get; set; }
    }
}
