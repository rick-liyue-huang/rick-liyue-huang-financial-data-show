using Microsoft.EntityFrameworkCore;
using webAPI.DataConnectionContext;
using webAPI.Interfaces;
using webAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the database context to the container
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    // confirmed from appsettings.json that the connection string is named "DefaultConnection", and then create the tables in the database from the models
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add the controllers to the container
builder.Services.AddControllers();

// Add the repository to the container
builder.Services.AddScoped<IStockRepository, StockRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add the routing to the request pipeline
app.MapControllers();

app.Run();


