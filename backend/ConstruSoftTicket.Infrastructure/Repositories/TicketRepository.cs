using ConstruSoftTicket.Application.Interfaces;
using ConstruSoftTicket.Domain.Entities;
using ConstruSoftTicket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ConstruSoftTicket.Infrastructure.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _context;

    public TicketRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Ticket>> GetAllAsync()
    {
        return await _context.Tickets
            .OrderByDescending(t => t.FechaCreacion)
            .ToListAsync();
    }

    public async Task<Ticket?> GetByIdAsync(int id)
    {
        return await _context.Tickets.FindAsync(id);
    }
}
