namespace Psyker.WebUI.Controllers;

using System.Diagnostics;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Psyker.Shared;
using Psyker.Shared.Commands;
using Psyker.WebUI.Models;

public sealed class HomeController : Controller
{
    private readonly IBackgroundJobClient backgroundJobClient;
    private readonly IStringLocalizer<HomeController> localizer;
    private readonly ILogger<HomeController> logger;

    public HomeController(IBackgroundJobClient backgroundJobClient, IStringLocalizer<HomeController> localizer, ILogger<HomeController> logger)
        => (this.backgroundJobClient, this.localizer, this.logger) = (backgroundJobClient, localizer, logger);

    public IActionResult Index()
    {
        var title = localizer["Title"];

        var command = new SendMessage
        {
            Id = Guid.NewGuid(),
            Payload = "Hello World!!!",
        };

        this.logger.LogInformation($"Processing '{nameof(Index)}' request");
        this.backgroundJobClient.Enqueue<MediatRHangfireBridge>(bridge => bridge.Send("send-message", command));

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
