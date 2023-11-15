using Microsoft.EntityFrameworkCore;
using PruebaTecnica_DVP_FMGS.API.InfraEstructura.Contratos;
using PruebaTecnica_DVP_FMGS.API.InfraEstructura.Repositorios;
using PruebaTecnica_DVP_FMGS.DA.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DVPContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DVP"]);
});
builder.Services.AddScoped<ITipoIdentificacionRepository, TipoIdentificacionRepository>();
builder.Services.AddScoped<ICuentaRepository, CuentaRepository>();
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
