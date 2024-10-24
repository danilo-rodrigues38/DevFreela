using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Services.Implemantations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DevFreelaDbContext> ( options => options.UseSqlServer ( builder.Configuration.GetConnectionString ( "DevFreelaCs" ) ) );

builder.Services.AddMediatR ( cfg => cfg.RegisterServicesFromAssemblies ( typeof ( CreateProjectCommand ).Assembly ) );

builder.Services.AddControllers ( );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer ( );
builder.Services.AddSwaggerGen ( );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment ( ))
{
    app.UseSwagger ( );
    app.UseSwaggerUI ( );
}

app.UseHttpsRedirection ( );

app.UseAuthorization ( );

app.MapControllers ( );

app.Run ( );
