using Day3API.Data.Context;
using Day3API.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add connection string of DataBase

var connectionString = builder.Configuration.GetConnectionString("System_ConString");
builder.Services.AddDbContext<SystemContext>(options => options.UseSqlServer(connectionString));


//Add usermanager service 

builder.Services.AddIdentity<UsersEntity, IdentityRole>(options=>
{
    // to remove constrains on Password and Email
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;

    options.User.RequireUniqueEmail = true;

})
    .AddEntityFrameworkStores<SystemContext>();

// add schema and authentication type(jwt)

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "MyToken";
    options.DefaultChallengeScheme = "MyToken";
})
    .AddJwtBearer("MyToken", options =>
    {
        string KeyString = builder.Configuration.GetValue<String>("SecretKey") ?? string.Empty;
        var KeyStringinBytes = Encoding.ASCII.GetBytes(KeyString);
        var key = new SymmetricSecurityKey(KeyStringinBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = key,
            ValidateIssuer = false, // as we only have one service that send and verify token
            ValidateAudience = false,
        };
    });

//Add policy

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admins", policy => policy
        .RequireClaim(ClaimTypes.Role, "Admin"));

    options.AddPolicy("Admins_Users", policy => policy
        .RequireClaim(ClaimTypes.Role, "Admin", "User"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// to user Authentication Middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
