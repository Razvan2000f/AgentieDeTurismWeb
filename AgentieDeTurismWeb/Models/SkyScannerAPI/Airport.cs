namespace AgentieDeTurismWeb.Models.SkyScannerAPI
{
    public class Airport
    {
        public string id { get; set; }
        public string name { get; set; }
        public string displayCode { get; set; }
        public string city { get; set; }
        public bool isHighlighted { get; set; }
        public string flightPlaceId { get; set; }
        public string type { get; set; }
    }
}
