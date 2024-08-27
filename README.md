# DelfostiChallenge - Backend Developer

API desarrollada como parte del reto técnico para Delfosti.

## Tecnologías Utilizadas

- .NET 8
- MySQL
- Entity Framework Core

## Requisitos Previos

- MySQL
- .NET 8 (SDK) 

## Ejecución del Proyecto utilizando Visual Studio 2022

1. Clonar el repositorio
2. Abrir la solución con Visual Studio 2022
3. Configurar la cadena de conexión en el archivo `appsettings.Development.json`:
```bash
"ConnectionStrings": {
  "DBMYSQL": "Server=localhost;Port=3306;Database=delfostichallengedb;User=root;Password=root"
}
```
4. Abrir la consola `Package Manager Console`, asegurarse de seleccionar como Default project `DelfostiChallenge.Repository` y ejecutar los comandos: 
- `Add-Migration InitialCreate`
- `Update-Database`
  
5. Con esto se ejecutaron las migraciones de Entity Framework Core y debe haberse creado la base de datos `delfostichallengedb` o el nombre que haya configurado en el archivo `appsettings.Development.json`
6. Se ha implementado Data Seeding en el proyecto por lo que habrá datos de prueba para facilitar la revisón de la API.

## Documentación de la API (Swagger UI)
- La API facilita la interfáz gráfica de Swagger UI como apoyo para la documentación y pruebas.

