using DAL;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Application;
using Infrastructure;
using Persistence;
using Infrastructure.Middleware;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Infrastructure.Mailing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reactivities", Version = "v1" });
});

#region Mail Settings
var emailSettings = new MailSettings();
builder.Configuration.GetSection("MailSettings").Bind(emailSettings);
builder.Services.AddSingleton(emailSettings); 
#endregion


builder.Services.AddApplicationLayer();
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddInfrastrucutreLayer(builder.Configuration);
builder.Services.AddPersistenceLayer();

var app = builder.Build();

app.UseInfrastrucutreLayer(builder.Configuration);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();