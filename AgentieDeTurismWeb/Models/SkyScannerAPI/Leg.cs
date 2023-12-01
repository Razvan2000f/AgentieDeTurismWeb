using System.Threading;

namespace AgentieDeTurismWeb.Models.SkyScannerAPI
{
    public class Leg
    {
        public string id { get; set; }
        public Airport origin { get; set; }
        public Airport destination { get; set; }
        public int durationInMinutes { get; set; }
        public int stopCount { get; set; }
        public bool isSmallestStops { get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
        public int timeDeltaInDays { get; set; }
        public Carrier carriers { get; set; }
        public List<Segment> segments { get; set; }
    }
}
