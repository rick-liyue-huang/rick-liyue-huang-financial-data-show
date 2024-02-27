using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

// Add the controllers to the container, and configure the JSON serializer to ignore reference loops, which can cause the serializer to crash for the one-to-many relationship between stocks and comments
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
);

// Add the repository to the container
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

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


