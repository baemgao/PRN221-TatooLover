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
        public List<Service> GetServiceByStudioId(int studioId);
    }
}
