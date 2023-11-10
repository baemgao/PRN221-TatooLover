using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IArtistRepository
    {
        List<Artist> GetArtists();
        Artist? GetArtistById(int? id);

        List<Artist> GetArtistByName(string name);
        bool UpdateArtist(Artist artistId);
        List<Artist> GetArtistByStudioId(int StudioId);
        int AddArtist(Artist artist);
        public List<Service> GetServiceByArtistId(int artistId);
        void ChangePassword(int artistId, string? newPassword);
    }
}
