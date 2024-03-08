using CaseForForceget.BussinesLayer.Abstract;
using CaseForForceget.BussinesLayer.Concrete;
using CaseForForceget.DataAccess.UnitOfWork;
using CaseForForceget.DataAccessLayer.Abstract;
using CaseForForceget.DataAccessLayer.Context;
using CaseForForceget.DataAccessLayer.EntityFramework;
using CaseForRanna_BackEnd.DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DbContextForceget>(options=> options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IOfferService, OfferService>();


builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericDal<>));
builder.Services.AddScoped<IOfferDal, EfOfferDal>();

builder.Services.AddAutoMapper(typeof(Program));



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
