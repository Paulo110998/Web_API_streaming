using _2._web_API.Data;
using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _2._web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilController : ControllerBase
    {
        private UsuariosContext _context;
        private IMapper _mapper;

        public PerfilController(UsuariosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarPerfil([FromBody] CreatePerfilDto perfilDto)
        {
            Perfil perfil = _mapper.Map<Perfil>(perfilDto);
            _context.Perfis.Add(perfil);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarPerfisPorId),
                new { id = perfil.Id }, perfil);
        }

        [HttpGet]
        public IEnumerable<ReadPerfilDto> BuscarPerfis()
        {
            return _mapper.Map<List<ReadPerfilDto>>(
                _context.Perfis.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPerfisPorId(int id)
        {
            Perfil perfil = _context.Perfis.FirstOrDefault(
                perfil => perfil.Id == id);

            if (perfil != null)
            {
                ReadPerfilDto perfilDto = _mapper.Map<ReadPerfilDto>(perfil);
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPerfil(int id, [FromBody] UpdatePerfilDto perfilDto)
        {
            Perfil perfil = _context.Perfis.FirstOrDefault(
                perfil => perfil.Id == id);
            if (perfil == null)
            {
                return NotFound();
            }
            _mapper.Map(perfilDto, perfil);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPlano(int id)
        {
            Perfil perfil = _context.Perfis.FirstOrDefault(
                perfil => perfil.Id == id);
            if (perfil == null)
            {
                return NotFound();
            }
            _context.Remove(perfil);
            _context.SaveChanges();
            return NoContent();


        }

    }
}
