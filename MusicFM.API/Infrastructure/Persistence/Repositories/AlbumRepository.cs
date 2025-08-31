using Microsoft.EntityFrameworkCore;
using MusicFM.API.Core;
using MusicFM.API.Features.Interfaces;
using MusicFM.API.Infrastructure.Mapping;

namespace MusicFM.API.Infrastructure.Persistence.Repositories;

public class AlbumRepository: IAlbumRepository
{
    private readonly MusicFmDbContext _context;

    public AlbumRepository(MusicFmDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create album for db
    /// </summary>
    public async Task CreateAlbumAsync(Album album, CancellationToken cancellationToken)
    {
        var existedAlbum = await _context.Albums.FirstOrDefaultAsync(a => a.Mbid == album.Mbid, cancellationToken);
        if (existedAlbum == null)
        {
            await _context.Albums.AddAsync(album.ToDb(), cancellationToken);
        }
    }

    /// <summary>
    /// Get all albumsof the artist
    /// </summary>
    public async Task<List<Album>> GetAlbumsByArtistId(Guid artistsMbid, CancellationToken cancellationToken)
    {
        var artist = await _context.Artists.FirstOrDefaultAsync(a => a.Mbid == artistsMbid, cancellationToken);
        if (artist == null)
        {
            throw new InvalidOperationException("There is no artist with such Id");
        }
        
        var result = await 
            _context
                .Albums
                .Where(al => al.Artist.Mbid == artistsMbid)
                .Select(al => al.ToDomain(artist.ToDomain()))
                .ToListAsync(cancellationToken);
        
        return result;
    }
}