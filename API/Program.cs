using Context;
using Context.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Identity
// Add Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 8;
    })
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

// Add DbContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(config.GetConnectionString("Database"), sqlOptions =>
    {
        sqlOptions.UseNetTopologySuite();
        sqlOptions.CommandTimeout(300);
    });
    
    // Enable sensitive data logging in development
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    // Seed data in development
    using (var scope = app.Services.CreateScope())
    {
        try
        {
            await Context.Seed.DataSeeder.SeedData(scope.ServiceProvider);
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }
}

app.UseAuthorization();

app.MapControllers();

app.Run();
