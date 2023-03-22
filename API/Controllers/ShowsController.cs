using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
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

    [HttpGet("{artista}")]
    public async Task<IActionResult> RecuperaShowPorArtista(string artista)
    {
        var show = await shows.AsQueryable().FirstOrDefaultAsync(show => show.Artista == artista);

        if (show == null)
        {
            return NotFound();
        }

        return Ok(new { Show = show });
    }

    [HttpPost("Artistas")]
    public IActionResult AdicionarArtista([FromBody] string artista)
    {
        if (shows.Any(s => s.Artista == artista))
        {
            return Conflict(new { Message = "Já existe um artista cadastrado com este nome." });
        }

        shows.Add(new Show { Artista = artista });

        return Ok(new { Message = "Artista adicionado com sucesso." });
    }

    [HttpGet("Artistas")]
    public IActionResult ListarArtistas()
    {
        var artistas = shows.Select(s => s.Artista).Distinct();

        return Ok(new { Artistas = artistas });
    }
}