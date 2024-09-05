using CRMDev.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using CRMDev.Application.Command.PostOpportunity;
using MediatR;
using CRMDev.Application.HelperFunction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CRMDevDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CRMDevCS")));

builder.Services.AddScoped<IHelperFunctions, HelperFunctions>();
builder.Services.AddMediatR(typeof(PostOpportunityCommand));

builder.Services.AddHttpClient("MyApiClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:11434/api/generate");
    client.Timeout = TimeSpan.FromMinutes(5);
});

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
