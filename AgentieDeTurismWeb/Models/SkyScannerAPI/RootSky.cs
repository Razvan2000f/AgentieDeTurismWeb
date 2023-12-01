namespace AgentieDeTurismWeb.Models.SkyScannerAPI
{
    public class RootSky
    {
        public bool status { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
        public DataSky data { get; set; }
    }
}
