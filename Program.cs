using Microsoft.EntityFrameworkCore;
using JusFacil.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "JusFacilAPI",
        ValidAudience = "JusFacilFront",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("protecao-contra-falsiane-tem-que-ser-longa"))
    };

});
   


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
