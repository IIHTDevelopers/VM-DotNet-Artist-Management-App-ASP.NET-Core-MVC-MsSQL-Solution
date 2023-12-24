using ArtistManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistManagementApp.DAL.Interface
{
    public interface IArtistInterface 
    {
        Artist GetArtistById(int artistId);
        IEnumerable<Artist> GetAllArtists();
        Artist AddArtist(Artist artist);
        Artist UpdateArtist(Artist artist);
        Artist DeleteArtist(int artistId);
    }
}