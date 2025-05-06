using FlightTrackerApp.Models;
namespace FlightTrackerApp.Services;

public class ExcelDataProvider : IDataProvider
{
    public Task<List<DepartureModel>> GetDeparturesAsync(string airportIcao, DateTime from, DateTime to)
    {
        throw new NotImplementedException();
    }
}
