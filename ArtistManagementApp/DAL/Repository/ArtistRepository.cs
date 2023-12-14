using ArtistManagementApp.DAL.Interface;
using ArtistManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ArtistManagementApp.DAL.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private ArtistDbContext _context;
        public ArtistRepository(ArtistDbContext Context)
        {
            this._context = Context;
        }
      
        public Artist GetArtistById(int artistId)
        {
            return _context.Artists.Find(artistId);
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return _context.Artists.ToList();
        }

        public Artist AddArtist(Artist artist)
        {
            if (artist != null)
            {
                _context.Artists.Add(artist);
                _context.SaveChanges(); // Save changes to the database
                return artist; // Return the added artist with the updated Id
            }
            else
            {
                // Handle the case where the input artist is null
                throw new ArgumentNullException(nameof(artist), "Artist object cannot be null");
            }
        }


        public Artist UpdateArtist(Artist updatedArtist)
        {
            if (updatedArtist != null)
            {
                var existingArtist = _context.Artists.Find(updatedArtist.ArtistId);

                if (existingArtist != null)
                {
                    // Update properties of the existing artist with the new values
                    _context.Entry(existingArtist).CurrentValues.SetValues(updatedArtist);
                    _context.SaveChanges(); // Save changes to the database
                    return existingArtist;
                }
                else
                {
                    // Handle the case where the artist with the given Id is not found
                    throw new ArgumentException($"Artist with Id {updatedArtist.ArtistId} not found", nameof(updatedArtist));
                }
            }
            else
            {
                // Handle the case where the input artist is null
                throw new ArgumentNullException(nameof(updatedArtist), "Updated artist object cannot be null");
            }
        }

        public Artist DeleteArtist(int artistId)
        {
            var artistToDelete = _context.Artists.Find(artistId);

            if (artistToDelete != null)
            {
                _context.Artists.Remove(artistToDelete);
                _context.SaveChanges(); // Save changes to the database
                return artistToDelete;
            }
            else
            {
                // Handle the case where the artist with the given Id is not found
                throw new ArgumentException($"Artist with Id {artistId} not found", nameof(artistId));
            }
        }
    }
}
