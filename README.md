# TiendaVideojuegos

Sistema de gestión para una tienda de videojuegos (consolas, juegos digitales/físicos y suscripciones), construido siguiendo la estructura del proyecto guía **InventarioISP20**.

## Proyectos

- **Services** (`net9.0`): modelos compartidos (`Cliente`, `Localidad`, `Provincia`, `Pais`, `TipoProducto`, `Producto`, `Venta`, `DetalleVenta`).
- **Backend** (`net9.0`): ASP.NET Core Web API + EF Core 8 + Npgsql (Supabase PostgreSQL). Controladores CRUD con borrado lógico (`isDeleted`) y endpoints `deleteds`/`restore`.
- **Desktop** (`net9.0-windows`): WinForms con:
  - `SplashView` (barra de progreso + carga de datos + reporte).
  - `IniciarSesionView` (Firebase Authentication email/password).
  - `MenuPrincipalView` MDI con `MenuStrip` + `FontAwesome.Sharp.IconMenuItem`.
  - Vistas CRUD con `TabControl`, `DataGridView`, `FontAwesome.Sharp.IconButton`.
  - Reportes con `ReportViewerCore.WinForms` (`ViewReports`).
  - Imágenes pequeñas de productos (`PictureBox`) desde Supabase Storage.

## Requisitos

- .NET 9 SDK
- Visual Studio 2022 (17.14 o superior)
- Cuenta de Supabase (PostgreSQL + Storage + PostgREST)
- Proyecto de Firebase con Email/Password habilitado
- Azure App Service (backend)
- GitHub (código fuente)

## Configuración

### Desktop
Copiar `Desktop/.env.example` a `Desktop/.env` y completar:

```
apikey_supabase="..."
supabase_clientes_endpoint="https://<ref>.supabase.co/rest/v1/clientes"
...
URLAPI="https://<app>.azurewebsites.net/api/"
AUTHDOMAINFB="<proyecto>.firebaseapp.com"
APIKEYFIREBASE="..."
```

### Backend
Copiar `Backend/appsettings.example.json` a `Backend/appsettings.json` y configurar la cadena de conexión a Supabase. En Azure se configura como App Setting `ConnectionStrings__DefaultConnection`.

### Base de datos
1. Aplicar migraciones:
   ```
   dotnet ef database update --project Backend/Backend.csproj --startup-project Backend/Backend.csproj
   ```
2. Ejecutar `Database/grants.sql` para que PostgREST (`service_role`) pueda acceder a las tablas.
3. Crear el bucket público `productos` en Supabase Storage.

## Ejecutar

```
dotnet build TiendaVideojuegos.sln
```

Abrir `TiendaVideojuegos.sln` en Visual Studio 2022 y ejecutar el proyecto **Desktop**.

## Despliegue

El workflow `.github/workflows/deploy.yml` compila y publica el backend en Azure Web App usando el secret `AZURE_WEBAPP_PUBLISH_PROFILE`.
