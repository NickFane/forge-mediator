using MediatorExamples_Application;
using MediatorExamples_Application.Services.GetBreeds;
using MediatorExamples_Application.Services.GetBreedsBySpecies;
using MediatorExamples_Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

// Add Swagger Endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Bootstrap.BootstrapApplication(builder.Services);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


var app = builder.Build();

var mediatr = app.Services.GetRequiredService<IMediator>();

// Expose Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Map endpoints
var breedsApi = app.MapGroup("/breeds");
breedsApi.MapGet("/", () => mediatr.Send(new GetBreedsRequest()));
breedsApi.MapGet("/{species}", (string species) => mediatr.Send(new GetBreedsBySpeciesRequest(species)));

app.Run();


[JsonSerializable(typeof(IList<Breed>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}

