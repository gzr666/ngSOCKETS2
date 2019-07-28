using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

[Route("api/[controller]")]
public class ChartController : Controller
{
    private IHubContext<ChartHub> _hub;

    public ChartController(IHubContext<ChartHub> hub)
    {

        _hub = hub;

    }

    public IActionResult Get()
    {
        var timerManager = new TimerManager(()=>{

            _hub.Clients.All.SendAsync("transferchartdata",DataManager.GetData());

        });

        return Ok(new {Message="request competed"});

    }


}