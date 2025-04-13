using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Clear default logging providers and use NLog
builder.Logging.ClearProviders();
builder.Host.UseNLog();

// Add services to the container.

builder.Services.AddControllers()
       .AddXmlSerializerFormatters();
builder.Services.AddSwaggerGen();

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
