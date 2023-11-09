using BusinessObjects.Models;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        ArtistDAO artistDAO = new ArtistDAO();
        ServiceDAO serviceDAO = new ServiceDAO();
        public List<Artist> GetArtists() => ArtistDAO.GetArtists();
        public List<Artist> GetArtistByName(string name) => ArtistDAO.GetArtistByName(name);
        public Artist? GetArtistById(int? id) => artistDAO.GetArtistById(id);
        public bool UpdateArtist(Artist artist) => artistDAO.UpdateArtist(artist);
        public List<Artist> GetArtistByStudioId(int StudioId) => artistDAO.GetArtistByStudioId(StudioId);
        public int AddArtist(Artist artist) => artistDAO.AddArtist(artist);
        public List<Service> GetServiceByArtistId(int artistId) => serviceDAO.GetServiceByArtistId(artistId);
        public void ChangePassword(int artistId, string? newPassword) => artistDAO.ChangePassword(artistId, newPassword);
    }
}
