// dotnet add package Microsoft.AspNetnetCore.Cors -> para agregar la función de los cors

using ElevenNotesBackEnd.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregamos nuevos servicios Controller
builder.Services.AddControllers();

// Agregamos los cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod());
});

//Ruta de la base de datos 
builder.Services.AddDbContext<ElevenContext>(Options =>
    Options.UseMySql
    (
        builder.Configuration.GetConnectionString("ElevenContext"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
    )
);

var app = builder.Build();

app.UseCors("AllowAnyOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapeamos todos los servicios necesarios
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
