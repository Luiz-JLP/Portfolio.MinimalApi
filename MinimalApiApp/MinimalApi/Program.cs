using Domain;
using MinimalApi.Extensions;
using Services;
using Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ILoginService, LoginService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddControllers();

app.MapPost("/login", (Login login) =>
{
    var result = new LoginService().Logar(login);
    return result ? Results.Ok("Login realizado com sucesso.") : Results.Unauthorized();
});

app.UseHttpsRedirection();
app.Run();