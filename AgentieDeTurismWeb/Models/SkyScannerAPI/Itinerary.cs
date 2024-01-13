using System.IO;

namespace AgentieDeTurismWeb.Models.SkyScannerAPI
{
    public class Itinerary
    {
        public string id { get; set; }
        public Price price { get; set; }
        public List<Leg> legs { get; set; }
        public bool isSelfTransfer { get; set; }
        public bool isProtectedSelfTransfer { get; set; }
       // public FarePolicy farePolicy { get; set; }
        public List<string> tags { get; set; }
        public bool isMashUp { get; set; }
        public bool hasFlexibleOptions { get; set; }
        public double score { get; set; }
    }
}
