using BusinessObjects.Models;
using DataAccessObjects;

namespace Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        ScheduleDAO scheduleDAO = new ScheduleDAO();
        public List<Schedule> GetSchedules() => scheduleDAO.GetSchedules();
        public Schedule? GetSchedulesById(int? id) => scheduleDAO.GetSchedulesById(id);
        public List<Schedule> GetListScheduleByArtistId(int? artistId) => scheduleDAO.GetListScheduleByArtistId(artistId);
        public void CreateSchedule(Schedule schedule) => scheduleDAO.CreateSchedule(schedule);
        public void UpdateSchedule(Schedule schedule) => scheduleDAO.UpdateSchedule(schedule);
        public void DeleteSchedule(Schedule schedule) => scheduleDAO.DeleteSchedule(schedule);
    }
}
