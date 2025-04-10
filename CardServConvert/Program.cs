using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
       .AddXmlSerializerFormatters();
builder.Services.AddSwaggerGen();

 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();              
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Configure the HTTP request pipeline.
 

 

app.Run();
