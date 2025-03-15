using ExamenU2_POO_ElkinBohorquez.Database;
using ExamenU2_POO_ElkinBohorquez.Helpers;
using ExamenU2_POO_ElkinBohorquez.Services;
using ExamenU2_POO_ElkinBohorquez.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ExamenDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddTransient<IEmpleadosService, EmpleadosService>();
builder.Services.AddTransient<IPlanillasService, PlanillasService>();
builder.Services.AddTransient<IDetallePlanillas, DetallePlanillasService>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
