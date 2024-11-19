using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public static class WebApplicationExtensions
    {
        public static WebApplication MapUsers(this WebApplication app) {
            var group = app.MapGroup("/users");


            group.MapGet("/", async (TwoDoTwoDoneDbContext db) => await db.Users.ToListAsync())
                .WithName("GetUsers")
                .WithOpenApi();

            group.MapGet("/{userid:int}",
                async (int userid, TwoDoTwoDoneDbContext db) =>
                {
                    var user = await db.Users.FindAsync(userid);
                    return user != null ? Results.Ok(user) : Results.NotFound();
                })
                .WithName("GetUser")
                .WithOpenApi();

            group.MapPost("/",
                async (User user, TwoDoTwoDoneDbContext db) =>
                {
                    await db.Users.AddAsync(user);
                    await db.SaveChangesAsync();
                    return Results.Created($"/users/{user.Id}", user);
                })
                .WithName("CreateUser")
                .WithOpenApi();

            group.MapDelete("/{userid:int}",
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

            return app;
        }
    }
}
