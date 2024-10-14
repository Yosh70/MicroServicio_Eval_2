# Introduction 
TODO: Microservicio Evaluacion 2 

# Getting Started
TODO: Guia de Usuario: 

Prerequisitos
1.	.NET 8.0
2.	Microsoft SQL Server 2019
3.	Visual Studio 2022
4.	GIT

# Build and Test
TODO: Primeros pasos.

1. Visual Studio
1.1 appsettings.json: Modificar la cadena de conexion a la base de datos.
1.2 Consola de administrador de paquetes: Ejecutar los siguientes comandos para crear las migraciones de base de datos:
 - Add-Migration InitialCreate -p WebAPITienda -s WebAPITienda -c TiendaContext
 - Update-Database InitialCreate -p WebAPITienda -s WebAPITienda -context TiendaContext
1.3 Swagger: Se añade al proyecto cliente de pruebas. 

# Contribute
TODO: Se que el codigo se puede mejorar, me faltaron varias configuraciones, validaciones
	  y por practicidad de lectura cree un solo proyecto.

	  Debido a que esta pensado para desacoplarse,
	  se puede seccionar las funciones y añadirlas a proyectos adicionales. 

