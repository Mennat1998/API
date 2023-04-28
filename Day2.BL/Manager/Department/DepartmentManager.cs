using Day2.BL.Dtos.Department;
using Day2.BL.Dtos.Tickets;
using Day2.DAL.Data.Models;
using Day2.DAL.Repos.DepartmentsRepo;
using System.Diagnostics;

namespace Day2.BL.Manager.Department;

public class DepartmentManager : IDepartmentManager
{
    public readonly IDepartmentRepo _DepartmentRepo;
    public DepartmentManager(IDepartmentRepo DepartmentRepo)
    {
        _DepartmentRepo = DepartmentRepo;
    }
    public DepartmentTicketDto? GetDetailsCustom(int id)
    {
        Departments? departmentTicketDb = _DepartmentRepo.GetDetailsCustomFromDb(id);
        if (departmentTicketDb == null) { return null; }

        return new DepartmentTicketDto
        {
            Id = departmentTicketDb.Id,
            Name = departmentTicketDb.Name,
            Tickets = departmentTicketDb.Tickets.Select(D =>
            new TicketsDetailsDtoCustum
            {
                Id = D.Id,
                Description = D.Description,
                CountDevelopers = D.Developers.Count
            }).ToList()
        };
    }
    
    }


