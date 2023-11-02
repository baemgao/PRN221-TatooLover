using BusinessObjects.Models;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StudioRepository : IStudioRepository
    {
        StudioDAO studioDAO = new StudioDAO();
        ServiceDAO serviceDAO = new ServiceDAO(); 

        public Studio GetStudioById(int id)
        {
            Studio? studio = GetStudios().FirstOrDefault(x => x.StudioId == id);
            return studio;
        }

        public List<Studio> GetStudios() => studioDAO.GetStudios();
        public List<Studio> GetStudioByName(string name) => StudioDAO.GetStudioByName(name);
        public List<Service> GetServices() => serviceDAO.GetServices();

        public List<Service> GetServiceByStudioId(int studioId) => serviceDAO.GetServiceByStudioId(studioId);
    }
}
