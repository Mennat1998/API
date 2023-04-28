using Day2.BL.Dtos.Department;
using Day2.BL.Manager.Department;
using Day2.BL.Manager.Tickets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly IDepartmentManager _departmentManager;
        public DepartmentController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        [HttpGet]
        [Route("{id}")]


        public ActionResult<DepartmentTicketDto> GetDetails(int id)
        {
            DepartmentTicketDto? department = _departmentManager.GetDetailsCustom(id);
            if(department == null) { return NotFound(); }
            return department;
        }
    }
}
