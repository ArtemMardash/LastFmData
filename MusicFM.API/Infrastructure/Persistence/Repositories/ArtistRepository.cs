using Microsoft.EntityFrameworkCore;
using MusicFM.API.Core;
using MusicFM.API.Features.Interfaces;
using MusicFM.API.Infrastructure.Mapping;

namespace MusicFM.API.Infrastructure.Persistence.Repositories;

public class ArtistRepository : IArtistRepository
{
    private readonly MusicFmDbContext _context;

    public ArtistRepository(MusicFmDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create entity Artist for db
    /// </summary>
    public async Task CreateArtistAsync(Artist artist, CancellationToken cancellationToken)
    {
        var tagsId = artist.Tags.Select(t => t.Id).ToList();
        var existingTags = await _context.Tags.Where(t => tagsId.Contains(t.Id)).ToListAsync(cancellationToken);
        var artistDb = artist.ToDb();
        artistDb.Tags = existingTags;
        await _context.Artists.AddAsync(artistDb, cancellationToken);
    }


    /// <summary>
    /// Method to check if Artist exist
    /// </summary>
    public async Task<bool> IsArtistExistsAsync(Guid mbid, CancellationToken cancellationToken)
    {
        return await _context.Artists.AnyAsync(a => a.Mbid == mbid, cancellationToken);
    }

    /// <summary>
    /// Update artist tags
    /// </summary>
    public async Task UpdateArtistTags(Guid mbid, Tag tag, CancellationToken cancellationToken)
    {
        var artistDb = await _context.Artists.Include(artistDb => artistDb.Tags)
            .FirstOrDefaultAsync(a => a.Mbid == mbid, cancellationToken);
        if (artistDb == null)
        {
            throw new InvalidOperationException("There is no Artist with such mbID");
        }

        var tagDb = await _context.Tags.FirstOrDefaultAsync(t => t.Id == tag.Id, cancellationToken);

        if (!artistDb.Tags.Contains(tagDb))
        {
            artistDb.Tags.Add(tagDb);
        }
    }

    /// <summary>
    /// Update artists albums
    /// </summary>
    public async Task UpdateArtistsAlbumsAsync(Guid mbid, Album album, CancellationToken cancellationToken)
    {
        var artistDb = await _context.Artists.Include(ar => ar.Albums)
            .FirstOrDefaultAsync(a => a.Mbid == mbid, cancellationToken);
        if (artistDb == null)
        {
            throw new InvalidOperationException("There is no Artist with such mbID");
        }

        var albumDb = await _context.Albums.FirstOrDefaultAsync(ar => ar.Mbid == album.Mbid, cancellationToken);
        if (albumDb == null)
        {
            albumDb = album.ToDb();
            artistDb.Albums.Add(albumDb);
        }
        else
        {
            artistDb.Albums.Add(albumDb);
        }
    }

    /// <summary>
    /// Get all artist with tags and albums
    /// </summary>
    public async Task<List<Artist>> GetAllArtistsAsync(CancellationToken cancellationToken)
    {
        return await _context
            .Artists
            .Include(ar => ar.Albums)
            .Include(a => a.Tags)
            .Select(art => art.ToDomain())
            .ToListAsync(cancellationToken);
    }
}