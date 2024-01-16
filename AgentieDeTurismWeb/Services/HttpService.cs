namespace AgentieDeTurismWeb.Services
{
    public class HttpService
    {
        private string _bookingHost = "apidojo-booking-v1.p.rapidapi.com";
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
                Console.WriteLine(body);
                return body;
            }
        }

        public Task<string> CreateBookingAPIRequest(string path)
        {
            return CreateNewRequest(_bookingHost, path);
        }
    }
}
