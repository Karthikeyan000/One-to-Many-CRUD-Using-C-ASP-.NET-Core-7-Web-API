using Microsoft.EntityFrameworkCore;
using New.Data;
using New.Services___Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connnectionString = builder.Configuration.GetConnectionString("DefaultConnections");
builder.Services.AddDbContext<BlogDbContext>(options =>options.UseSqlServer(connnectionString));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
  options.SerializerSettings.ReferenceLoopHandling= Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddTransient<BlogRepository>();
builder.Services.AddTransient<BlogService>();



builder.Services.AddControllers();
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
