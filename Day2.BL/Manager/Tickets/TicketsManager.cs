using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day2.BL.Dtos.Tickets;
using Day2.DAL.Data.Context;
using Day2.DAL.Data.Models;
using Day2.DAL.Repos.Tickets;

namespace Day2.BL.Manager.Tickets
{
    
    public class TicketsManager : ITicketsManagers
    {
        public readonly ITicketRepo _ticketRepo;
        public TicketsManager(ITicketRepo ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }

        public List<TicketReadDto> GetAllTickets()
        {
            var ListFromDb= _ticketRepo.GetAll();
            return ListFromDb.Select(T => new TicketReadDto {
            Id= T.Id,
            Description=T.Description,
            DepartmentId=T.DepartmentId,
            Title=T.Title}).ToList();
        }

        public TicketReadDto? GetById(int id)
        {
            var GetTicketFromDb = _ticketRepo.GetById(id);
            if( GetTicketFromDb == null) 
            {
                return null;
            }
            return new TicketReadDto
            {
                Id = GetTicketFromDb.Id,
                Description = GetTicketFromDb.Description,
                DepartmentId = GetTicketFromDb.DepartmentId,
                Title = GetTicketFromDb.Title
            };
        }
        public int AddTicket(AddTicketDto ticketDto)
        {
            var Ticket = new Ticket
            {
                Description = ticketDto.Description,
                Title = ticketDto.Title,
            };
            _ticketRepo.AddTicket(Ticket);
            _ticketRepo.SaveChanges();
            return Ticket.Id;
        }

        public bool DeleteTicket(int id)
        {
            var GetTicketFromDb = _ticketRepo.GetById(id);
            if (GetTicketFromDb == null)
            { return false; }

            _ticketRepo.DeleteTicket(GetTicketFromDb);
            _ticketRepo.SaveChanges();

            return true;
        }
        public bool UpdateTicket(UpdateTicketDto ticketDto)
        {
            var GetTicketFromDb = _ticketRepo.GetById(ticketDto.Id);
            if( GetTicketFromDb ==null) 
            { return false; }

            GetTicketFromDb.Description = ticketDto.Description;
            GetTicketFromDb.Title = ticketDto.Title;

            _ticketRepo.UpdateTicket(GetTicketFromDb);
            _ticketRepo.SaveChanges();
            return true;
        }
    }
}
