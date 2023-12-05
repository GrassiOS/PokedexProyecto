using Microsoft.EntityFrameworkCore;
using Data;
using Business.Contracts;
using Business.Implementation;
using Data.Contracts;
using Data.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PokeDBContext>(options =>
    options.UseSqlServer("name=DefaultConnection"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IPokemonTypeService, PokemonTypeService>();
builder.Services.AddScoped<IPokemonTypeRepository, PokemonTypeRepository>();

builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

builder.Services.AddScoped<IPokemonMoveService, PokemonMoveService>();
builder.Services.AddScoped<IPokemonMoveRepository, PokemonMoveRepository>();

builder.Services.AddScoped<IBattleService, BattleService>();
builder.Services.AddScoped<IBattleRepository, BattleRepository>();

builder.Services.AddScoped<IBattleMoveService, BattleMoveService>();
builder.Services.AddScoped<IBattleMoveRepository, BattleMoveRepository>();

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

