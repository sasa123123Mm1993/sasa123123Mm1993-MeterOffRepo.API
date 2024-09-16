using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using MeterOff.EF;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Identity;
using MeterOff.EF.Services;
using MeterOff.API;

var builder = WebApplication.CreateBuilder(args);

//Using Lazy Loading
builder.Services.AddDbContext<DBContext>(options =>
options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Add services to the container.

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddEntityFrameworkStores<DBContext>()
    .AddDefaultTokenProviders();

//Add Dapper Service
builder.Services.AddSingleton<DapperContext>();




#region Jwt
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});
#endregion

#region Inject app Dependencies (Dependency Injection)
builder.Services.AddScoped<IMeterOffReasonsRepository, MeterOffReasonsService>();
builder.Services.AddScoped<ICMaintenenceMetersOff, CMaintenenceMetersOffService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IControlCard, ControlCardService>();
builder.Services.AddScoped<IAppUser, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITestRegister, TestRegisterService>();
builder.Services.AddScoped<IReport, ReportService>();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
#endregion


//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // Configure identity options
//    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@";
//    options.User.RequireUniqueEmail = true;
//});




builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
});

//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();



app.UseCors(options =>
options.WithOrigins("http://localhost:4200")
.AllowAnyMethod()
.AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
