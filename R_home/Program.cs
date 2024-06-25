using R_home.Core.Repositories;
using R_home.Core.Services;
using R_home.Data.Repositories;
using R_home.Data;
using R_home.Service;
using R_home;
using R_home.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//Baby
builder.Services.AddScoped<IBabyService, BabyService>();
builder.Services.AddScoped<IBabyRepository, BabyRepository>();

//Employee
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

//Room
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();


//Mapping
builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(MappingProfilePostModel));

//DataContext
builder.Services.AddDbContext<DataContext>();




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
