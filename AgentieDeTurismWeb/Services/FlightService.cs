using AgentieDeTurismWeb.Controllers;
using AgentieDeTurismWeb.Models.SkyScannerAPI;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace AgentieDeTurismWeb.Services
{
    public class FlightService
    {
        public IWebHostEnvironment _webHostEnvironment;
        public FlightService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public List<Itinerary> GetAvailableFlights()
        {
            RootSky root;

            using (StreamReader r = new StreamReader(_webHostEnvironment.WebRootPath + "\\input\\zboruri.json"))
            {
                string json = r.ReadToEnd();
                root = JsonSerializer.Deserialize<RootSky>(json);
            }

            List<Itinerary> itineraries = root.data.itineraries;

            return itineraries;
        }
    }
}
