using Microsoft.EntityFrameworkCore;
using WebPageAnalysis.DAL;
using WebPageAnalysis.DAL.Repository;
using WebPageAnalysis.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IWordCountRepository, WordCountRepository>();
builder.Services.AddScoped<IWebPageWorker, WebPageWorker>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(opt =>
               opt.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase")), ServiceLifetime.Scoped);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
