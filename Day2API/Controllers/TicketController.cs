using Azure.Messaging;
using Day2.BL.Dtos.Tickets;
using Day2.BL.Manager.Tickets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        public readonly ITicketsManagers _ticketsManagers;
        public TicketController( ITicketsManagers ticketsManagers)
        {
            _ticketsManagers = ticketsManagers;
        }

        [HttpGet]
        public ActionResult<List<TicketReadDto>> GetAllTickets()
        {
            return _ticketsManagers.GetAllTickets();
        }

        [HttpPut]

        public ActionResult UpdateTicket(UpdateTicketDto TicketDto)
        {
           var ticketfound= _ticketsManagers.UpdateTicket(TicketDto);
            if( !ticketfound)
            {
                return NotFound();
            }
            return NoContent();  
        }

        [HttpGet]
        [Route("{id}")]

        public ActionResult<TicketReadDto> GetTicketById(int id)
        {
            var ticketfound = _ticketsManagers.GetById(id);
            if (ticketfound==null)
            {
                return NotFound();
            }
            return ticketfound;
        }
        [HttpPost]
        public ActionResult AddTicket(AddTicketDto addTicketDto)
        {

            var ticketid = _ticketsManagers.AddTicket(addTicketDto);

            return CreatedAtAction("GetTicketById" //name of next step action
                , new { id = ticketid }, // parameters of next step
                new { Message = "Ticket Is Added" }); //response body
        }

        [HttpDelete]
        [Route("{id}")]

        public ActionResult DeleteTicket(int id)
        {
            var ticketfound = _ticketsManagers.DeleteTicket(id);
            if (!ticketfound)
            {
                return NotFound();
            }
            return NoContent();

        }

    
    }
}
