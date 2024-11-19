using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddDbContext<TwoDoTwoDoneDbContext>(options =>
{
    options.UseSqlServer("Data Source=localhost\\SQLEXPRESS; Initial Catalog=TwoDoTwoDone_EfCore; Integrated Security=True; Encrypt=False");

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/users", async (TwoDoTwoDoneDbContext db) => await db.Users.ToListAsync())
    .WithName("GetUsers")
    .WithOpenApi();

app.MapGet("/users/{userid:int}",
    async (int userid, TwoDoTwoDoneDbContext db) =>
    {
        var user = await db.Users.FindAsync(userid);
        return user != null ? Results.Ok(user) : Results.NotFound();
    })
    .WithName("GetUser")
    .WithOpenApi();

app.MapPost("/users",
    async (User user, TwoDoTwoDoneDbContext db) =>
    {
        await db.Users.AddAsync(user);
        await db.SaveChangesAsync();
        return Results.Created($"/users/{user.Id}", user);
    })
    .WithName("CreateUser")
    .WithOpenApi();

app.MapDelete("/users/{userid:int}",
    async (int userid, TwoDoTwoDoneDbContext db) =>
    {
        try
        {
            var user = db.Users.Attach(new User { Id = userid, Email = String.Empty, Username = String.Empty });
            user.State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Results.NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            return Results.NotFound();
        }

    })
    .WithName("DeleteUser")
    .WithOpenApi();


app.Run();

