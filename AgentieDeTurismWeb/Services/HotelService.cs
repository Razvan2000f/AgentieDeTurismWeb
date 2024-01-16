using AgentieDeTurismWeb.Models.ActivitiesAPI;
using AgentieDeTurismWeb.Models.BookingAPI;
using AgentieDeTurismWeb.Models.WeatherAPI;
using System.Text.Json;

namespace AgentieDeTurismWeb.Services
{
    public class HotelService
    {
        public IWebHostEnvironment _webHostEnvironment;
        private HttpService _httpService;
        public HotelService(IWebHostEnvironment webHostEnvironment, HttpService httpService)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpService = httpService;
        }

        public List<Result> GetAllHotels(DateTime dateStart, DateTime dateEnd, int noAdults, int noChildren)
        {
            List<Result> results = new List<Result>();

            string path = "/properties/list?offset=0&arrival_date=2024-1-21&departure_date=2024-1-24&guest_qty=2&dest_ids=-3712125&room_qty=1&search_type=city&children_qty=2&children_age=5%2C7&search_id=none&price_filter_currencycode=USD&order_by=popularity&languagecode=en-us&travel_purpose=leisure";
            string body=_httpService.CreateBookingAPIRequest(path).Result;
            Root root=JsonSerializer.Deserialize<Root>(body);
            results = root.result;
            //using (StreamReader r = new StreamReader(_webHostEnvironment.WebRootPath + "\\input\\input.json"))
            //{
            //    string json = r.ReadToEnd();
            //    Root root = JsonSerializer.Deserialize<Root>(json);
            //    results = root.result;
            //}
            return results;
        }

        public HotelDescription GetHotelDescription()
        {
            HotelDescription description = new HotelDescription();
            using (StreamReader r = new StreamReader(_webHostEnvironment.WebRootPath + "\\input\\description.json"))
            {
                string json = r.ReadToEnd();
                List<HotelDescription> descriptions = JsonSerializer.Deserialize<List<HotelDescription>>(json);
                description = descriptions[1];
            }
            return description;
        }

        public List<HotelRooms> GetAllRooms(int id)
        {
            List<HotelRooms> hotelRooms = new List<HotelRooms>();
            using (StreamReader r = new StreamReader(_webHostEnvironment.WebRootPath + "\\input\\rooms.json"))
            {
                string json = r.ReadToEnd();
                hotelRooms = JsonSerializer.Deserialize<List<HotelRooms>>(json);
            }
            return hotelRooms;
        }

        public RootWeather GetCurrentWeather(double longitude, double latitude)
        {
            RootWeather weather;

            using (StreamReader r = new StreamReader(_webHostEnvironment.WebRootPath + "\\input\\weather.json"))
            {
                string json = r.ReadToEnd();
                weather = JsonSerializer.Deserialize<RootWeather>(json);
            }

            return weather;
        }

        public List<Activity> GetCountryActivities(string country)
        {
            RootActivities activities;

            using (StreamReader r = new StreamReader(_webHostEnvironment.WebRootPath + "\\input\\activities.json"))
            {
                string json = r.ReadToEnd();
                activities = JsonSerializer.Deserialize<RootActivities>(json);
            }

            return activities.data.activities;
        }
    }
}
