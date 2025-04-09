using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

// Add Swagger Endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Expose Swagger In
app.UseSwagger();
app.UseSwaggerUI();

var sampleBreeds = new Breed[] {
    new("Maine Coon", Species.Cat),
    new("Labrador", Species.Dog),
    new("Blue Cattle", Species.Dog),
    new("Domestic Short Hair", Species.Cat),
};

var breedsApi = app.MapGroup("/breeds");
breedsApi.MapGet("/", () => sampleBreeds);

app.Run();

public record Breed(string name, string species);

[JsonSerializable(typeof(Breed[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}

public static class Species
{
    public static string Dog = "Dog";
    public static string Cat = "Cat";
}