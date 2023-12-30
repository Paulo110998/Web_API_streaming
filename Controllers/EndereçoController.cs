using _2._web_API.Data;
using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _2._web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EndereçoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public EndereçoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarEndereço([FromBody] CreateEndereçoDto endereçoDto)
        {
            Endereco endereço = _mapper.Map<Endereco>(endereçoDto);
            _context.Endereços.Add(endereço);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarEndereçoId), new { id = endereço.Id }, endereço);
        }

        [HttpGet]
        public IEnumerable<ReadEndereçoDto> BuscarEndereço()
        {
            return _mapper.Map<List<ReadEndereçoDto>>(_context.Endereços.ToList());

        }

        [HttpGet("{id}")]
        public IActionResult BuscarEndereçoId(int id)
        {
            Endereco endereço = _context.Endereços.FirstOrDefault(endereço 
                => endereço.Id == id);
            if (endereço != null)
            {
                ReadEndereçoDto endereçoDto = _mapper.Map<ReadEndereçoDto>(endereço);
                return Ok(endereçoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereço(int id, [FromBody] UpdateEndereçoDto endereçoDto)
        {
            Endereco endereço = _context.Endereços.FirstOrDefault(endereço => endereço.Id == id);
            if (endereço == null)
            {
                return NotFound();
            }
            _mapper.Map(endereçoDto, endereço);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
           Endereco endereço = _context.Endereços.FirstOrDefault(endereço => endereço.Id == id);
            if (endereço == null)
            {
                return NotFound();
            }
            _context.Remove(endereço);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
