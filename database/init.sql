-- =============================================
-- ConstruSoftTicket - Script de Base de Datos
-- PostgreSQL
-- =============================================

-- Crear la tabla de Tickets
CREATE TABLE IF NOT EXISTS "Tickets" (
    "Id" SERIAL PRIMARY KEY,
    "Titulo" VARCHAR(200) NOT NULL,
    "Descripcion" TEXT NOT NULL,
    "FechaCreacion" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Datos de ejemplo
INSERT INTO "Tickets" ("Titulo", "Descripcion") VALUES
    ('Revisar instalación eléctrica piso 3', 'Se necesita revisar el cableado del piso 3, hay reportes de fallas intermitentes'),
    ('Inspección de columnas sector B', 'Realizar inspección visual y con escáner de las columnas del sector B'),
    ('Reparación de grietas en muro norte', 'Se detectaron grietas en el muro norte del edificio principal, requiere evaluación estructural'),
    ('Mantenimiento sistema de ventilación', 'Realizar mantenimiento preventivo al sistema de ventilación del sótano 2'),
    ('Revisión plomería baños piso 5', 'Fugas detectadas en los baños del piso 5, urgente reparación');
