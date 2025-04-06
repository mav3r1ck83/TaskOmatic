using Microsoft.EntityFrameworkCore;
using TaskOmatic.Application;
using TaskOmatic.Infrastructure;
using TaskOmatic.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddDbContext<TaskOmaticDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DBConnectionString"));
});

builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(); 
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});



var app = builder.Build();

app.UseCors();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

