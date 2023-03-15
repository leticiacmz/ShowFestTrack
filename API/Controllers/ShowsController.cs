using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShowsAPI.Models;

namespace ShowsAPI.Controllers;
[ApiController]
[Route("[controller]")] 

public class ShowsController : Controller
{
    private static List<Show> shows = new List<Show>();
    private static int id = 0; 

    [HttpPost]
    public void AdicionarShow([FromBody] Show show)
    {
        show.Id = id++;
        shows.Add(show);
    }

    [HttpGet]
    public IEnumerable<Show> ListarShows()
    {
        return shows;
    }

    
}

