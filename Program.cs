using _2._web_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text;
using System;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Buscando a connection do appsettings.json e adicionando o contexto.

// Filmes
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection"); 

builder.Services.AddDbContext<FilmeContext>(options => 
options.UseLazyLoadingProxies().UseMySql(connectionString, 
ServerVersion.AutoDetect(connectionString)));

// Séries
var connectionStringSeries = builder.Configuration.GetConnectionString("SeriesConnection");

builder.Services.AddDbContext<SeriesContext>(options =>
options.UseLazyLoadingProxies().UseMySql(connectionStringSeries,
ServerVersion.AutoDetect(connectionStringSeries)));

// Generos
var connectionStringGenero = builder.Configuration.GetConnectionString("GeneroConnection");

builder.Services.AddDbContext<GeneroContext>(options_genero
    => options_genero.UseLazyLoadingProxies().UseMySql(connectionStringGenero, 
    ServerVersion.AutoDetect(connectionStringGenero)));

// Usuarios
var connectionStringUsuario = builder.Configuration.GetConnectionString("UsuariosConnection");

builder.Services.AddDbContext<UsuariosContext>(options_users
    => options_users.UseLazyLoadingProxies().UseMySql(connectionStringUsuario, ServerVersion.AutoDetect(connectionStringUsuario)));


// ProgramaTv
var connectionStringTv = builder.Configuration.GetConnectionString("ProgramaTvConnection");

builder.Services.AddDbContext<ProgramaTvContext>(options_tv
    => options_tv.UseLazyLoadingProxies().UseMySql(connectionStringTv, ServerVersion.AutoDetect(connectionStringTv)));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Swagger Documentation
builder.Services.AddSwaggerGen(c =>
{
    // Definindo a informação da API, nome e versão v1
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "2.web_API", Version = "v1" });
    
    // Escrevendo arquivo xml com libs internas para gerar através do contexto
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    // Definindo um caminho baseado no arquivo xlm, com o BaseDirectory
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    // Permitindo a execução de comentários XML
    c.IncludeXmlComments(xmlPath);
});


var app = builder.Build();


app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
