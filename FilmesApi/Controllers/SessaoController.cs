using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessaos.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaosPorId), new {filmeId =
                sessao.FilmeId, CinemaId = sessao.CinemaId },
                sessao);
        }


        [HttpGet]
        public IEnumerable<ReadSessaoDto> RecuperaSessaos()
        {
            return _mapper.Map<List<ReadSessaoDto>>(_context.Sessaos.ToList());
        }

        [HttpGet("{filmeId}/{cinemaId}")]
        public IActionResult RecuperaSessaosPorId(int filmeId,int cinemaId)
        {
            Sessao sessao = _context.Sessaos.FirstOrDefault(sessao => 
            sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId );
            if(sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return Ok(sessaoDto);
            }

            return NotFound();
        }

    }
}
