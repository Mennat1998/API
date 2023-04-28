using Day2.BL.Dtos.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.BL.Dtos.Department
{
    public class DepartmentTicketDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public List<TicketsDetailsDtoCustum> Tickets { get; set; } = new();
    }
}
