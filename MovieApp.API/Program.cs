using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieApp.API.Data;
using MovieApp.API.DTOs;
using MovieApp.API.Repositories;
using MovieApp.API.Repositories.Interfaces;
using MovieApp.API.Services;
using MovieApp.API.Services.Interfaces;
using MovieApp.API.Validators;

var builder = WebApplication.CreateBuilder(args);

//DbContext con PostgreSQL (Requiere instalar el paquete NuGet Npgsql.EntityFrameworkCore.PostgreSQL):
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<MovieCreateValidator>();


//Registro manual de DTOs y Validadores:
//CREATE MOVIE:
builder.Services.AddScoped<IValidator<MovieCreateDto>, MovieCreateValidator>();
//UPDATE MOVIE:
builder.Services.AddScoped<IValidator<MovieUpdateDto>, MovieUpdateValidator>();
//CREATE ACTOR:
builder.Services.AddScoped<IValidator<ActorCreateDto>, ActorCreateValidator>();
//UPDATE ACTOR:
builder.Services.AddScoped<IValidator<ActorUpdateDto>, ActorUpdateValidator>();



//Registro manual de Repositories - Interfaces:
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();


//Registro manual de Services
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IActorService, ActorService>();

//Registro de AutoMapper
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

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
