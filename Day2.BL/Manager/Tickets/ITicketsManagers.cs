using Day2.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day2.BL.Dtos.Tickets;
namespace Day2.BL.Manager.Tickets
{
    public interface ITicketsManagers
    {
        List<TicketReadDto> GetAllTickets();
        TicketReadDto? GetById(int id);
        int AddTicket (AddTicketDto ticketDto);
        bool UpdateTicket(UpdateTicketDto ticketDto);
        bool DeleteTicket(int id);

       
    }
}
