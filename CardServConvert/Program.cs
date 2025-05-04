using CardServConvert;
using Microsoft.OpenApi.Models;
using NLog.Web;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Clear default logging providers and use NLog
builder.Logging.ClearProviders();
builder.Host.UseNLog();

// Add services to the container.


// Add services to the container
builder.Services.AddControllers(options =>
{
    // Insert the custom formatter to handle text/plain
    options.InputFormatters.Insert(0, new PlainTextInputFormatter());
});


builder.Services.AddSwaggerGen(opt =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);
 
});
 

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
       policy =>
       {
           policy.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
       });
});



var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAll");

if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();







app.Run();
