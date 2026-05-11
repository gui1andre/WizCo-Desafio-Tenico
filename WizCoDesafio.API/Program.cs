using Scalar.AspNetCore;
using WizCoDesafio.API.MIddleware;
using WizCoDesafio.Application;
using WizCoDesafio.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddOpenApi();


var app = builder.Build();


app.UseMiddleware<ExceptionHadnleMiddleware>();


if (app.Environment.IsDevelopment()) 
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
