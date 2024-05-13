using BlogApi.DataAccess;
using BlogApi.Logging;
using BlogApi.Logging.Headers;
using BlogApi.Logging.Requests;
using BlogApi.Logging.Responses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultValue")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/*
app.UseLogHeaders();
app.UseRequestLogging();
app.UseResponseLogging();
*/
app.UseLogger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
