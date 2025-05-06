namespace FlightTrackerApp.Models;

public class DepartureRequestModel
{
    public string AirportIcao { get; set; } = "LKPR";
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}
