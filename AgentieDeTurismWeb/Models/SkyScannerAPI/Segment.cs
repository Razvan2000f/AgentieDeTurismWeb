namespace AgentieDeTurismWeb.Models.SkyScannerAPI
{
    public class Segment
    {
        public string id { get; set; }
        public Airport origin { get; set; }
        public Airport destination { get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
        public int durationInMinutes { get; set; }
        public string flightNumber { get; set; }
       // public MarketingCarrier marketingCarrier { get; set; }
        //public OperatingCarrier operatingCarrier { get; set; }
    }
}
