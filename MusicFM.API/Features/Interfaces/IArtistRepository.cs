using MusicFM.API.Core;

namespace MusicFM.API.Features.Interfaces;

public interface IArtistRepository
{
    /// <summary>
    /// Create Entity artistDb for db
    /// </summary>
    public Task CreateArtistAsync(Artist artist, CancellationToken cancellationToken);
    
    /// <summary>
    /// Check if artist exists. For Get artists by tags because dome artist have more than 1 tag
    /// </summary>
    public Task<bool> IsArtistExistsAsync(Guid mbid, CancellationToken cancellationToken);

    /// <summary>
    /// Update list of tags 
    /// </summary>
    public Task UpdateArtistTags(Guid mbid, Tag tag, CancellationToken cancellationToken);

    /// <summary>
    /// Get all artists with theirs tags and albums
    /// </summary>
    public Task<List<Artist>> GetAllArtistsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Update list of albums
    /// </summary>
    public Task UpdateArtistsAlbumsAsync(Guid mbid, Album album, CancellationToken cancellationToken);
}