# GitHub Actions Setup Guide

Este documento explica cómo configurar los secretos y ajustes necesarios para el pipeline de CI/CD de AlohaPDF.

## 📋 Prerequisitos

1. Cuenta de GitHub con acceso al repositorio
2. Cuenta de NuGet.org (solo para publicación)
3. Cuenta de Codecov.io (opcional, para cobertura de código)

## 🔐 Configuración de Secretos

### 1. NUGET_API_KEY (Requerido para publicación)

Este secreto es necesario para publicar el paquete en NuGet.org.

**Pasos:**

1. Ve a [NuGet.org](https://www.nuget.org/) e inicia sesión
2. Haz clic en tu nombre de usuario → "API Keys"
3. Crea una nueva API Key:
   - **Key Name:** `AlohaPDF GitHub Actions`
   - **Glob Pattern:** `AlohaPDF*`
   - **Expiration:** Selecciona un período apropiado (ej: 365 días)
   - **Scopes:** Selecciona "Push" y "Push new packages and package versions"
4. Copia la API Key generada
5. Ve a tu repositorio de GitHub → Settings → Secrets and variables → Actions
6. Crea un nuevo secret:
   - **Name:** `NUGET_API_KEY`
   - **Value:** Pega la API Key de NuGet.org

### 2. CODECOV_TOKEN (Opcional, para cobertura de código)

Este secreto es opcional pero recomendado para visualizar la cobertura de código.

**Pasos:**

1. Ve a [Codecov.io](https://codecov.io/) e inicia sesión con tu cuenta de GitHub
2. Agrega el repositorio AlohaPDF a Codecov
3. Copia el token de upload que te proporciona Codecov
4. Ve a tu repositorio de GitHub → Settings → Secrets and variables → Actions
5. Crea un nuevo secret:
   - **Name:** `CODECOV_TOKEN`
   - **Value:** Pega el token de Codecov

## 🔄 Flujo del Pipeline

### Build and Test (Automático)

Este job se ejecuta en cada:
- Push a las ramas `master`, `main`, o `develop`
- Pull request hacia `master` o `main`

**Acciones:**
- ✅ Restaura dependencias
- ✅ Compila el proyecto en modo Release
- ✅ Ejecuta todos los tests
- ✅ Genera reporte de cobertura de código
- ✅ Sube resultados a Codecov (si está configurado)

### Pack NuGet (Automático en master/main)

Este job se ejecuta solo en pushes a `master` o `main` después de pasar los tests.

**Acciones:**
- 📦 Empaqueta el proyecto como NuGet package
- 📤 Sube el artefacto para posible publicación manual

### Publish to NuGet (En releases)

Este job se ejecuta solo cuando creas un release en GitHub.

**Acciones:**
- 🚀 Descarga el paquete NuGet
- 🌐 Publica en NuGet.org automáticamente

## 📝 Crear un Release

Para publicar una nueva versión en NuGet.org:

1. **Actualiza la versión** en `src/AlohaPDF/AlohaPDF.csproj`:
   ```xml
   <Version>1.0.0</Version>
   ```

2. **Commit y push** los cambios:
   ```bash
   git add .
   git commit -m "Bump version to 1.0.0"
   git push origin master
   ```

3. **Crea un tag**:
   ```bash
   git tag v1.0.0
   git push origin v1.0.0
   ```

4. **Crea un Release en GitHub**:
   - Ve a tu repositorio → Releases → "Draft a new release"
   - Selecciona el tag que acabas de crear (v1.0.0)
   - Título: `v1.0.0 - Release Notes`
   - Descripción: Detalla los cambios, mejoras y fixes
   - Haz clic en "Publish release"

5. **Automático**: El pipeline detectará el release y publicará en NuGet.org

## 🔍 Verificar el Pipeline

Después de configurar:

1. Ve a la pestaña "Actions" de tu repositorio
2. Deberías ver los workflows ejecutándose en cada push
3. Haz clic en cualquier workflow para ver los detalles de ejecución

## 📊 Badges

Los badges en el README se actualizan automáticamente:

- **Build Status**: Muestra si la última compilación pasó o falló
- **Codecov**: Muestra el porcentaje de cobertura de código
- **NuGet**: Muestra la última versión publicada
- **Downloads**: Muestra el total de descargas

## ⚙️ Configuración Avanzada

### Ejecutar Tests en Múltiples Plataformas

Si quieres ejecutar tests en Windows, Linux y macOS:

```yaml
build-and-test:
  strategy:
    matrix:
      os: [ubuntu-latest, windows-latest, macos-latest]
  runs-on: ${{ matrix.os }}
```

### Pre-release en NuGet

Para publicar versiones pre-release, usa sufijos en la versión:

```xml
<Version>1.0.0-beta.1</Version>
```

### Notificaciones

Para recibir notificaciones de fallos:
1. Ve a Settings → Notifications
2. Activa "GitHub Actions" en tus preferencias

## 🆘 Solución de Problemas

### El pipeline falla en "Run tests"

- Verifica que todos los tests pasen localmente: `dotnet test`
- Revisa los logs del workflow para ver qué test falló

### Falla la publicación a NuGet

- Verifica que `NUGET_API_KEY` esté configurado correctamente
- Asegúrate de que la API key tenga los permisos correctos
- Verifica que el nombre del paquete no esté ya tomado

### No aparece el badge de cobertura

- Verifica que `CODECOV_TOKEN` esté configurado
- Asegúrate de que el repositorio esté agregado en Codecov.io
- Puede tardar unos minutos en aparecer después del primer push

## 📞 Soporte

Si tienes problemas con el pipeline:
1. Revisa los logs en la pestaña Actions
2. Abre un issue en el repositorio
3. Consulta la [documentación de GitHub Actions](https://docs.github.com/en/actions)
