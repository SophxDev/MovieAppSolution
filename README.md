# 🎬 MovieAppSolution – API REST + Razor UI con ASP.NET Core

Aplicación full stack en **C# / ASP.NET Core** para gestionar películas y actores.  
Incluye una **Web API limpia y bien estructurada** y una **interfaz web en Razor** para visualizar el catálogo.

Pensado como proyecto de portafolio para demostrar:
- Buenas prácticas de arquitectura en .NET
- Uso de patrones (SRP, DIP, OCP)
- Trabajo con **PostgreSQL + EF Core**
- Validaciones con FluentValidation
- Mapeos con AutoMapper
- UI con Razor + TailwindCSS

---

## 🧩 Solución y proyectos

El repositorio contiene **2 proyectos** dentro de la solución `MovieAppSolution.sln`:

```bash
MovieAppSolution/
│
├── MovieApp.API/        # Backend: ASP.NET Core Web API (PostgreSQL + EF Core)
└── MovieApp.RazorUI/    # Frontend: Razor UI (Razor Pages + TailwindCSS)
```
---


## 🚀 Tecnologías principales

Backend – MovieApp.API:
- ASP.NET Core Web API
- C#
- Entity Framework Core (PostgreSQL)
- AutoMapper
- FluentValidation
- Inyección de dependencias (DI)
- Swagger / OpenAPI

Frontend – MovieApp.RazorUI:
- ASP.NET Core Razor Pages
- C#
- Razor Views / Pages
- TailwindCSS
- Bootstrap (para algunos estilos base)
- Consumo de API vía servicios HTTP

---


## 🧠 Arquitectura y buenas prácticas

- La API está organizada para respetar principios SOLID y separación por capas:

- Práctica / Principio	Cómo se aplica

- SRP (Single Responsibility)	Carpetas separadas: Controllers, Services, Repositories, DTOs, Validators, etc.

- DIP (Dependency Inversion)	Uso de interfaces en Repositories/Interfaces y Services/Interfaces + inyección de dependencias en Program.cs.

- OCP (Open/Closed)	Repositorios y servicios extensibles sin modificar código existente (nuevos métodos → nuevas implementaciones).

- DTOs	DTOs/ para separar modelos de dominio de los contratos expuestos por la API.

- AutoMapper	Mappings/AutoMapperProfile.cs para mapear DTO ↔ entidades.

- FluentValidation	Validators/ centraliza reglas de validación testables y reutilizables.

- Swagger	Documentación automática de los endpoints de la API.

- EF Core + PostgreSQL	DbContext (Data/ApplicationDbContext.cs) y migraciones en Migrations/.


---


## 🧠 Estructura general – MovieApp.API:
```bash
MovieApp.API/
│
├── Controllers/                 # Rutas HTTP (API pública)
│   ├── MovieController.cs
│   └── ActorController.cs
│
├── Data/
│   └── ApplicationDbContext.cs  # DbContext y configuración de EF Core
│
├── DTOs/                        # Objetos de transferencia (entrada/salida)
│   ├── MovieCreateDto.cs
│   ├── MovieUpdateDto.cs
│   ├── MovieReadDto.cs
│   ├── ActorCreateDto.cs
│   ├── ActorUpdateDto.cs
│   └── ActorReadDto.cs
│
├── Models/                      # Entidades de dominio
│   ├── Movie.cs
│   ├── Actor.cs
│   └── MovieActor.cs           # Relación N:N
│
├── Repositories/                # Acceso a datos (EF Core)
│   ├── Interfaces/
│   │   ├── IMovieRepository.cs
│   │   └── IActorRepository.cs
│   └── MovieRepository.cs
│       ActorRepository.cs
│
├── Services/                    # Lógica de negocio
│   ├── Interfaces/
│   │   ├── IMovieService.cs
│   │   └── IActorService.cs
│   └── MovieService.cs
│       ActorService.cs
│
├── Validators/                  # Validaciones (FluentValidation)
│   ├── MovieCreateValidator.cs
│   ├── MovieUpdateValidator.cs
│   ├── ActorCreateValidator.cs
│   └── ActorUpdateValidator.cs
│
├── Mappings/                    # Perfiles de AutoMapper
│   └── AutoMapperProfile.cs
│
├── appsettings.json             # Configuración real (IGNORADO en Git)
├── appsettings.example.json     # Plantilla sin credenciales
└── Program.cs                   # Configuración de servicios, DI, EF, Swagger, etc.
```


🎨 Estructura general – MovieApp.RazorUI:

```bash
MovieApp.RazorUI/
│
├── Pages/                       # Razor Pages (UI)
│   ├── Index.cshtml             # Catálogo de películas
│   ├── Privacy.cshtml
│   ├── Error.cshtml
│   └── Shared/
│       ├── _Layout.cshtml       # Layout principal
│       └── _ValidationScriptsPartial.cshtml
│
├── Models/
│   └── Movie.cs                 # Modelo usado en el frontend
│
├── Services/
│   └── MovieService.cs          # Consumo de la API MovieApp.API
│
├── wwwroot/                     # Archivos estáticos
│   ├── css/
│   │   ├── site.css
│   │   └── tailwind.css
│   ├── js/site.js
│   └── lib/…                    # Bootstrap, jQuery, etc.
│
├── appsettings.json             # Config local (IGNORADO en Git)
├── appsettings.example.json     # Plantilla sin datos sensibles
├── Program.cs                   # Configuración del host Razor
└── tailwind.config.js           # Configuración de TailwindCSS

```
---


## 🔐 Manejo de configuración y seguridad

Los archivos sensibles NO se suben al repositorio gracias a .gitignore:
- appsettings.json
- appsettings.Development.json
- appsettings.*.local.json

En su lugar, cada proyecto incluye un archivo de ejemplo:

- MovieApp.API/appsettings.example.json
- MovieApp.RazorUI/appsettings.example.json

## ¿Cómo usarlos?

Copiar el archivo de ejemplo:
1. appsettings.example.json → appsettings.json
2. Editar appsettings.json con tus valores reales:
```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=MovieAppDB;Username=tu_usuario;Password=tu_password"
  }
}
```
---



## 🛠 Requisitos previos:
- .NET SDK instalado (versión compatible con el proyecto)
- PostgreSQL (local o en contenedor)
- Node.js + npm (para TailwindCSS, si quieres recompilar estilos)
- Git

---
  

▶️ Cómo ejecutar el proyecto en local:

- Clonar el repositorio
```bash
git clone https://github.com/SophxDev/MovieAppSolution.git
cd MovieAppSolution
```

- Configurar la API (MovieApp.API):

1. Entrar a la carpeta del proyecto API:
cd MovieApp.API
Copiar el archivo de ejemplo:
copy appsettings.example.json appsettings.json

2. Editar appsettings.json y colocar tu cadena de conexión de PostgreSQL.
Aplicar migraciones (si es necesario):
dotnet ef database update

3. Ejecutar la API:
dotnet run

4. Por defecto se levanta en algo como:
```bash
https://localhost:7xxx
http://localhost:5xxx
```

5. Abrir Swagger en el navegador:
https://localhost:7xxx/swagger

- Configurar la UI (MovieApp.RazorUI)
1. Desde la raíz de la solución:
cd ../MovieApp.RazorUI

2. Copiar el archivo de ejemplo:
copy appsettings.example.json appsettings.json


3. Asegurarte de que appsettings.json tenga la URL base de la API:
```bash
{
  "ApiBaseUrl": "https://localhost:7xxx"
}
```

4. Ejecutar la UI:
```bash
dotnet run
```

6. Abrir el navegador:
https://localhost:7yyy


7. Verás el catálogo de películas consumiendo los datos desde la API.

---


## 📡 Endpoints principales (API)

GET /api/movies – Listado de películas
GET /api/movies/{id} – Detalle de una película
POST /api/movies – Crear película
PUT /api/movies/{id} – Actualizar película
DELETE /api/movies/{id} – Eliminar película

(De forma similar para actores).

Toda la API está documentada en Swagger.


---


## 🧪 Posibles mejoras futuras (roadmap):

Autenticación y autorización (JWT + roles)
Paginación y filtros en listados de películas
Subida de imágenes a un servicio externo (ej. Cloudinary / Azure Blob)
Pruebas unitarias (xUnit / NUnit) para servicios y validadores
Pruebas de integración para la API
Pruebas automatizadas de UI (Playwright / Selenium)
Deploy en Azure / Railway / Render

---

👤 Autora

SophxDev
Software Developer & QA Automation.

⚡ GitHub: SophxDev
💼 Linkedin: https://www.linkedin.com/in/jaquelineespino/

---
