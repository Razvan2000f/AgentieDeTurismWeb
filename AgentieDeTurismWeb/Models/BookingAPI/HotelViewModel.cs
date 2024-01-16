using AgentieDeTurismWeb.Models.ActivitiesAPI;
using AgentieDeTurismWeb.Models.WeatherAPI;

namespace AgentieDeTurismWeb.Models.BookingAPI
{
    public class HotelViewModel
    {
        public Result Result { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public RootWeather Weather { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
