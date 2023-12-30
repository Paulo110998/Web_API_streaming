using Microsoft.AspNetCore.Mvc;
using _2._web_API.Models;
using System.Collections.Immutable;
using _2._web_API.Data;
using _2._web_API.Data.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace _2._web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmesController : ControllerBase
{
    // Criando um campo privado com o contexto de banco de dados
    private FilmeContext _context;
    private IMapper _mapper;

    //criando um construtor pro controlador
    public FilmesController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Adiciona um filma ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objetos com campos necessários 
    /// para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a inserção seja feita com sucesso.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto) 
    {
        // Utilizando o AutoMapper para o mapeamento
        Filme filme = _mapper.Map<Filme>(filmeDto);
         // Adicionando filmes através da prop 'Filmes' (FilmeContext)
        _context.Filmes.Add(filme); 
         // Salvando no banco
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscarFilmesId), 
            new { id = filme.Id }, filme);

    }
    // Exibindo a lista de filmes 
    [HttpGet]
    public IEnumerable<ReadFilmeDto> ExibirFilmes() 
    {
        // Atualizando a consulta de todos os objetos com ReadFilmeDto
        return _mapper.Map<List<ReadFilmeDto>>(
            _context.Filmes.ToList());   
    }

    // Exibindo filmes por id
    [HttpGet("{id}")]
    public IActionResult BuscarFilmesId(int id)
    {
        var filme =  _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        // Adicionando consulta 
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    // Método para atualizar filmes (PUT)
    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id, 
        [FromBody] UpdateFilmeDto filmeDto) 
    {
        // Recuperando o filme através do ID
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if(filme == null) return NotFound();
        // Atualizando as novas informações com mapeamento
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        // status de sucesso 204 No Content
        return NoContent();
    }

    // Método para atualização parcial (PATCH)
    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id,
        JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();

        // Convertendo o filme para um Tipo "UpdateFilmeDto"
        var filmeAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        // Se oque tem aplicado conter um modelo de estado (model)
        patch.ApplyTo(filmeAtualizar, ModelState);

        // Se não for valido
        if (!TryValidateModel(filmeAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        
        // Se for valido
        _mapper.Map(filmeAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    // Método para deletar o objeto através do ID
    [HttpDelete("{id}")]
    public IActionResult DetelaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();

        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
