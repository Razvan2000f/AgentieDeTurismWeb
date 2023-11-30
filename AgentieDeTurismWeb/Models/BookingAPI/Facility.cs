namespace AgentieDeTurismWeb.Models.BookingAPI
{
    public class Facility
    {
        public int id { get; set; }
        public int facilitytype_id { get; set; }
        public string facilitytype_name { get; set; }
        public string name { get; set; }
        public int alt_facilitytype_id { get; set; }
        public string alt_facilitytype_name { get; set; }
    }
}
