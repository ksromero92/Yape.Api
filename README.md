# Yape.Api


📌 Reto Técnico - Yape Bolivia
📖 Descripción
Este proyecto implementa un servicio WCF en .NET Framework 4.8 y una API REST en .NET 8 con una arquitectura bien estructurada.

🛠️ Arquitectura
1️⃣ Servicio WCF (.NET Framework 4.8)
Patrón: N-Capas.
Tecnologías: WCF, MySQL, Entity Framework.
Estructura:
Yape.WcfService.Contracts → Interfaces y modelos compartidos.
Yape.WcfService.Data → Acceso a datos con MySQL.
Yape.WcfService.Business → Lógica de negocio.
Yape.WcfService.Host → Servicio WCF.


2️⃣ API REST (.NET 8)
Patrón: Arquitectura Hexagonal (Puertos y Adaptadores).
Tecnologías: .NET 8, Entity Framework Core, MySQL.
Endpoints: Permite registrar clientes y consulta el servicio WCF para validar datos.
📡 Endpoints y Pruebas
📍 Registrar un Cliente
sh
Copiar
Editar
curl --location 'https://localhost:7182/api/Client' \
--header 'Content-Type: application/json' \
--data '{
  "name": "Juan",
  "lastName": "Perez",
  "cellPhoneNumber": "7654321",
  "documentType": "DNI",
  "documentNumber": "12345678"
}'


📊 Base de Datos (MySQL)
📍 Creación de la Base de Datos y Tabla
sql
Copiar
Editar
CREATE DATABASE yape_db;
USE yape_db;

CREATE TABLE persons (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cellPhoneNumber VARCHAR(20) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    DocumentType VARCHAR(50) NOT NULL,
    DocumentNumber VARCHAR(50) NOT NULL
);
🚀 Cómo Ejecutar el Proyecto


1️⃣ Configurar el Servicio WCF
Compilar y ejecutar Yape.WcfService.Host.
Verificar que el WSDL esté disponible en http://localhost:65442/PersonService.svc?wsdl.


2️⃣ Configurar la API REST
Configurar la conexión a MySQL en appsettings.json.
Ejecutar migraciones de Entity Framework (si aplica).
Levantar el proyecto y probar con curl o Postman.
📎 Notas
Se recomienda usar Postman para probar los endpoints.
Revisar el web.config y appsettings.json para configurar correctamente las conexiones.
