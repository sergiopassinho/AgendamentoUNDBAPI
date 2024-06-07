using System.Text;
using WebApplication1.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<Agendamento> reunioesExistentes = new()
{
    new Agendamento { Data = "2024-06-10", Horario = "10:00", Sala = "LAB 601", Duracao = 60 },
    new Agendamento { Data = "2024-06-11", Horario = "14:00", Sala = "LAB 602", Duracao = 30 }
};

app.MapPost("/autenticar", async (HttpContext context) =>
{
    using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8))
    {
        string requestBody = await reader.ReadToEndAsync();

        var credencial = JsonConvert.DeserializeObject<Credencial>(requestBody);

        if (credencial == null)
            return context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        Autenticar autenticador = new BasicAutenticacao();

        bool autenticado = autenticador.AutenticarUsuario(credencial);
       
        if (autenticado)
            return context.Response.StatusCode = (int)HttpStatusCode.OK;
            
        return context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
    }
});

app.MapGet("/agendamentos", () =>
{
    return reunioesExistentes;
});

app.MapPost("/agendar", async (HttpContext context) =>
{
    using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8))
    {
        string requestBody = await reader.ReadToEndAsync();

        var agendamento = JsonConvert.DeserializeObject<Agendamento>(requestBody);

        if (agendamento == null)
            return context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        reunioesExistentes.Add(agendamento);

        return context.Response.StatusCode = (int)HttpStatusCode.OK;
    }
});


app.Run();