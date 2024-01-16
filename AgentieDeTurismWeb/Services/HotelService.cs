using AgentieDeTurismWeb.Models.ActivitiesAPI;
using AgentieDeTurismWeb.Models.BookingAPI;
using AgentieDeTurismWeb.Models.WeatherAPI;
using System.Text.Json;

namespace AgentieDeTurismWeb.Services
{
    public class HotelService
    {
        public IWebHostEnvironment _webHostEnvironment;
        public HotelService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public List<Result> GetAllHotels(DateTime dateStart, DateTime dateEnd, int noAdults, int noChildren)
        {
            List<Result> results = new List<Result>();
            using (StreamReader r = new StreamReader(_webHostEnvironment.WebRootPath + "\\input\\input.json"))
            {
                string json = r.ReadToEnd();
                Root root = JsonSerializer.Deserialize<Root>(json);
                results = root.result;
            }
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
