# ReservationSystem.Application

Implementa la capa de presentación de la solución.

## NET Core + Angular

Este proyecto combina ASP.NET Core MVC .NET 5 y Angular 13.  
El directorio `ClientApp` contiene la aplicación frontend en Angular 13.  
Para evitar problemas con las compilaciones de dotnet, la carpeta `ClientApp` está excluida del proyecto .NET Core (por lo que no es visible en el archivo `.sln` de Visual Studio), pero la aplicación Angular está configurada para compilar y exportar los archivos de producción en `wwwroot/dist`.

Para más información sobre la configuración de Angular para el despliegue en .NET Core, consulta el archivo `README.NET.md` en la aplicación cliente.
