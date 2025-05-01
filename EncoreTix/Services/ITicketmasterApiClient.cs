using EncoreTix.Models;
using EncoreTix.ViewModels;

namespace EncoreTix.Interfaces
{
    public interface ITicketmasterApiClient
    {
        Task<AttractionSearchViewModel> SearchAttractionsAsync(AttractionSearchRequest request);
        Task<AttractionEventsViewModel> GetAttractionEventsAsync(string attractionId, string attractionName, string previousKeyword, string? imageUrl, string? twitterUrl, string? spotifyUrl, string? youTubeUrl, string? homePageUrl);
    }
}
