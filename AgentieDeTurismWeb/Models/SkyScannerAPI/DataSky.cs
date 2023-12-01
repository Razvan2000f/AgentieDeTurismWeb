namespace AgentieDeTurismWeb.Models.SkyScannerAPI
{
    public class DataSky
    {
        public string token { get; set; }
        //public Context context { get; set; }
        public List<Itinerary> itineraries { get; set; }
        public List<object> messages { get; set; }
        public string flightsSessionId { get; set; }
        public string destinationImageUrl { get; set; }
    }
}
