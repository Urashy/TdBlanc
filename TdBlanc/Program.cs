using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TdBlanc.Controllers;
using TdBlanc.Models;
using TdBlanc.Models.EntityFramework;
using TdBlanc.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LocalConnection");

builder.Services.AddDbContext<CommandeBDContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        policy =>
        {
            policy.SetIsOriginAllowed(origin =>
                new Uri(origin).Host == "localhost")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<CommandeBDContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IRepository<Commande>, CommandeManager>();

builder.Services.AddScoped<IRepository<Commande>>(sp => sp.GetRequiredService<IRepository<Commande>>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowBlazorClient");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
