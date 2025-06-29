# Krispy Kreme Examen

Proyecto Full Stack con ASP.NET Core 8 y Vue.js 3 para la gestión de usuarios y ventas.

## 📦 Estructura del Proyecto

```
├── app-prueba-vue/             # Frontend Vue 3
├── servicio/                   # Backend ASP.NET Core 8
├── infraestructura/            # Acceso a datos y persistencia
├── Modelo/                     # Clases de dominio y DTOs
├── appPrueba.sln               # Solución principal
```

## ✅ Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Node.js v18+ y npm
- SQL Server (local)
- (Opcional) Visual Studio 2022 o VS Code
- Swagger incluido para pruebas de API

## ⚙️ Configuración del Backend

1. Abrir la solución `appPrueba.sln` en Visual Studio o VS Code.

2. Verificar el archivo `appsettings.json` (en el proyecto backend):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=KrispyKremeDB;User Id=KrispyKremeAdmin;Password=KrispyKremeAdmin;TrustServerCertificate=True;"
}
```

3. Crear la base de datos ejecutando el siguiente script SQL:

```sql
-- Incluye creación de tablas 'usuarios' y 'ventas'
-- Con relaciones, descripciones y datos iniciales (ver script SQL proporcionado)
```

4. Restaurar paquetes NuGet:

```bash
dotnet restore
```

5. Ejecutar la API:

```bash
dotnet run --project servicio
```

La API estará disponible en `https://localhost:{puerto}/swagger`

## 💻 Frontend (Vue 3 + Vite)

1. Ir a la carpeta del frontend:

```bash
cd app-prueba-vue
```

2. Instalar dependencias:

```bash
npm install
```

3. Ejecutar en modo desarrollo:

```bash
npm run dev
```

## 👤 Credenciales de prueba

```txt
Usuario: abel
Contraseña: 123456
Rol: Admin
```

```txt
Usuario: vendedor1
Contraseña: 123456
Rol: Ventas
```

## 🛠 Características

- Login con JWT
- Control de acceso por roles
- Gestión de ventas
- Panel de usuarios (solo Admin)
- Vue 3 + Vuetify 3 para la interfaz
- Swagger UI para probar endpoints

---

© 2025 Krispy Kreme Challenge