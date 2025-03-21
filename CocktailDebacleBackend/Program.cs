using Microsoft.EntityFrameworkCore;
using CocktailDebacleBackend.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

System.Diagnostics.Debug.Print(builder.Configuration.GetConnectionString("DefaultConnection"));


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

// Get the application part manager
var partManager = app.Services.GetRequiredService<ApplicationPartManager>();

// Find all controllers
var feature = new ControllerFeature();
partManager.PopulateFeature(feature);

// Print loaded controllers
System.Diagnostics.Debug.Print("Controllers Loaded: " + string.Join(", ", feature.Controllers.Select(c => c.AsType().FullName)));
app.Run();
