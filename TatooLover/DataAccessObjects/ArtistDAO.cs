using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ArtistDAO
    {
        
        public List<Artist> GetArtistByStudioId(int StudioId)
        {
            List<Artist> artistList = GetArtists();

            return artistList
              .Where(a => a.StudioId == StudioId)
              .ToList();
        }

        public static List<Artist> GetArtists()
        {
            List<Artist> artists = new List<Artist>();
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    artists = context.Artists
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return artists;
        }
    }
}
