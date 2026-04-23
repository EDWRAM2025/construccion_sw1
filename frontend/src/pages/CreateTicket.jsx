import { useState, useEffect } from 'react';
import { ticketService } from '../services/ticketService';

function CreateTicket() {
  const [titulo, setTitulo] = useState('');
  const [descripcion, setDescripcion] = useState('');
  const [tickets, setTickets] = useState([]);
  const [message, setMessage] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    loadTickets();
  }, []);

  const loadTickets = async () => {
    try {
      const data = await ticketService.getAllTickets();
      setTickets(data);
    } catch (error) {
      console.error('Error cargando tickets:', error);
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!titulo.trim() || !descripcion.trim()) return;

    setLoading(true);
    setMessage(null);

    try {
      await ticketService.createTicket({ titulo, descripcion });
      setMessage({ type: 'success', text: '✅ Ticket creado exitosamente' });
      setTitulo('');
      setDescripcion('');
      await loadTickets();
    } catch (error) {
      setMessage({ type: 'error', text: '❌ Error al crear el ticket. Verifica que el backend esté corriendo.' });
    } finally {
      setLoading(false);
      setTimeout(() => setMessage(null), 4000);
    }
  };

  const handleDelete = async (id) => {
    if (!window.confirm('¿Estás seguro de eliminar este ticket?')) return;
    try {
      await ticketService.deleteTicket(id);
      setMessage({ type: 'success', text: '✅ Ticket eliminado exitosamente' });
      await loadTickets();
    } catch (error) {
      setMessage({ type: 'error', text: '❌ Error al eliminar el ticket' });
    } finally {
      setTimeout(() => setMessage(null), 4000);
    }
  };

  const formatDate = (dateString) => {
    return new Date(dateString).toLocaleString('es-ES', {
      day: '2-digit',
      month: 'short',
      year: 'numeric',
      hour: '2-digit',
      minute: '2-digit',
    });
  };

  return (
    <div className="app-container">
      {/* Header */}
      <header className="app-header">
        <div className="app-header__logo">
          <div className="app-header__icon">🏗️</div>
          <h1 className="app-header__title">ConstruSoftTicket</h1>
        </div>
        <p className="app-header__subtitle">
          Sistema de gestión de tickets para proyectos de construcción
        </p>
      </header>

      {/* Main Grid */}
      <div className="main-grid">
        {/* Create Ticket Form */}
        <div className="card" style={{ animationDelay: '0.1s' }}>
          <div className="card__header">
            <div className="card__header-icon card__header-icon--create">✏️</div>
            <h2 className="card__title">Nuevo Ticket</h2>
          </div>

          {message && (
            <div className={`alert alert--${message.type}`}>
              {message.text}
            </div>
          )}

          <form onSubmit={handleSubmit} id="create-ticket-form">
            <div className="form-group">
              <label htmlFor="ticket-titulo">Título</label>
              <input
                id="ticket-titulo"
                type="text"
                className="form-input"
                placeholder="Ej: Revisar instalación eléctrica piso 3"
                value={titulo}
                onChange={(e) => setTitulo(e.target.value)}
                required
              />
            </div>

            <div className="form-group">
              <label htmlFor="ticket-descripcion">Descripción</label>
              <textarea
                id="ticket-descripcion"
                className="form-textarea"
                placeholder="Describe el problema o tarea a realizar..."
                value={descripcion}
                onChange={(e) => setDescripcion(e.target.value)}
                required
              />
            </div>

            <button
              type="submit"
              className="btn btn--primary"
              id="submit-ticket-btn"
              disabled={loading || !titulo.trim() || !descripcion.trim()}
            >
              {loading ? '⏳ Creando...' : '🚀 Crear Ticket'}
            </button>
          </form>
        </div>

        {/* Ticket List */}
        <div className="card" style={{ animationDelay: '0.2s' }}>
          <div className="card__header">
            <div className="card__header-icon card__header-icon--list">📋</div>
            <h2 className="card__title">Tickets Registrados</h2>
            {tickets.length > 0 && (
              <span className="counter-badge">{tickets.length}</span>
            )}
          </div>

          <div className="ticket-list">
            {tickets.length === 0 ? (
              <div className="ticket-list__empty">
                <div className="ticket-list__empty-icon">📭</div>
                <p className="ticket-list__empty-text">
                  No hay tickets creados aún.<br />
                  ¡Crea el primero!
                </p>
              </div>
            ) : (
              tickets.map((ticket) => (
                <div className="ticket-item" key={ticket.id}>
                  <div className="ticket-item__header">
                    <span className="ticket-item__id">#{ticket.id}</span>
                    <button
                      className="btn-delete"
                      onClick={() => handleDelete(ticket.id)}
                      title="Eliminar ticket"
                    >
                      🗑️
                    </button>
                  </div>
                  <h3 className="ticket-item__title">{ticket.titulo}</h3>
                  <p className="ticket-item__description">{ticket.descripcion}</p>
                  <div className="ticket-item__date">
                    🕐 {formatDate(ticket.fechaCreacion)}
                  </div>
                </div>
              ))
            )}
          </div>
        </div>
      </div>

      {/* Footer */}
      <footer className="app-footer">
        <p>ConstruSoftTicket © 2025 — Clean Architecture con .NET 9, React y PostgreSQL</p>
      </footer>
    </div>
  );
}

export default CreateTicket;
