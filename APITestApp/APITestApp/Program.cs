using APITestApp.Respository;
using Microsoft.EntityFrameworkCore;
using APITestApp.Respository.RepositoryImpl;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<HangHoaRepository, RepositoryImpl>();
builder.Services.AddScoped<LoaiRepository, LoaiRepositoryImpl>();
builder.Services.AddDbContext<APITestApp.Data.DataConnection.MyDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
