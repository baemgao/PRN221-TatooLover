using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ArtistDAO
    {
        Prn221TatooLoverContext db = new Prn221TatooLoverContext();
        public List<Artist> GetArtists() => db.Artists.ToList();
    }
}
