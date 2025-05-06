using FlightTrackerApp.Models;
using FlightTrackerApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace FlightTrackerApp.Controllers;

public class FlightsController : Controller
{
    private readonly IDataProvider _provider;

    public FlightsController(IDataProvider provider)
    {
        _provider = provider;
    }

    [HttpGet]
    public IActionResult DepartureForm()
    {
        return View(new DepartureRequestModel
        {
            From = DateTime.UtcNow.Date,
            To = DateTime.UtcNow.Date,
        });
    }
    [HttpPost]
    public async Task<IActionResult> GetDepartures(DepartureRequestModel model)
    {
        var from = model.From.ToUniversalTime();
        var to = model.To.ToUniversalTime();

        var departures = await _provider.GetDeparturesAsync(model.AirportIcao, from, to);

        var viewModel = new DepartureResultViewModel
        {
            Request = model,
            Departures = departures
        };

        return View("Departures", viewModel);
    }
}
