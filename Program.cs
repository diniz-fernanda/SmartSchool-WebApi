using Microsoft.EntityFrameworkCore;
using SmartSchool_WebApi.Data;
using SmartSchool_WebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConn");

builder.Services.AddDbContext<DataContext>(
    x => x.UseSqlite(connectionString)
);

builder.Services.AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddScoped<IRepository, Repository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
