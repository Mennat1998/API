using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.BL.Dtos.Tickets
{
    public class UpdateTicketDto
    {
        public required int Id { get; set; }

        public required string Description { get; set; } = string.Empty;

        public required string Title { get; set; } = string.Empty;
        //public int DepartmentId { get; set; }
    }
}
