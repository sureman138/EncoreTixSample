using System.Diagnostics;
using EncoreTix.Interfaces;
using EncoreTix.Models;
using Microsoft.AspNetCore.Mvc;

namespace EncoreTix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITicketmasterApiClient _ticketmasterApiClient;

        public HomeController(ILogger<HomeController> logger, ITicketmasterApiClient ticketmasterApiClient)
        {
            _logger = logger;
            _ticketmasterApiClient = ticketmasterApiClient;
        }

        public async Task<IActionResult> IndexAsync(string searchKeyword = "Phish")
        {
            var request = new AttractionSearchRequest
            {
                Keyword = searchKeyword
            };
            var attractions = await _ticketmasterApiClient.SearchAttractionsAsync(request);
            return View(attractions);
        }

        public async Task<IActionResult> AttractionEvents(string attractionId, string attractionName, string? twitterUrl, string? spotifyUrl, string? youTubeUrl, string? homePageUrl)
        {
            var attractionEvents = await _ticketmasterApiClient.GetAttractionEventsAsync(attractionId, attractionName, twitterUrl, spotifyUrl, youTubeUrl, homePageUrl);
            return View(attractionEvents);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
