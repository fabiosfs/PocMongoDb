using PocMongoDb.Domain;
using PocMongoDb.Infrastructure;
using PocMongoDb.Domain.Repositories.Shared;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Poc MongoDb API", Version = "v1" });
});

builder.Services.InjectionInfrastructure(new DataBaseConfiguration()
{
    ConnectionString = builder.Configuration.GetSection("Connection:ConnectionString").Value,
    DatabaseName = builder.Configuration.GetSection("Connection:DataBase").Value,
    IsSSL = Convert.ToBoolean(builder.Configuration.GetSection("Connection:IsSSL").Value)
});
builder.Services.InjectionDomain();

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
