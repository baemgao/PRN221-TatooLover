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
        public List<Artist> GetArtists() => ArtistDAO.GetArtists();

        public Artist? GetArtistById(int? id) => artistDAO.GetArtistById(id);
        public Artist UpdateArtist(Artist artist) => artistDAO.UpdateArtist(artist);
    }
}
