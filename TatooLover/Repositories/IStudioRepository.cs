using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IStudioRepository
    {
        public List<Studio> GetStudios();
        public List<Service> GetServices();
        public Studio GetStudioById(int id);
        public void CreateStudio(Studio studio);
        List<Studio> GetStudioByName(string name);
        public List<Service> GetServiceByStudioId(int studioId);
        public void UpdateStudio(Studio studio);
        public void UpdateServiceStatus(int serviceId);
        public void AddService(Service service, int artistId);
    }
}
