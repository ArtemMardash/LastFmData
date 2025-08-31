using Microsoft.EntityFrameworkCore;
using MusicFM.API.Features.GetAlbumsByArtists;
using MusicFM.API.Features.GetAllData;
using MusicFM.API.Features.GetTopArtistsByTag;
using MusicFM.API.Features.GetTopTags;
using MusicFM.API.Features.Interfaces;
using MusicFM.API.Infrastructure.Persistence;
using MusicFM.API.Infrastructure.Persistence.Repositories;
using MusicFM.API.Infrastructure.Services;
using MusicFM.API.Infrastructure.Services.WebClients;

namespace MusicFM.API.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration config)
    {
        services.AddScoped<IAlbumRepository, AlbumRepository>();
        services.AddScoped<IArtistRepository, ArtistRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<MusicFmDbContext>(opt =>
        {
            opt.UseNpgsql(config.GetConnectionString("DefaultConnectionString") ??
                          throw new InvalidOperationException("Invalid Default Connection String"),
                builder => builder.MigrationsAssembly(typeof(MusicFmDbContext).Assembly.GetName().Name));
        });
        return services;
    }

    public static void AddLastFmService(this IServiceCollection services, IConfiguration configuration)
    {
        var lastFmSettings = configuration.GetSection("LastFm") ?? throw new InvalidOperationException("No LastFm section");
        services.Configure<MusicFmSettings>(lastFmSettings);

        services.AddHttpClient<MusicFmClient>(nameof(MusicFmClient),(client) =>
        {
            client.BaseAddress = new Uri("http://ws.audioscrobbler.com");
        });

        services.AddScoped<IGetAlbumsByArtistsUseCase, GetAlbumsByArtistsUseCase>();
        services.AddScoped<IGetTopTagsUseCase, GetTopTagsUseCase>();
        services.AddScoped<IGetTopArtistsByTagsUseCases, GetTopArtistsByTagsUseCase>();
        services.AddScoped<IGetAllDataUseCase, GetAllDataUseCase>();
    }
}