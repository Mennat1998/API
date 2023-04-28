using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day2.DAL.Data.Models;

namespace Day2.DAL.Repos.Tickets
{
    public interface ITicketRepo
    {

        IEnumerable<Ticket> GetAll();
        Ticket? GetById(int id);
        void AddTicket (Ticket ticket);
        void UpdateTicket (Ticket ticket);
        void DeleteTicket (Ticket ticket);

        int SaveChanges();

    }
}
