using ConstruSoftTicket.Application.DTOs;
using ConstruSoftTicket.Application.Interfaces;
using ConstruSoftTicket.Domain.Entities;

namespace ConstruSoftTicket.Application.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Ticket> RegisterTicketAsync(CreateTicketDto ticketDto)
    {
        var ticket = new Ticket
        {
            Titulo = ticketDto.Titulo,
            Descripcion = ticketDto.Descripcion,
            FechaCreacion = DateTime.UtcNow
        };

        await _ticketRepository.AddAsync(ticket);
        return ticket;
    }

    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        return await _ticketRepository.GetAllAsync();
    }

    public async Task<Ticket?> GetTicketByIdAsync(int id)
    {
        return await _ticketRepository.GetByIdAsync(id);
    }
}
