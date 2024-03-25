using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace FilmesApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FilmeController : ControllerBase
{
   private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("RecuperarFilmes")]
    public IEnumerable<ReadFilmesDto> RecuperarFilmes
        ([FromQuery] int skip = 0,
        [FromQuery] int take = 50,
        [FromQuery] string? nomeCinema = null)
    {
        if(nomeCinema == null)
        {
            return _mapper.Map<List<ReadFilmesDto>>
                (_context.Filmes.Skip(skip).Take(take).ToList());
        }

        return _mapper.Map<List<ReadFilmesDto>>(_context.Filmes.Skip(skip)
            .Take(take).Where(filme => filme.Sessaos.Any(sessao
                => sessao.Cinema.Nome == nomeCinema)));

    }

    [HttpGet("{id}")]
    public IActionResult RecuperarFilmesId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmesDto>(filme);
        return Ok(filmeDto);
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto"></param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Casa inserção seja feita com sucesso</response>

    [HttpPost("AdicionaFilme")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody]CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme); 
        _context.SaveChanges();
       return CreatedAtAction(nameof(RecuperarFilmesId), 
           new { id = filme.Id },
            filme);      
        
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody]
    UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme=> filme.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto,filme );
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaCampo(int id, 
        JsonPatchDocument<UpdateFilmeDto>patch)
        
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme=> filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }


        _mapper.Map(filmeParaAtualizar, filme );
        _context.SaveChanges();
        return NoContent();

    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme=> filme.Id == id);
        if(filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
