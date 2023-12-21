using _2._web_API.Data;
using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace _2._web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuariosController : ControllerBase
{
    private UsuariosContext _context;
    private IMapper _mapper;

    public UsuariosController(UsuariosContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastrarUsuario([FromBody] CreateUsuariosDto usuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscarUserId),
            new { id = usuario.Id }, usuario);
    }

    [HttpGet]
    public IEnumerable<Usuario> BuscarUsers([FromQuery] int skip = 0,
        int take = 50) 
    {
        return _context.Usuarios.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarUserId(int id)
    {
        var usuarios = _context.Usuarios.FirstOrDefault(usuarios => usuarios.Id == id);
        if (usuarios == null) return NotFound();
        return Ok(usuarios);

    }

    [HttpPut("{id}")]
    public IActionResult AtualizarUsuario(int id,
        [FromBody] UpdateUsuariosDto usuariosDto)
    {
        var usuario = _context.Usuarios.FirstOrDefault(
            usuario => usuario.Id == id);
        if(usuario == null) return NotFound();
        _mapper.Map(usuariosDto, usuario);
        _context.SaveChanges();
        return NoContent();
    }

}
