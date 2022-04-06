namespace Psyker.WebUI.Controllers;

using System.Diagnostics;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Psyker.Shared;
using Psyker.Shared.Commands;
using Psyker.WebUI.Models;

public class HomeController : Controller
{
    private readonly IBackgroundJobClient backgroundJobClient;
    private readonly ILogger<HomeController> logger;

    public HomeController(IBackgroundJobClient backgroundJobClient, ILogger<HomeController> logger)
        => (this.backgroundJobClient, this.logger) = (backgroundJobClient, logger);

    public IActionResult Index()
    {
        var command = new SendMessage
        {
            Id = Guid.NewGuid(),
            Payload = "Hello World!!!",
        };

        this.backgroundJobClient.Enqueue<MediatorHangfireBridge>(bridge => bridge.Send("send-message", command));
        return base.View();
    }

    public IActionResult Privacy()
    {
        return base.View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var viewModel = new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
        };
        return base.View(viewModel);
    }
}
