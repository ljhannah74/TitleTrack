using Microsoft.EntityFrameworkCore;
using TitleTrack.Api.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    
        builder.Services.AddDbContext<TitleTrackDbContext>(options =>
            options.UseSqlite("Data Source=titletrack.db"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
        //    app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.Run();
    }
}
