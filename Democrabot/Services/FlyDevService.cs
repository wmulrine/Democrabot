namespace Democrabot.Services
{
    internal interface IFlyDevService
    {
        Task<string> GetCurrentSeason();
    };
    internal class FlyDevService : IFlyDevService
    {
        private readonly HttpClient _client;
        private readonly Uri _baseUrl;

        public FlyDevService(HttpClient client)
        {
            if (client.BaseAddress != null)
                _baseUrl = client.BaseAddress;
            else
                throw new ApplicationException("Invalid Configuration for FlyDevClient");
            _client = client;
        }

        public async Task<string> GetCurrentSeason()
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri($"{_baseUrl}/api"),
                Method = HttpMethod.Get,
            };

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            HellDiversApiDto dtoObject = await response.Content.ReadAsAsync<HellDiversApiDto>();
            return dtoObject.current;
        }
    }
}
