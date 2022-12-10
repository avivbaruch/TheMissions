using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheMissions.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TheMissionsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TheMissionsContext") ?? throw new InvalidOperationException("Connection string 'TheMissionsContext' not found.")));

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
