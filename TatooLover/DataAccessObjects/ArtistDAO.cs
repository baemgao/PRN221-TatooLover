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
        public static List<Artist> GetArtistByStudioId(int StudioId)
        { 

            return GetArtists()
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
                        .Include(a => a.ArtistDetails)
                        .ThenInclude(a => a.Service)
                        .Include(s => s.Studio)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return artists;
        }

        public static List<Artist> GetArtistByName(string searchText)
        {
            List<Artist> artists = new List<Artist>();
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        artists = context.Artists.Where(c => c.Name.Contains(searchText)).ToList();
                    }
                    else
                    {
                        artists = context.Artists.ToList();
                    }
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
