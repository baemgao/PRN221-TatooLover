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
        public Schedule? GetSchedulesById(int? id) => db.Schedules
            .Include(a => a.Artist)
            .SingleOrDefault(a => a.ScheduleId == id);
        public List<Schedule> GetListScheduleByArtistId(int? artistId) => db.Schedules
            .Where(a => a.ScheduleId == artistId)
            .Include(a => a.Artist)
            .ToList();
        public List<Schedule> GetScheduleInDayByArtistId(DateTime date, int id) => db.Schedules
            .Where(b => b.ScheduleId == id && b.Date.Date == date.Date)
            .Include(c => c.Artist)
            .ToList();
        public void CreateSchedule(Schedule schedule, int artistId)
        {
            schedule.Status = 0;
            schedule.ArtistId = artistId;
            db.Schedules.Add(schedule);
            db.SaveChanges();
        }
        public void UpdateSchedule(Schedule schedule)
        {
            schedule.Status = 0;
            db.Entry<Schedule>(schedule).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteSchedule(Schedule schedule)
        {
            db.Schedules.Remove(schedule);
            db.SaveChanges();
        }
    }
}
