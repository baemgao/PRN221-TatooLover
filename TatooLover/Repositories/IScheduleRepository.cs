using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IScheduleRepository
    {
        public List<Schedule> GetSchedules();
        public Schedule? GetSchedulesById(int? id);
        public List<Schedule> GetListScheduleByArtistId(int? artistId);
        public List<Schedule> GetScheduleInDayByArtistId(DateTime date, int id);
        public void CreateSchedule(Schedule schedule, int artistId);
        public void UpdateSchedule(Schedule schedule);
        public void DeleteSchedule(Schedule schedule);
    }
}
