using System.Text.Json.Serialization;

namespace EncoreTix.Models
{
    public class AttractionSearchViewModel
    {
        [JsonPropertyName("_embedded")]
        public AttractionEmbedded Embedded { get; set; }

        public string PreviousKeyword { get; set; }
    }

    public class AttractionEmbedded
    {
        public List<AttractionDetails> Attractions { get; set; }
    }
}
