using MinimalApi.Extensions;
using Repositories.Startup;
using Services.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataBaseContext();
builder.Services.AddRepositoryDependency();
builder.Services.AddServiceDependency();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.InitializeDatabase();

app.AddRouteEndpoints();
app.UseHttpsRedirection();
app.Run();