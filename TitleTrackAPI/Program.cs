using Microsoft.EntityFrameworkCore;
using TitleTrackAPI.Data;
using TitleTrackAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
            options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
        );

builder.Services.AddCors(options =>
       {
           options.AddPolicy("MyCors", builder =>
           {
               builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
           });
       });

builder.Services.AddScoped<ITitleAbstractRepository, TitleAbstractRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("MyCors");

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TitleTrackAPI v1"));
}

app.Run();