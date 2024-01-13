namespace AgentieDeTurismWeb.Models.SkyScannerAPI
{
    public class Carrier
    {
        public int id { get; set; }
        public string logoUrl { get; set; }
        public string name { get; set; }
        public List<Marketing> marketing { get; set; }
        public string operationType { get; set; }
    }
}
