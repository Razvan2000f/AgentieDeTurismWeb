using AgentieDeTurismWeb.Controllers;
using AgentieDeTurismWeb.Models.SkyScannerAPI;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace AgentieDeTurismWeb.Services
{
    public class FlightService
    {
        public IWebHostEnvironment _webHostEnvironment;
        private HttpService _httpService;
        public FlightService(IWebHostEnvironment webHostEnvironment, HttpService httpService)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpService = httpService;
        }

        public List<Itinerary> GetAvailableFlights(string from, string to, string formattedStart, string formattedEnd, int noAdults)
        {
            string body=_httpService.CreateSkyScannerAPI(from, to, formattedStart, formattedEnd, noAdults).Result;
            RootSky root = JsonSerializer.Deserialize<RootSky>(body);

            List<Itinerary> itineraries = root.data.itineraries;

            return itineraries;
        }
    }
}
