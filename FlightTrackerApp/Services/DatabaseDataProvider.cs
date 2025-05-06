using FlightTrackerApp.Models;
namespace FlightTrackerApp.Services;

public class DatabaseDataProvider : IDataProvider
{
    public Task<List<DepartureModel>> GetDeparturesAsync(string airportIcao, DateTime from, DateTime to)
    {
        throw new NotImplementedException();
    }
}
