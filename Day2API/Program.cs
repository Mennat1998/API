using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Day2.DAL.Data.Context;
using Day2.DAL.Repos.Tickets;
using Day2.DAL.Repos.DepartmentsRepo;
using Day2.BL.Manager.Tickets;
using Day2.BL.Manager.Department;

var builder = WebApplication.CreateBuilder(args);


// services
builder.Services.AddScoped<ITicketRepo,TicketRepo>();

builder.Services.AddScoped<ITicketsManagers, TicketsManager>();

builder.Services.AddScoped<IDepartmentManager,DepartmentManager>();

builder.Services.AddScoped<IDepartmentRepo,DepartmentRepo>();
// Add connection string of DataBase

var connectionString = builder.Configuration.GetConnectionString("System_ConString");
builder.Services.AddDbContext<SystemContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


