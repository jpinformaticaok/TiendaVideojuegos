# TiendaVideojuegos

Sistema de gestión para una tienda de videojuegos (consolas, juegos digitales/físicos y suscripciones), construido siguiendo la estructura del proyecto guía **InventarioISP20**.

## Proyectos

- **Services** (`net9.0`): modelos compartidos (`Cliente`, `Localidad`, `Provincia`, `Pais`, `TipoProducto`, `Producto`, `Venta`, `DetalleVenta`).
- **Backend** (`net9.0`): ASP.NET Core Web API + EF Core 8 + Npgsql (Supabase PostgreSQL). Controladores CRUD con borrado lógico (`isDeleted`) y endpoints `deleteds`/`restore`.
- **Desktop** (`net9.0-windows`): WinForms con:
  - `SplashView` (barra de progreso + carga de datos + reporte) y luego `IniciarSesionView`.
  - `IniciarSesionView` (Firebase Authentication email/password) con botón **Crear Usuario**.
  - `RegistrarUsuarioView` (alta de usuario en Firebase con email y contraseña).
  - `MenuPrincipalView` MDI con `MenuStrip` + `FontAwesome.Sharp.IconMenuItem`.
  - Vistas CRUD con `TabControl`, `DataGridView`, `FontAwesome.Sharp.IconButton`.
  - Formularios editables en el **Diseñador de Visual Studio 2022** (cada uno con su `.Designer.cs` y `.resx`).
  - Reportes con `ReportViewerCore.WinForms` (`ViewReports`).
  - Imágenes pequeñas de productos (`PictureBox`) desde Supabase Storage.

## Flujo de la aplicación

```
SplashView  →  IniciarSesionView  →  MenuPrincipalView
```

El splash verifica la conexión y prepara el reporte; al terminar abre el login.
Si el login es correcto se abre el menú principal (MDI); si se cancela, la aplicación se cierra.

Desde el login, el botón **Crear Usuario** abre `RegistrarUsuarioView`, que registra la cuenta en
Firebase (Email/Password), valida email, mínimo de 6 caracteres y repetición de contraseña, y al
finalizar deja el email cargado en el login para ingresar la contraseña.

## Trabajar con el Diseñador de Visual Studio

Los 10 formularios siguen la estructura estándar de WinForms, por lo que se pueden abrir y
editar visualmente en Visual Studio 2022:

| Formulario | Archivos |
| --- | --- |
| `SplashView` | `Desktop/Views/SplashView.cs` + `.Designer.cs` + `.resx` |
| `IniciarSesionView` | `Desktop/Views/IniciarSesionView.cs` + `.Designer.cs` + `.resx` |
| `RegistrarUsuarioView` | `Desktop/Views/RegistrarUsuarioView.cs` + `.Designer.cs` + `.resx` |
| `MenuPrincipalView` | `Desktop/Views/MenuPrincipalView.cs` + `.Designer.cs` + `.resx` |
| `ClientesView` | `Desktop/Views/ClientesView.cs` + `.Designer.cs` + `.resx` |
| `TiposProductoView` | `Desktop/Views/TiposProductoView.cs` + `.Designer.cs` + `.resx` |
| `ProductosView` | `Desktop/Views/ProductosView.cs` + `.Designer.cs` + `.resx` |
| `VentasView` | `Desktop/Views/VentasView.cs` + `.Designer.cs` + `.resx` |
| `ClientesViewReport` | `Desktop/ViewReports/ClientesViewReport.cs` + `.Designer.cs` + `.resx` |
| `ProductosViewReport` | `Desktop/ViewReports/ProductosViewReport.cs` + `.Designer.cs` + `.resx` |

- Para abrir el diseñador: clic derecho sobre el `.cs` → **Ver diseñador** (o `Shift+F7`).
- El `.Designer.cs` contiene `InitializeComponent()` y las declaraciones de los controles: se edita
  desde el diseñador, no a mano. La lógica queda en el `.cs`.
- Los logos del splash y del login se dibujan en tiempo de ejecución (`CrearImagenSplash` /
  `CrearLogo`), así que en el diseñador esos `PictureBox` aparecen vacíos. Los datos de las grillas,
  las imágenes de productos y los reportes también se cargan en tiempo de ejecución.
- Los controles `IconButton`/`IconMenuItem` (FontAwesome.Sharp) y `ReportViewer`
  (ReportViewerCore.WinForms) vienen de NuGet: hay que restaurar los paquetes antes de abrir el
  diseñador.

## Datos de prueba (semilla)

Las migraciones `SeedProductos` y `SeedProductosYVentas` cargan los siguientes datos:

| Tabla | Registros |
| --- | --- |
| `paises` | Argentina, Brasil, Chile |
| `provincias` | Buenos Aires, Córdoba, Santa Fe |
| `localidades` | Buenos Aires, Córdoba, Santa Fe, Rosario, San Justo |
| `clientes` | Juan Pablo Aguero, María González, Pedro López |
| `tipos_producto` | Consola, Juego, Suscripción |
| `productos` | 10 productos (3 consolas, 4 juegos, 3 suscripciones) con imagen pública en Supabase Storage |
| `ventas` / `detalles_venta` | 3 facturas de ejemplo: `FAC-00001`, `FAC-00002`, `FAC-00003` |

La numeración de facturas es local y correlativa (`FAC-00001`, `FAC-00002`, ...).

Usuario de prueba de Firebase (Email/Password):

```
Usuario:    test@tienda.com
Contraseña: Tienda1234
```

También se pueden crear usuarios nuevos desde el botón **Crear Usuario** del login; quedan
registrados en el proyecto de Firebase y pueden iniciar sesión inmediatamente.

## Endpoints utilizados

| Servicio | Endpoint |
| --- | --- |
| Firebase Auth (login) | `POST https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=APIKEYFIREBASE` |
| Firebase Auth (alta) | `POST https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=APIKEYFIREBASE` |
| Backend (splash y API) | `https://api-tiendavideojuegos-jp.azurewebsites.net/api/` |
| Supabase REST | `https://sukjueyvigrcyafzppjx.supabase.co/rest/v1/` (`clientes`, `localidades`, `provincias`, `paises`, `productos`, `tipos_producto`, `ventas`, `detalles_venta`) |
| Supabase Storage | `https://sukjueyvigrcyafzppjx.supabase.co/storage/v1/object/public/productos/` |

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

> El archivo `.env` se copia automáticamente a la carpeta de salida al compilar, y `EnvConfig` lo busca desde la carpeta de la aplicación hacia arriba, por lo que funciona igual desde Visual Studio o ejecutando el `.exe`.

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

El workflow `.github/workflows/deploy.yml` compila el backend y lo publica en Azure Web App
(`api-tiendavideojuegos-jp`) usando **OpenID Connect** (sin publish profile):

1. `azure/login@v2` inicia sesión con la identidad federada del repositorio
   (secrets `AZURE_CLIENT_ID`, `AZURE_TENANT_ID`, `AZURE_SUBSCRIPTION_ID`).
2. `az webapp deploy --type zip` sube el paquete publicado.

La credencial federada se creó sobre la app registration `gh-tiendavideojuegos-deploy`
con el subject `repo:jpinformaticaok/TiendaVideojuegos:ref:refs/heads/main` y su variante
con IDs inmutables, y el service principal tiene el rol *Website Contributor* sobre el
resource group `tiendavideojuegos-rg`.
