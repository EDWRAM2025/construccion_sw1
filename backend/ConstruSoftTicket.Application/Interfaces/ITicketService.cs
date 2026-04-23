using ConstruSoftTicket.Application.DTOs;
using ConstruSoftTicket.Domain.Entities;

namespace ConstruSoftTicket.Application.Interfaces;

public interface ITicketService
{
    Task<Ticket> RegisterTicketAsync(CreateTicketDto ticketDto);
    Task<List<Ticket>> GetAllTicketsAsync();
    Task<Ticket?> GetTicketByIdAsync(int id);
}
