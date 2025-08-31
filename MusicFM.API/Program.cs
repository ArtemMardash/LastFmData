using Microsoft.EntityFrameworkCore;
using MusicFM.API.Features.GetAlbumsByArtists;
using MusicFM.API.Features.GetAllData;
using MusicFM.API.Features.GetTopArtistsByTag;
using MusicFM.API.Features.GetTopTags;
using MusicFM.API.Infrastructure;
using MusicFM.API.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(config);
builder.Services.AddLastFmService(config);

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetService<MusicFmDbContext>();
    context?.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//Get method to get tags
app.MapGet("/topTags", async (IGetTopTagsUseCase useCase, CancellationToken cancellationToken) =>
    {
        await useCase.ExecuteAsync(cancellationToken);
    })
    .WithName("GetTopTags")
    .WithOpenApi();

//Get method to get artists
app.MapGet("/topArtists", async (IGetTopArtistsByTagsUseCases useCase, CancellationToken cancellationToken) =>
    {
        await useCase.ExecuteAsync(cancellationToken);
    })
    .WithName("GetTopArtists")
    .WithOpenApi();

//Get method to get albums
app.MapGet("/topAlbums", async (IGetAlbumsByArtistsUseCase useCase, CancellationToken cancellationToken) =>
    {
        await useCase.ExecuteAsync(cancellationToken);
    })
    .WithName("GetTopAlbums")
    .WithOpenApi();
//Get all data for UI
app.MapGet("GetAllData", async (IGetAllDataUseCase useCase, CancellationToken cancellationToken) =>
    {
        return await useCase.ExecuteAsync(cancellationToken);
    })
    .WithName("GetAllData")
    .WithOpenApi();

app.Run();