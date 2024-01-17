using AgentieDeTurismWeb.Models.BookingAPI;
using AgentieDeTurismWeb.Models.SkyScannerAPI;
using System.Text.Json;

namespace AgentieDeTurismWeb.Services
{
    public class HttpService
    {
        private readonly string _bookingHost = "apidojo-booking-v1.p.rapidapi.com";
        private readonly string _skyscannerHost = "sky-scrapper1.p.rapidapi.com";
        private readonly string _weatherHost = "weatherapi-com.p.rapidapi.com";
        private readonly string _travelInfoHost = "travel-info-api.p.rapidapi.com";
        private async Task<string> CreateNewRequest(string host, string path)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://" + host + path),
                Headers =
                {
                    { "X-RapidAPI-Key", "513f0e999fmshb1bcb7de96db259p1e0c0ajsn4b4dd94a8dd9" },
                    { "X-RapidAPI-Host", host },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

        public Task<string> CreateBookingAPIHotelRequest(string location, string dateStart, string dateEnd, int noAdults)
        {
            string pathCountry = "/locations/auto-complete?text=" + location + "&languagecode=en-us";
            string json = CreateNewRequest(_bookingHost, pathCountry).Result;

            List<Location> locations = JsonSerializer.Deserialize<List<Location>>(json);

            string dest_id = locations[0].dest_id;
            string path = "/properties/list?offset=0&arrival_date="+dateStart+"&departure_date="+dateEnd+"&guest_qty="+noAdults+"&dest_ids=" + dest_id + "&room_qty=1&search_type=city&children_qty=2&children_age=5%2C7&search_id=none&price_filter_currencycode=USD&order_by=popularity&languagecode=en-us&travel_purpose=leisure";

            return CreateNewRequest(_bookingHost, path);
        }

        public Task<string> CreateBookingAPIRequest(string path)
        {
            return CreateNewRequest(_bookingHost, path);
        }

        public Task<string> CreateSkyScannerAPI(string from, string to, string startDate, string endDate, int noAdults)
        {
            string fromAirport = "/api/v1/flights/searchAirport?query=" + from + "&currency=USD&market=US&locale=en-US";
            string toAirport = "/api/v1/flights/searchAirport?query=" + to + "&currency=USD&market=US&locale=en-US";

            string json = CreateNewRequest(_skyscannerHost, fromAirport).Result;
            RootAirport fromAir = JsonSerializer.Deserialize<RootAirport>(json);
            string fromId = fromAir.data[0].id;

            json = CreateNewRequest(_skyscannerHost, toAirport).Result;
            RootAirport toAir = JsonSerializer.Deserialize<RootAirport>(json);
            string toId = toAir.data[0].id;

            string path = "/api/v1/flights/searchFlights?fromId=" + fromId + "&toId=" + toId + "&date="+startDate+"&returnDate="+endDate+"&adults="+noAdults+"&currency=USD&market=US&locale=en-US";

            return CreateNewRequest(_skyscannerHost, path);
        }

        public Task<string> CreateWeatherAPIRequest(double latitude, double longitude)
        {
            string path = "/forecast.json?q=" + latitude + "%2C" + longitude + "&days=3";
            return CreateNewRequest(_weatherHost, path);
        }

        public Task<string> CreateTravelInfoAPIRequest(string country)
        {
            string path = "/country-activities?country=" + country;
            return CreateNewRequest(_travelInfoHost, path);
        }
    }
}
