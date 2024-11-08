using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

// Need instance of the database
using var context = new TwoDoTwoDoneDbContext();

app.MapGet("/users", async () => await context.Users.ToListAsync())
    .WithName("GetUsers")
    .WithOpenApi();

app.MapGet("/users/{userid:int}",
    async (int userid) =>
    {
        var user = await context.Users.FindAsync(userid);
        return user != null ? Results.Ok(user) : Results.NotFound();
    })
    .WithName("GetUser")
    .WithOpenApi();

app.MapPost("/users",
    async ([FromBody]User user) =>
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return Results.Created($"/users/{user.Id}", user);
    })
    .WithName("CreateUser")
    .WithOpenApi();


app.Run();

