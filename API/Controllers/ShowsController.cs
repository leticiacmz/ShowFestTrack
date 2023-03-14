using Microsoft.AspNetCore.Mvc;
using ShowsAPI.Models;

namespace ShowsAPI.Controllers;
[ApiController]
[Route("[controller]")] 

public class ShowsController : Controller
{
    private static List<Show> shows = new List<Show>();

    [HttpPost]
    public void AdicionarShow([FromBody] Show show)
    {

        shows.Add(show);
    }
}

