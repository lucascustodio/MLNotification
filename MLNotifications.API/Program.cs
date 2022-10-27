using MLNotifications.Application.Validators;
using MLNotifications.Infra.Data.Repository;
using MLNotifications.Application.Services;
using MLNotifications.Application.Services.Interfaces;
using MLNotifications.Domain.Aggregates.NotificationAggregate.Interface;
using MLNotifications.Domain.Aggregates.UserConfigAggregate.Interface;
using MLNotifications.Extensions;
using MLNotifications.Domain.Aggregates.UserNotificationAggregate.Interface;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IPushNotificationService, PushNotificationService>();
builder.Services.AddScoped<IUserConfigService, UserConfigService>();
builder.Services.AddScoped<IUserNotificationService, UserNotificationService>();

//Repositories
builder.Services.AddScoped<IUserNotificationRepository, UserNotificationRepository>();
builder.Services.AddScoped<IUserConfigRepository, UserConfigRepository>();
builder.Services.AddScoped<INofiticationRepository, NofiticationRepository>();

//Validators
builder.Services.AddScoped<ICreateNotificationCommandValidator, CreateNotificationCommandValidator>();
builder.Services.AddScoped<ICreateUserNotificationCommandValidator, CreateUserNotificationCommandValidator>();
builder.Services.AddScoped<IUpdateNotificationCommandValidator, UpdateNotificationCommandValidator>();

builder.Services.AddMigrator();
builder.Services.AddDbContexts(builder.Configuration);

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
app.MigrateContext();


app.Run();


