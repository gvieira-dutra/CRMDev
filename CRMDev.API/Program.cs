using CRMDev.Application.Services.Implementations;
using CRMDev.Application.Services.Interfaces;
using CRMDev.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CRMDevDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CRMDevCS")));


builder.Services.AddScoped<IOpportunityServices, OpportunityServices>();
builder.Services.AddScoped<IContactServices, ContactServices>();
builder.Services.AddScoped<IFieldServices, FieldServices>();
builder.Services.AddScoped<INoteServices, NoteServices>();


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
