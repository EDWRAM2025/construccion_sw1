using ConstruSoftTicket.Application.DTOs;
using ConstruSoftTicket.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConstruSoftTicket.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTicketDto dto)
    {
        var ticket = await _ticketService.RegisterTicketAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tickets = await _ticketService.GetAllTicketsAsync();
        return Ok(tickets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(id);
        if (ticket == null) return NotFound();
        return Ok(ticket);
    }
}
