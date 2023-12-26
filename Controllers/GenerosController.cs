using Microsoft.AspNetCore.Mvc;
using _2._web_API.Models;
using _2._web_API.Data;
using AutoMapper;
using _2._web_API.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace _2._web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class GenerosController : ControllerBase
{
    private GeneroContext _context;
    private IMapper _mapper;

    public GenerosController(GeneroContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    
    /// <summary>
    /// Adiciona gênero
    /// </summary>
    /// <param name="generoDto">Objetos com campos necessários</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a inserção seja feita com sucesso.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarGenero([FromBody] CreateGeneroDto generoDto)
    {
        Genero genero = _mapper.Map<Genero>(generoDto);
        _context.Generos.Add(genero);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ExibirGenerosId),
            new { id = genero.Id }, genero);
    }

    [HttpGet]
    public IEnumerable<ReadGeneroDto> GetGeneros([FromQuery] int skip = 0,
        int take = 20)
    {
        return _mapper.Map<List<ReadGeneroDto>>(_context.Generos.Skip(skip).Take(take));
        
    }

    [HttpGet("{id}")]
    public IActionResult ExibirGenerosId(int id)
    {
        var genero = _context.Generos.FirstOrDefault(genero => genero.Id == id);
        if (genero == null) return NotFound();
        var generoDto = _mapper.Map<ReadGeneroDto>(genero);
        return Ok(genero);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarGenero(int id,
        [FromBody] UpdateGeneroDto generoDto)
    {
        var genero = _context.Generos.FirstOrDefault(
            genero => genero.Id == id);
        if(genero == null) return NotFound();
        _mapper.Map(generoDto, genero);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarGeneroPatch(int id,
        JsonPatchDocument<UpdateGeneroDto> patch)
    {
        var genero = _context.Generos.FirstOrDefault(
            genero => genero.Id == id);
        if (genero == null) return NotFound();

        var generoAtualizar = _mapper.Map<UpdateGeneroDto>(genero);

        patch.ApplyTo(generoAtualizar, ModelState);

        if (!TryValidateModel(generoAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(generoAtualizar, genero);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarGenero(int id)
    {
        var genero = _context.Generos.FirstOrDefault(
            genero => genero.Id == id);
        if (genero == null) return NotFound();

        _context.Remove(genero);
        _context.SaveChanges();
        return NoContent();
    }
}
