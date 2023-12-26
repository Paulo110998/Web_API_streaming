using _2._web_API.Data;
using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace _2._web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class SeriesController : ControllerBase
{
    private SeriesContext _context;
    private IMapper _mapper;

    public SeriesController(SeriesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarSerie([FromBody] CreateSeriesDto seriesDto)
    {
        Series serie = _mapper.Map<Series>(seriesDto);
        _context.Seriess.Add(serie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscarSeriePorId), 
            new { id = serie.Id }, serie);
    }

    [HttpGet]
    public IEnumerable<ReadSeriesDto> GetSeries([FromQuery] int skip = 0, int take = 5) 
    {
        return _mapper.Map<List<ReadSeriesDto>>(
            _context.Seriess.Skip(skip).Take(take));
        
    }

    [HttpGet("{id}")]
    public IActionResult BuscarSeriePorId(int id)
    {
        var serie = _context.Seriess.FirstOrDefault(serie => serie.Id == id);
        if (serie == null) return NotFound();
        var serieDto = _mapper.Map<ReadSeriesDto>(serie);
        return Ok(serie);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarSeries(int id,
        [FromBody] UpdateSeriesDto seriesDto)
    {
        var serie = _context.Seriess.FirstOrDefault(
            serie => serie.Id == id);
        if (serie == null) return NotFound();
        _mapper.Map(seriesDto, serie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarSeriePatch(int id,
        JsonPatchDocument<UpdateSeriesDto> patch)
    {
        var serie = _context.Seriess.FirstOrDefault(
            serie => serie.Id == id);
        if (serie == null) return NotFound();

        var serieAtualizar = _mapper.Map<UpdateSeriesDto>(serie);

        patch.ApplyTo(serieAtualizar, ModelState);

        if (!TryValidateModel(serieAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(serieAtualizar, serie);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteSerie(int id)
    {
        var serie = _context.Seriess.FirstOrDefault(
            serie => serie.Id == id);
        if (serie == null) return NotFound();

        _context.Remove(serie);
        _context.SaveChanges();
        return NoContent();
    }


}
