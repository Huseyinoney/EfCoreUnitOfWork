using Business.Abstract;
using Business.Abstract.UnitOfWork;
using Business.Concrete;
using Business.Concrete.UnitOfWork;
using Business.Helpers;
using Business.Repositories;
using DataAccess.Context;
using DataAccess.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("connectionString")
    ));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Add services to the container.
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IPasswordHashHelper, PasswordHashHelper>();
builder.Services.AddScoped<IBaseRepository<User>, UserRepository>();
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
