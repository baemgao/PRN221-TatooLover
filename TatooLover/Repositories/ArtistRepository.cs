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
        public List<Artist> GetArtists() => ArtistDAO.GetArtists();

        public Artist GetArtistById(int id) => ArtistDAO.GetArtists().SingleOrDefault(a => a.ArtistId == id);
    }
}
