using ConstruSoftTicket.Domain.Entities;

namespace ConstruSoftTicket.Application.Interfaces;

public interface ITicketRepository
{
    Task AddAsync(Ticket ticket);
    Task<List<Ticket>> GetAllAsync();
    Task<Ticket?> GetByIdAsync(int id);
}
