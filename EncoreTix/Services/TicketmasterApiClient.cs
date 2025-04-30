using EncoreTix.Interfaces;
using EncoreTix.ViewModels;
using EncoreTix.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace EncoreTix.Services
{
    public class TicketmasterApiClient : ITicketmasterApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly TicketmasterApiOptions _options;
        private const string BaseUrl = "https://app.ticketmaster.com/discovery/v2";

        public TicketmasterApiClient(HttpClient httpClient, IOptions<TicketmasterApiOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value ?? throw new ArgumentNullException(nameof(options));
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<AttractionSearchViewModel> SearchAttractionsAsync(AttractionSearchRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var queryParams = new Dictionary<string, string>
            {
                ["apikey"] = _options.ApiKey,
                ["size"] = request.Size.ToString(),
            };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                queryParams["keyword"] = request.Keyword;
            }
            string fullEndpoint = new UriBuilder($"{BaseUrl}/attractions.json")
            {
                Query = string.Join("&", queryParams.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"))
            }.ToString();

            var response = await _httpClient.GetAsync(fullEndpoint);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
                return new AttractionSearchViewModel { Embedded = new AttractionEmbedded() };

            return JsonSerializer.Deserialize<AttractionSearchViewModel>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        }

        public async Task<AttractionDetails> GetAttractionDetailsAsync(string attractionId)
        {
            if (string.IsNullOrEmpty(attractionId))
                throw new ArgumentNullException(nameof(attractionId));

            var queryParams = new Dictionary<string, string>
            {
                ["apikey"] = _options.ApiKey,
                ["size"] = "1",
            };
            string fullEndpoint = new UriBuilder($"{BaseUrl}/attractions/{attractionId}.json")
            {
                Query = string.Join("&", queryParams.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"))
            }.ToString();

            var response = await _httpClient.GetAsync(fullEndpoint);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AttractionDetails>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<AttractionEventsViewModel> GetAttractionEventsAsync(string attractionId)
        {
            if (string.IsNullOrEmpty(attractionId))
                throw new ArgumentNullException(nameof(attractionId));

            var queryParams = new Dictionary<string, string>
            {
                ["apikey"] = _options.ApiKey,
                ["size"] = "6",
                ["attractionId"] = attractionId
            };
            string fullEndpoint = new UriBuilder($"{BaseUrl}/events.json")
            {
                Query = string.Join("&", queryParams.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"))
            }.ToString();

            var response = await _httpClient.GetAsync(fullEndpoint);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(content) || !content.Contains("_embedded"))
                return new AttractionEventsViewModel { Embedded = new AttractionEventsEmbedded() };

            return JsonSerializer.Deserialize<AttractionEventsViewModel>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public class TicketmasterApiOptions
        {
            public string ApiKey { get; set; }
        }
    }
}
