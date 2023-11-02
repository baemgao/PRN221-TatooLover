using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ScheduleDAO
    {
        Prn221TatooLoverContext db = new Prn221TatooLoverContext();
        public List<Schedule> GetSchedules() => db.Schedules.ToList();
        public List<Schedule> GetSchedulesByArtistId(int artistId) => db.Schedules
            .Where(a => a.ArtistId == artistId)
            .Include(a => a.Artist)
            .ToList();

    }
}
