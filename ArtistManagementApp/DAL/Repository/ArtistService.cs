using ArtistManagementApp.DAL.Interface;
using ArtistManagementApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtistManagementApp.DAL.Repository
{
    public class ArtistManagementService : IArtistInterface
    {
        private IArtistRepository _repo;
        public ArtistManagementService(IArtistRepository repo)
        {
            this._repo = repo;
        }

        public Artist AddArtist(Artist artist)
        {
            return _repo.AddArtist(artist);
        }

        public Artist DeleteArtist(int artistId)
        {
            return _repo.DeleteArtist(artistId);
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return _repo.GetAllArtists();
        }

        public Artist GetArtistById(int artistId)
        {
            return _repo.GetArtistById(artistId);
        }

        public Artist UpdateArtist(Artist artist)
        {
            return _repo.UpdateArtist(artist);
        }
    }
}