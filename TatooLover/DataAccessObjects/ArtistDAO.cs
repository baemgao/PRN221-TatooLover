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
        Prn221TatooLoverContext db = new Prn221TatooLoverContext();
        public List<Artist> GetArtistByStudioId(int StudioId)
        {
            List<Artist> artistList = GetArtists();

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
        public Artist? GetArtistById(int? id)
        {
            return db.Artists
              .Include(s => s.Studio)
              .SingleOrDefault(a => a.ArtistId == id);
        }
        public void UpdateArtist(Artist artist)
        {
            db.Entry<Artist>(artist).State = EntityState.Modified;
            db.SaveChanges();
        }
        public int AddArtist(Artist artist)
        {
            db.Artists.Add(artist);
            return db.SaveChanges();
        }
    }
}