using InMemoryCache.API.Middleware;
using InMemoryCaching.Domain.Interfaces.RepositoryInterfaces;
using InMemoryCaching.IOC;
using InMemoryCaching.Repositories.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDataAccess, DataAccess>();
builder.Services.AddMemoryCache();
DependencyContainer.RegisterService(builder.Services);
var app = builder.Build();

app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
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


//reference
//https://www.c-sharpcorner.com/article/how-to-implement-caching-in-the-net-core-web-api-application/