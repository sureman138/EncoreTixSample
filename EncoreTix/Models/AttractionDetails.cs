
namespace EncoreTix.Models
{
    public class AttractionDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public ExternalLink? ExternalLinks { get; set; }
        public List<Image>? Images { get; set; }
    }
}
