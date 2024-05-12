using Microsoft.Extensions.Configuration;
using TeaProduction.Business.Interfaces;
using TeaProduction.Business.Models;
using TeaProduction.Business.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var emailConfig = builder.Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfigurationModel>();

builder.Services.AddSingleton(emailConfig);

builder.Services.AddScoped<IEmailInterface, EmailService>();
builder.Services.AddScoped<ILoggerInterface, LoggerService>();
builder.Services.AddScoped<IBlackTeaInterface, BlackTeaService>();
builder.Services.AddTransient(typeof(IRepositoryInterface<>), typeof(RepositoryService<>));


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
