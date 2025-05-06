using FlightTrackerApp.Models;
using FlightTrackerApp.Services;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

public class OpenSkyAPI : IDataProvider
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;
    public OpenSkyAPI(HttpClient httpClient, IMemoryCache cache)
    {
        _httpClient = httpClient;
        _cache = cache;
    }

    public async Task<List<DepartureModel>> GetDeparturesAsync(string airportIcao, DateTime from, DateTime to)
    {
        string cacheKey = $"departures_{airportIcao}_{from:yyyyMMddHHmm}_{to:yyyyMMddHHmm}";

        if (_cache.TryGetValue(cacheKey, out List<DepartureModel> cachedDepartures))
        {
            return cachedDepartures;
        }

        long begin = ((DateTimeOffset)from).ToUnixTimeSeconds();
        long end = ((DateTimeOffset)to).ToUnixTimeSeconds();

        string url = $"https://opensky-network.org/api/flights/departure?airport={airportIcao}&begin={begin}&end={end}";

        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return new List<DepartureModel>();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<List<DepartureModel>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new List<DepartureModel>();

        _cache.Set(cacheKey, result, TimeSpan.FromHours(1));

        return result.OrderByDescending(x => x.FirstSeenDateTime).ToList();
    }
}

