namespace AgentieDeTurismWeb.Models.BookingAPI
{
    public class Result
    {
        public int extended { get; set; }
        public int urgency_room_c { get; set; }
        public int soldout { get; set; }
        public int main_photo_id { get; set; }
        public string address { get; set; }
        public int is_free_cancellable { get; set; }
        public string default_wishlist_name { get; set; }
        public int hotel_id { get; set; }
        public PriceBreakdown price_breakdown { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string currency_code { get; set; }
        public double review_score { get; set; }
        public string hotel_name_trans { get; set; }
        public string zip { get; set; }
        public string distance { get; set; }
        public string type { get; set; }
        public int price_is_final { get; set; }
        public int is_city_center { get; set; }
        public string countrycode { get; set; }
        public object updated_checkout { get; set; }
        public int is_genius_deal { get; set; }
        public int accommodation_type { get; set; }
        public int children_not_allowed { get; set; }
        public int wishlist_count { get; set; }
        public string country_trans { get; set; }
        public string distance_to_cc { get; set; }
        public int is_smart_deal { get; set; }
        public string currencycode { get; set; }
        public string address_trans { get; set; }
        public string review_recommendation { get; set; }
        public string default_language { get; set; }
        public int cant_book { get; set; }
        public string accommodation_type_name { get; set; }
        public int ufi { get; set; }
        public string city_name_en { get; set; }
        public int cc_required { get; set; }
        public int hotel_include_breakfast { get; set; }
        public string city_in_trans { get; set; }
        public List<string> block_ids { get; set; }
        public int district_id { get; set; }
        public string url { get; set; }
        public string city { get; set; }
        public string timezone { get; set; }
        public string review_score_word { get; set; }
        public object is_geo_rate { get; set; }
        public object updated_checkin { get; set; }
        public int class_is_estimated { get; set; }
        public string main_photo_url { get; set; }
        public string hotel_name { get; set; }
        public string city_trans { get; set; }
        public object selected_review_topic { get; set; }
        public string id { get; set; }
        public string hotel_facilities { get; set; }
    }
}
