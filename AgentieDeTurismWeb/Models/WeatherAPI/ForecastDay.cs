namespace AgentieDeTurismWeb.Models.WeatherAPI
{
    public class Forecastday
    {
        public string date { get; set; }
        public int date_epoch { get; set; }
        public Day day { get; set; }
    }
}
