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

    public async Task<Ticket?> UpdateTicketAsync(UpdateTicketDto ticketDto)
    {
        var ticket = await _ticketRepository.GetByIdAsync(ticketDto.Id);
        if (ticket == null) return null;

        ticket.Titulo = ticketDto.Titulo;
        ticket.Descripcion = ticketDto.Descripcion;

        await _ticketRepository.UpdateAsync(ticket);
        return ticket;
    }

    public async Task<bool> DeleteTicketAsync(int id)
    {
        var ticket = await _ticketRepository.GetByIdAsync(id);
        if (ticket == null) return false;

        await _ticketRepository.DeleteAsync(ticket);
        return true;
    }
}
