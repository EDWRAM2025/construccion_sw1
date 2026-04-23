# 🏗️ ConstruSoftTicket

Sistema de gestión de tickets para proyectos de construcción, desarrollado con **Clean Architecture**.

## 📋 Arquitectura del Proyecto

```
ConstruSoftTicket_1/
├── backend/
│   ├── ConstruSoftTicket.Domain/          # Entidades del dominio
│   │   └── Entities/
│   │       └── Ticket.cs
│   ├── ConstruSoftTicket.Application/     # Lógica de negocio
│   │   ├── DTOs/
│   │   │   └── CreateTicketDto.cs
│   │   ├── Interfaces/
│   │   │   ├── ITicketRepository.cs
│   │   │   └── ITicketService.cs
│   │   └── Services/
│   │       └── TicketService.cs
│   ├── ConstruSoftTicket.Infrastructure/  # Acceso a datos
│   │   ├── Data/
│   │   │   └── AppDbContext.cs
│   │   └── Repositories/
│   │       └── TicketRepository.cs
│   └── ConstruSoftTicket.API/             # Web API
│       ├── Controllers/
│       │   └── TicketController.cs
│       └── Program.cs
├── frontend/                               # React + Vite
│   └── src/
│       ├── pages/
│       │   └── CreateTicket.jsx
│       └── services/
│           └── ticketService.js
├── database/
│   └── init.sql
└── docker-compose.yml
```

## 🛠️ Tecnologías

| Capa | Tecnología |
|------|-----------|
| **Backend** | .NET 9, ASP.NET Core Web API |
| **Frontend** | React 18, Vite |
| **Base de Datos** | PostgreSQL 16 |
| **ORM** | Entity Framework Core 9 |
| **Contenedores** | Docker, Docker Compose |
| **Arquitectura** | Clean Architecture |

## 🚀 Cómo ejecutar

### 1. Levantar PostgreSQL con Docker

```bash
docker-compose up -d
```

### 2. Backend (.NET)

```bash
cd backend
dotnet restore
dotnet run --project ConstruSoftTicket.API
```

El backend estará en: `http://localhost:5151`

### 3. Frontend (React)

```bash
cd frontend
npm install
npm run dev
```

El frontend estará en: `http://localhost:5173`

## 📡 Endpoints API

| Método | Ruta | Descripción |
|--------|------|-------------|
| `POST` | `/api/ticket` | Crear un nuevo ticket |
| `GET` | `/api/ticket` | Obtener todos los tickets |
| `GET` | `/api/ticket/{id}` | Obtener un ticket por ID |

## 👥 Integrantes

- EDWRAM2025

## 📄 Licencia

Proyecto académico — Construcción de Software I
