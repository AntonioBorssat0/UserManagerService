using Microsoft.EntityFrameworkCore;
using UserManagerService.Data;
using UserManagerService.Models;

var builder = WebApplication.CreateBuilder(args);

//services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); //default connection for the SQLite local database I set up in
builder.Services.AddSwaggerGen();

var app = builder.Build();

//HTTP request pipeline for development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//for creating users
app.MapPost("/users", async (CreatingUser userInfos, AppDbContext db) =>
{
    var user = new User
    {
        Name = userInfos.Name,
        Birthdate = userInfos.Birthdate,
        Active = true
    };
    db.Users.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"/users/{user.Id}", user);
});

//For changing Active status
app.MapPut("/users", async (UpdateActive userInfo, AppDbContext db) =>
{
    var user = await db.Users.FindAsync(userInfo.Id);
    if (user == null) return Results.NotFound("No users found.");
    user.Active = userInfo.Active;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

//For deleting user
app.MapDelete("/users/{id}", async (int id, AppDbContext db) =>
{
    var user = await db.Users.FindAsync(id);
    if (user == null) return Results.NotFound();
    db.Users.Remove(user);
    await db.SaveChangesAsync();
    return Results.NoContent();
});


//For the list of all active users
app.MapGet("/users/active", async (AppDbContext db) =>
{
    var users = await db.Users.Where(u => u.Active).ToListAsync();
    return Results.Ok(users);
});

app.Run();
