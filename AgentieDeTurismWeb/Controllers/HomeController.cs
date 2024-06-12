using AgentieDeTurismWeb.Models;
using AgentieDeTurismWeb.Models.BookingAPI;
using AgentieDeTurismWeb.Models.SkyScannerAPI;
using AgentieDeTurismWeb.Models.WeatherAPI;
using AgentieDeTurismWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AgentieDeTurismWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly int ShowIndex = 5;

        private readonly FlightService _flightService;
        private readonly HotelService _hotelService;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment,
            FlightService flightService, HotelService hotelService)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _flightService = flightService;
            _hotelService=hotelService;
        }

        public IActionResult Index()
        {
            List<Result> results = _hotelService.GetAllHotels("Hanoi","2024-8-1","2024-8-8",2);
            results = results.OrderByDescending(result => result.review_score).ToList();

            List<HotelViewModel> hotels = new List<HotelViewModel>();
            for (int i = 0; i < ShowIndex; i++)
            {
                string photoPath = _hotelService.GetHotelPhoto(results[i].hotel_id);
                HotelDescription description = _hotelService.GetHotelDescription(results[i].hotel_id);
                HotelViewModel hotel = new HotelViewModel()
                {
                    Result = results[i],
                    Photo = "https://cf.bstatic.com" + "/xdata" + photoPath,
                    Description = description.description,
                };
                hotels.Add(hotel);
            }

            return View(hotels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult checkBookingOptions(string dropdown, DateTime dateStart, DateTime dateEnd, int noAdults, int noChildren)
        {
            string formattedStart = dateStart.ToString("yyyy-MM-dd");
            string formattedEnd = dateEnd.ToString("yyyy-MM-dd");
            List<Result> results = _hotelService.GetAllHotels(dropdown, formattedStart, formattedEnd, noAdults);

            List<AgentieDeTurismWeb.Models.ActivitiesAPI.Activity> activities = _hotelService.GetCountryActivities(dropdown);

            List<HotelViewModel> hotels = new List<HotelViewModel>();
            for (int i = 0; i < ShowIndex; i++)
            {
                string photoPath=_hotelService.GetHotelPhoto(results[i].hotel_id);
                HotelDescription description = _hotelService.GetHotelDescription(results[i].hotel_id);
                HotelViewModel hotel = new HotelViewModel()
                {
                    Result = results[i],
                    Photo = "https://cf.bstatic.com" + "/xdata" + photoPath,
                    Description = description.description,
                    Activities = activities
                };
                hotels.Add(hotel);
            }

            return View("Search", hotels);
        }

        public IActionResult OpenDetails(int id, string name, string photo, string description, double latitude, double longitude, string address)
        {
            List<HotelRooms> hotelRooms = _hotelService.GetAllRooms(id);
            RootWeather weather = _hotelService.GetCurrentWeather(latitude, longitude);

            HotelDetailViewModel hotelDetailViewModel = new HotelDetailViewModel()
            {
                HotelViewModel = new HotelViewModel()
                {
                    Result = new Result()
                    {
                        hotel_name = name,
                        latitude = latitude,
                        longitude = longitude,
                        address_trans = address
                    },
                    Description = description,
                    Photo = photo,
                    Weather = weather
                },
                Rooms = hotelRooms[0]
            };

            return View("Room", hotelDetailViewModel);
        }

        public IActionResult checkFlightOptions(string departureAirport, string arrivalAirport, DateTime dateStart, DateTime dateEnd, int noAdults)
        {
            string formattedStart = dateStart.ToString("yyyy-MM-dd");
            string formattedEnd = dateEnd.ToString("yyyy-MM-dd");
            List<Itinerary> itineraries = _flightService.GetAvailableFlights(departureAirport, arrivalAirport, formattedStart, formattedEnd, noAdults);
            ViewBag.itineraries = itineraries;
            return View("Flights", itineraries);
        }
    }
}