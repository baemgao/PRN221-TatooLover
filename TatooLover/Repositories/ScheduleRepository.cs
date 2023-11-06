using BusinessObjects.Models;
using DataAccessObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        ScheduleDAO scheduleDAO = new ScheduleDAO();
        public List<Schedule> GetSchedules() => scheduleDAO.GetSchedules();
        public Schedule? GetSchedulesById(int? id) => scheduleDAO.GetSchedulesById(id);
        public List<Schedule> GetListScheduleByArtistId(int? artistId) => scheduleDAO.GetListScheduleByArtistId(artistId);
        public List<Schedule> GetScheduleInDayByArtistId(DateTime date, int id) => scheduleDAO.GetScheduleInDayByArtistId(date, id);
        public void CreateSchedule(Schedule schedule, int artistId) => scheduleDAO.CreateSchedule(schedule, artistId);
        public void UpdateSchedule(Schedule schedule) => scheduleDAO.UpdateSchedule(schedule);
        public void DeleteSchedule(Schedule schedule) => scheduleDAO.DeleteSchedule(schedule);
    }
}
