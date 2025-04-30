using EncoreTix.Models;
using EncoreTix.ViewModels;

namespace EncoreTix.Interfaces
{
    public interface ITicketmasterApiClient
    {
        Task<AttractionSearchViewModel> SearchAttractionsAsync(AttractionSearchRequest request);
        Task<AttractionDetails> GetAttractionDetailsAsync(string attractionId);

        Task<AttractionEventsViewModel> GetAttractionEventsAsync(string attractionId);
    }
}
