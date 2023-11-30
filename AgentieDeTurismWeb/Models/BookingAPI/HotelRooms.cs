namespace AgentieDeTurismWeb.Models.BookingAPI
{
    public class HotelRooms
    {
        public string departure_date { get; set; }
        public string currency_code { get; set; }
        public int use_new_bui_icon_highlight { get; set; }
        public int address_required { get; set; }
        public int hotel_id { get; set; }
        public List<object> tax_exceptions { get; set; }
        public int duplicate_rates_removed { get; set; }
        public string cc_required { get; set; }
        public int last_matching_block_index { get; set; }
        public string cvc_required { get; set; }
        public int qualifies_for_no_cc_reservation { get; set; }
        public int max_rooms_in_reservation { get; set; }
        public Dictionary<string, Room> rooms { get; set; }
    }

}
