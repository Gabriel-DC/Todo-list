using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Todo.Domain.Handlers;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;
using Todo.Infra.Context;
using Todo.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddDbContext<DataContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("dev-homologacao")));

builder.Services.AddScoped<INotification, NotificationContext>();

builder.Services.AddTransient<TodoHandler, TodoHandler>();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        opts.Authority = "https://securetoken.google.com/todos-a044d";
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/todos-a044d",
            ValidateAudience = true,
            ValidAudience = "todos-a044d",
            ValidateLifetime = true,
        };
    });

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

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
