namespace AgentieDeTurismWeb.Models.BookingAPI
{
    public class Room
    {
        public string description { get; set; }
        public int private_bathroom_count { get; set; }
        public int is_high_floor_guaranteed { get; set; }
        public List<BedConfiguration> bed_configurations { get; set; }
        public List<Facility> facilities { get; set; }
    }
}
