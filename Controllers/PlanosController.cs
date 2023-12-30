using _2._web_API.Data;
using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _2._web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanosController : ControllerBase
    {
        private UsuariosContext _context;
        private IMapper _mapper;

        public PlanosController(UsuariosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarPlanos([FromBody] CreatePlanosDto planosDto)
        {
            Planos planos = _mapper.Map<Planos>(planosDto);
            _context.Planos.Add(planos);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarPlanosPorId), 
                new { id = planos.Id }, planos);
        }

        [HttpGet]
        public IEnumerable<ReadPlanosDto> BuscarPlanos([FromQuery] int skip=0, int take=50)
        {
            return _mapper.Map<List<ReadPlanosDto>>(_context.Planos.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPlanosPorId(int id)
        {
            Planos plano = _context.Planos.FirstOrDefault(
                plano => plano.Id == id);

            if(plano != null)
            {
                ReadPlanosDto planosDto = _mapper.Map<ReadPlanosDto>(plano);
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPlanos(int id, [FromBody] UpdatePlanosDto planosDto)
        {
            Planos plano = _context.Planos.FirstOrDefault(
                plano => plano.Id == id);
            if (plano == null)
            {
                return NotFound();
            }
            _mapper.Map(planosDto, plano);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPlano(int id)
        {
            Planos plano = _context.Planos.FirstOrDefault(
                plano => plano.Id == id);
            if(plano == null)
            {
                return NotFound();
            }
            _context.Remove(plano);
            _context.SaveChanges();
            return NoContent();

            
        }
       
    }
}
