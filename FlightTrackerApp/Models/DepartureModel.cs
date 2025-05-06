namespace FlightTrackerApp.Models;
public class DepartureModel
{
    public string Icao24 { get; set; }
    public long FirstSeen { get; set; }
    public string EstDepartureAirport { get; set; }
    public long LastSeen { get; set; }
    public string EstArrivalAirport { get; set; }
    public string Callsign { get; set; } 
    public DateTime FirstSeenDateTime => DateTimeOffset.FromUnixTimeSeconds(FirstSeen).DateTime;
    public DateTime LastSeenDateTime => DateTimeOffset.FromUnixTimeSeconds(LastSeen).DateTime;

}