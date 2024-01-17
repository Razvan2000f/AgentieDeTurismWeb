namespace AgentieDeTurismWeb.Models.BookingAPI
{
    public class PriceBreakdown
    {
        public double all_inclusive_price { get; set; }
        public int has_fine_print_charges { get; set; }
        public object gross_price { get; set; }
        public string currency { get; set; }
    }
}
