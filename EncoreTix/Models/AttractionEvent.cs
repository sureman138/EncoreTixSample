using System.Text.Json.Serialization;

namespace EncoreTix.Models
{
    public class AttractionEvent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public List<Image>? Images { get; set; }
        public EventDate? Dates { get; set; }

        [JsonPropertyName("_embedded")]
        public EventEmbeddedDetails EventEmbeddedDetails { get; set; }

        public string FormattedDate
        {
            get
            {
                if (Dates != null && Dates?.Start?.LocalDate != null)
                {
                    var firstDate = Dates.Start.LocalDate;
                    if (!string.IsNullOrEmpty(firstDate))
                    {
                        DateTime dateTime;
                        if (DateTime.TryParse(firstDate, out dateTime))
                        {
                            return dateTime.ToString("MMMM dd, yyyy");
                        }
                    }
                }
                return string.Empty;
            }
        }

        public string FormattedLocation
        {
            get
            {
                if (EventEmbeddedDetails != null && EventEmbeddedDetails.Venues != null && EventEmbeddedDetails.Venues.Count > 0)
                {
                    var firstVenue = EventEmbeddedDetails.Venues.FirstOrDefault();
                    if (firstVenue != null)
                    {
                        var stateOrCountry = firstVenue.State?.StateCode ??
                                             (firstVenue.Country?.CountryCode ?? string.Empty);
                        var location = $"{firstVenue.Name}, {firstVenue.City.Name}{(!string.IsNullOrEmpty(stateOrCountry) ? ", " + stateOrCountry : stateOrCountry)}";
                        return location;
                    }
                }
                return string.Empty;
            }
        }
    }

    public class EventDate
    {
        public StartDate Start { get; set; }

    }

    public class StartDate
    {
        public string LocalDate { get; set; }
    }

    public class EventEmbeddedDetails
    {
        public List<Venue> Venues { get; set; }
        public List<AttractionDetails> Attractions { get; set; }
    }

    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public List<Image>? Images { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
    }
    public class State
    {
        public string StateCode { get; set; }
    }

    public class Country
    {
        public string CountryCode { get; set; }
    }
}
