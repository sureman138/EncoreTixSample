namespace EncoreTix.Models
{
    public class ExternalLink
    {
        public List<Link>? YouTube { get; set; }
        public List<Link>? Twitter { get; set; }
        public List<Link>? Spotify { get; set; }
        public List<Link>? Homepage { get; set; }
    }

    public class Link
    {
        public string? Url { get; set; }
    }
}
