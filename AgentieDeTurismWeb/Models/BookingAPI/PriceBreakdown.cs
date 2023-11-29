namespace AgentieDeTurismWeb.Models.BookingAPI
{
    public class PriceBreakdown
    {
        public double all_inclusive_price { get; set; }
        public int has_fine_print_charges { get; set; }
        public string gross_price { get; set; }
        public string sum_excluded_raw { get; set; }
        public int has_tax_exceptions { get; set; }
        public string currency { get; set; }
        public int has_incalculable_charges { get; set; }
    }
}
