using BusinessObjects.Models;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        ScheduleDAO scheduleDAO = new ScheduleDAO();
        public List<Schedule> GetSchedules() => scheduleDAO.GetSchedules();
        public List<Schedule> GetSchedulesByArtistId(int artistId) => scheduleDAO.GetSchedulesByArtistId(artistId);
    }
}
