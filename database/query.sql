-- Listar tablas
\dt

-- Estructura de la tabla Tickets
\d "Tickets"

-- Todos los registros
SELECT "Id", "Titulo", "Descripcion", "FechaCreacion" FROM "Tickets" ORDER BY "Id";

-- Conteo total
SELECT COUNT(*) AS "Total_Tickets" FROM "Tickets";
