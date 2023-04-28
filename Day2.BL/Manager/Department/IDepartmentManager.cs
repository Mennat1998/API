using Day2.BL.Dtos.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.BL.Manager.Department
{
    public interface IDepartmentManager
    {

       DepartmentTicketDto? GetDetailsCustom(int id);
    }
}
