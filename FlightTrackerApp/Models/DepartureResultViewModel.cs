namespace FlightTrackerApp.Models;

public class DepartureResultViewModel
{
    public DepartureRequestModel Request { get; set; }
    public List<DepartureModel> Departures { get; set; }
}
