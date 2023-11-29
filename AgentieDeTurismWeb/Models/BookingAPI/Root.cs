using System;

namespace AgentieDeTurismWeb.Models.BookingAPI
{
    public class Root
    {
        public string search_metadata { get; set; }
        public int count { get; set; }
        public string has_low_availability { get; set; }
        public int total_count_with_filters { get; set; }
        public int primary_count { get; set; }
        public int is_beach_ufi { get; set; }
        public int extended_count { get; set; }
        public List<object> applied_filters { get; set; }
        public int unfiltered_primary_count { get; set; }
        public int search_radius { get; set; }
        public List<string> copyright { get; set; }
        public int ranking_version { get; set; }
        public int unfiltered_count { get; set; }
        public string search_id { get; set; }
        public int page_loading_threshold { get; set; }
        public List<Result> result { get; set; }
    }
}
