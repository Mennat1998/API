using Day2.DAL.Data.Context;
using Day2.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Day2.DAL.Repos.Tickets
{
    public class TicketRepo : ITicketRepo

    {
        private readonly SystemContext _systemContext;

        public TicketRepo(SystemContext systemContext) 
        {
            _systemContext=systemContext;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _systemContext.Set<Ticket>();
           // return _systemContext.Ticket;
        }

        public Ticket? GetById(int id)
        {
            return _systemContext.Set<Ticket>().Find(id);
         //   return _systemContext.Set<Ticket>().FirstOrDefault(i=>i.Id== id);
        }
        public void AddTicket(Ticket ticket)
        {
             _systemContext.Set<Ticket>().Add(ticket);
        }

        public void DeleteTicket(Ticket ticket)
        {
            _systemContext.Set<Ticket>().Remove(ticket);
        }



        public int SaveChanges()
        {
           return _systemContext.SaveChanges();
        }

        public void UpdateTicket(Ticket ticket)
        {
            // No Implementation as we as using Tracking 
        }
    }
}
