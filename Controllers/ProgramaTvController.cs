using _2._web_API.Data;
using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2._web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProgramaTvController : ControllerBase
{
    private ProgramaTvContext _context;
    private IMapper _mapper;

    public ProgramaTvController(ProgramaTvContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarPrograma([FromBody] CreateProgramaTvDto programaDto)
    {
        ProgramaTv programa = _mapper.Map<ProgramaTv>(programaDto);
       
        _context.ProgramaTv.Add(programa);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscarProgramaId),
            new { id = programa.Id }, programa);
    }

    [HttpGet]
    public IEnumerable<ReadProgramaTvDto> BuscarPrograma([FromQuery] int skip = 0,
        int take = 50)
    {
        return  _mapper.Map<List<ReadProgramaTvDto>>(
            _context.ProgramaTv.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult BuscarProgramaId(int id)
    {
        var programa = _context.ProgramaTv.FirstOrDefault(programa
            => programa.Id == id);
        if(programa == null) return NotFound();
        var programaDto = _mapper.Map<ReadProgramaTvDto>(programa);
        return Ok(programa);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaPrograma(int id,
        [FromBody] UpdateProgramaTvDto programaDto)
    {
        var programa = _context.ProgramaTv.FirstOrDefault(
            programa => programa.Id == id);
        if (programa == null) return NotFound();
        _mapper.Map(programaDto, programa);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarProgramaPatch(int id,
        JsonPatchDocument<UpdateProgramaTvDto> patch)
    {
        var programa = _context.ProgramaTv.FirstOrDefault(
            programa => programa.Id == id);
        if (programa == null) return NotFound();

        var programaAtualizar = _mapper.Map<UpdateProgramaTvDto>(programa);

        patch.ApplyTo(programaAtualizar, ModelState);

        if (!TryValidateModel(programaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(programa, programaAtualizar);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePrograma(int id)
    {
        var programa = _context.ProgramaTv.FirstOrDefault(
            programa => programa.Id == id);
        if (programa == null) return NotFound();

        _context.Remove(programa);
        _context.SaveChanges();
        return NoContent(); 
    }
   
    
}
