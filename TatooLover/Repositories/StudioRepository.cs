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

        public Studio GetStudioByCode(string code) => studioDAO.GetStudioByCode(code);

        public List<Studio> GetStudios() => studioDAO.GetStudios();
    }
}
