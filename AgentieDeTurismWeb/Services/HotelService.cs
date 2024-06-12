using AgentieDeTurismWeb.Models.ActivitiesAPI;
using AgentieDeTurismWeb.Models.BookingAPI;
using AgentieDeTurismWeb.Models.WeatherAPI;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.Metrics;
using System.IO;
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

        public List<Result> GetAllHotels(string country, string dateStart, string dateEnd, int noAdults)
        {
            List<Result> results = new List<Result>();
            Root root;
            //  string body = _httpService.CreateBookingAPIHotelRequest(country, dateStart, dateEnd, noAdults).Result;
            //  body = body.Replace("null", "0");

            using (StreamReader r = new StreamReader(_webHostEnvironment.WebRootPath + "\\input\\input.json"))
            {
                string json = r.ReadToEnd();
                root = JsonSerializer.Deserialize<Root>(json);
                results = root.result;
            }

            return results;
        }

        public string GetHotelPhoto(int hotel_id)
        {
            string path = "/properties/get-hotel-photos?hotel_ids=" + hotel_id;
            string body = _httpService.CreateBookingAPIRequest(path).Result;

            string[] photos = body.Split("\",\"/xdata");
            IEnumerable<string> enumerablePhotos = photos.Where(x => x.StartsWith("/images") && !x.Contains("\""));
            List<string> listPhotos = enumerablePhotos.ToList();

            return listPhotos[0];
        }

        public HotelDescription GetHotelDescription(int hotel_id)
        {
            string path = "/properties/get-description?hotel_ids=" + hotel_id;
            string body = _httpService.CreateBookingAPIRequest(path).Result;

            List<HotelDescription> descriptions;

            using (StreamReader r = new StreamReader(_webHostEnvironment.WebRootPath + "\\input\\description.json"))
            {
                string json = r.ReadToEnd();
                descriptions = JsonSerializer.Deserialize<List<HotelDescription>>(json);

            }


            return descriptions[0];
        }

        public List<HotelRooms> GetAllRooms(int id)
        {
            string path = "/properties/v2/get-rooms?hotel_id=" + id + "&departure_date=2024-6-23&arrival_date=2024-6-21&rec_guest_qty=2&rec_room_qty=1&currency_code=USD&languagecode=en-us&units=imperial";
            string body = _httpService.CreateBookingAPIRequest(path).Result;
            List<HotelRooms> hotelRooms = JsonSerializer.Deserialize<List<HotelRooms>>(body);
            return hotelRooms;
        }

        public RootWeather GetCurrentWeather(double latitude, double longitude)
        {
            string body = _httpService.CreateWeatherAPIRequest(latitude, longitude).Result;
            RootWeather weather = JsonSerializer.Deserialize<RootWeather>(body);

            return weather;
        }

        public List<Activity> GetCountryActivities(string country)
        {
            string body = _httpService.CreateTravelInfoAPIRequest(country).Result;
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
