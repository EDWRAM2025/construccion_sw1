const API_BASE = 'http://localhost:5151/api';

export const ticketService = {
  async createTicket(ticketData) {
    const response = await fetch(`${API_BASE}/ticket`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(ticketData),
    });

    if (!response.ok) {
      throw new Error('Error al crear el ticket');
    }

    return response.json();
  },

  async getAllTickets() {
    const response = await fetch(`${API_BASE}/ticket`);

    if (!response.ok) {
      throw new Error('Error al obtener los tickets');
    }

    return response.json();
  },

  async getTicketById(id) {
    const response = await fetch(`${API_BASE}/ticket/${id}`);

    if (!response.ok) {
      throw new Error('Error al obtener el ticket');
    }

    return response.json();
  },

  async deleteTicket(id) {
    const response = await fetch(`${API_BASE}/ticket/${id}`, {
      method: 'DELETE',
    });

    if (!response.ok) {
      throw new Error('Error al eliminar el ticket');
    }

    return true;
  },
};
