using FlightTrackerApp.Models;
namespace FlightTrackerApp.Services;

public interface IDataProvider
{
    Task<List<DepartureModel>> GetDeparturesAsync(string airportIcao, DateTime from, DateTime to);
}
