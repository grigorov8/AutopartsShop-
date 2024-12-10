

using AutoPartsShop.Core.Contracts;
using AutoPartsShop.Core.Services;
using AutoPartsShop.Infrastructure.Database.Common;

var builder = WebApplication.CreateBuilder(args);



  

builder.Services.AddControllers();

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<ICartService, CartService>();


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
