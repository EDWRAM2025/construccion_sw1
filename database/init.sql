-- =============================================
-- ConstruSoftTicket - Script de Base de Datos
-- PostgreSQL
-- =============================================

-- Nota: La base de datos se crea automáticamente por docker-compose
-- y las tablas se crean por Entity Framework Core (EnsureCreated)

-- Si necesitas crear manualmente:

-- CREATE TABLE "Tickets" (
--     "Id" SERIAL PRIMARY KEY,
--     "Titulo" VARCHAR(200) NOT NULL,
--     "Descripcion" TEXT NOT NULL,
--     "FechaCreacion" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
-- );

-- Datos de ejemplo (opcional):
-- INSERT INTO "Tickets" ("Titulo", "Descripcion") VALUES
--     ('Revisar instalación eléctrica piso 3', 'Se necesita revisar el cableado del piso 3, hay reportes de fallas intermitentes'),
--     ('Inspección de columnas sector B', 'Realizar inspección visual y con escáner de las columnas del sector B');
