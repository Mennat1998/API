using Day2.DAL.Data.Context;
using Day2.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Day2.DAL.Repos.DepartmentsRepo
{
    public class DepartmentRepo : IDepartmentRepo
    {
        //GetDetailsCustomFromDb
        private readonly SystemContext _systemContext;

        public DepartmentRepo(SystemContext systemContext)
        {
            _systemContext = systemContext;
        }
        public Departments? GetDetailsCustomFromDb(int id)
        {
          return  _systemContext.Department
                .Include(D=>D.Tickets)
                .ThenInclude(Dv=>Dv.Developers)
                .FirstOrDefault(DEP=>DEP.Id == id);
        }
    }
}
