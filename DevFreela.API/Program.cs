using DevFreela.API.Filters;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Validators;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DevFreelaDbContext> ( options => options.UseSqlServer ( builder.Configuration.GetConnectionString ( "DevFreelaCs" ) ) );

builder.Services.AddScoped<IProjectRepository, ProjectRepository> ( );
builder.Services.AddScoped<IUserRepository, UserRepository> ( );
builder.Services.AddScoped<ISkillRepository, SkillRepository> ( );
builder.Services.AddScoped<IAuthService, AuthService> ( );

builder.Services.AddMediatR ( cfg => cfg.RegisterServicesFromAssemblies ( typeof ( CreateProjectCommand ).Assembly ) );

builder.Services.AddControllers (options =>
{
    options.Filters.Add<ValidationFilter> ( );
} );
builder.Services.AddFluentValidationAutoValidation ( );
builder.Services.AddValidatorsFromAssemblyContaining<CreateProjectCommandValidator> ( );

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
