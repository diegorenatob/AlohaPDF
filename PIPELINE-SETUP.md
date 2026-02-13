# 🌺 AlohaPDF - CI/CD Pipeline Configurado

## ✅ ¿Qué se ha configurado?

Se ha implementado un pipeline completo de CI/CD para AlohaPDF usando GitHub Actions.

### Archivos Creados

```
AlohaPDF/
├── .github/
│   ├── workflows/
│   │   └── ci.yml                 # Pipeline principal de CI/CD
│   └── SETUP.md                   # Guía de configuración de secretos
├── .gitignore                     # Actualizado con artifacts/coverage
├── build-local.sh                 # Script para build local (Linux/macOS)
├── build-local.cmd                # Script para build local (Windows)
├── CONTRIBUTING.md                # Guía de contribución
└── README.md                      # Actualizado con badges del pipeline
```

## 🔄 Flujo del Pipeline

### 1️⃣ Build and Test (Automático)

Se ejecuta en cada **push** o **pull request** a las ramas principales.

**Acciones:**
- ✅ Instala dependencias nativas de SkiaSharp para Linux
- ✅ Restaura dependencias con `dotnet restore`
- ✅ Compila el proyecto en modo Release
- ✅ Ejecuta los 137 tests unitarios
- ✅ Genera reportes de cobertura de código
- ✅ Sube resultados a Codecov (opcional)

### 2️⃣ Pack NuGet (Automático en master/main)

Se ejecuta después de un push exitoso a `master` o `main`.

**Acciones:**
- 📦 Empaqueta el proyecto como NuGet package
- 📤 Sube el artefacto para revisión/descarga

### 3️⃣ Publish to NuGet (Manual con Release)

Se ejecuta cuando creas un **Release** en GitHub.

**Acciones:**
- 🚀 Descarga el paquete NuGet empaquetado
- 🌐 Publica automáticamente en NuGet.org

## 📋 Próximos Pasos

### 1. Configurar Secretos (Requerido para publicación)

Para publicar en NuGet.org, necesitas configurar el secreto `NUGET_API_KEY`:

1. Ve a [NuGet.org](https://www.nuget.org/) → API Keys
2. Crea una nueva API Key para "AlohaPDF"
3. En GitHub: Settings → Secrets → Actions
4. Crea el secreto `NUGET_API_KEY`

**Documentación completa:** `.github/SETUP.md`

### 2. Configurar Codecov (Opcional)

Para reportes de cobertura de código:

1. Ve a [Codecov.io](https://codecov.io/)
2. Conecta tu repositorio de GitHub
3. Copia el token de upload
4. Agrégalo como secreto `CODECOV_TOKEN` en GitHub

### 3. Probar el Pipeline Localmente

**Windows:**
```cmd
build-local.cmd
```

**Linux/macOS:**
```bash
chmod +x build-local.sh
./build-local.sh
```

Esto ejecuta exactamente los mismos pasos que el pipeline de CI.

### 4. Hacer tu Primer Push

```bash
git add .
git commit -m "feat: configurar pipeline de CI/CD"
git push origin master
```

Luego ve a la pestaña **Actions** en GitHub para ver el pipeline en acción! 🎉

### 5. Publicar tu Primera Versión

Cuando estés listo para publicar en NuGet:

```bash
# 1. Actualiza la versión en src/AlohaPDF/AlohaPDF.csproj
# <Version>1.0.0</Version>

# 2. Commit y push
git add src/AlohaPDF/AlohaPDF.csproj
git commit -m "chore: bump version to 1.0.0"
git push origin master

# 3. Crea un tag
git tag v1.0.0
git push origin v1.0.0

# 4. Crea un Release en GitHub
# Ve a Releases → Draft a new release → Selecciona el tag v1.0.0
# El pipeline publicará automáticamente en NuGet.org
```

## 📊 Badges Agregados al README

El README ahora incluye badges que se actualizan automáticamente:

- **Build Status**: [![Build](https://github.com/diegorenatob/AlohaPDF/actions/workflows/ci.yml/badge.svg)](https://github.com/diegorenatob/AlohaPDF/actions)
- **Code Coverage**: Muestra el % de cobertura de tests
- **NuGet Version**: Última versión publicada
- **Downloads**: Total de descargas del paquete

## 🎯 Verificación

### Estado Actual
- ✅ Pipeline configurado
- ✅ Scripts de build local creados
- ✅ 137 tests pasando correctamente
- ✅ Documentación completa
- ✅ .gitignore actualizado
- ✅ README actualizado con badges

### Pendiente (opcional)
- ⏳ Configurar `NUGET_API_KEY` en GitHub Secrets
- ⏳ Configurar `CODECOV_TOKEN` para cobertura
- ⏳ Probar el pipeline con un push

## 📚 Documentación

- **Pipeline Setup**: `.github/SETUP.md`
- **Contribución**: `CONTRIBUTING.md`
- **README**: `README.md`

## 🆘 Solución de Problemas

### El pipeline falla

1. Ve a Actions → Selecciona el workflow fallido
2. Revisa los logs de cada step
3. Ejecuta `build-local.cmd` para reproducir localmente

### Tests fallan en CI pero no localmente

1. Asegúrate de usar .NET 9.0
2. Limpia y recompila: `dotnet clean && dotnet build`
3. Ejecuta tests en Release: `dotnet test --configuration Release`

### No puedo publicar en NuGet

1. Verifica que `NUGET_API_KEY` esté configurado
2. Asegúrate de crear un Release (no solo un tag)
3. Revisa los permisos de la API Key en NuGet.org

## 🎉 ¡Listo!

Tu proyecto AlohaPDF ahora tiene un pipeline de CI/CD profesional que:

- ✅ Compila automáticamente en cada push
- ✅ Ejecuta tests en cada PR
- ✅ Empaqueta el NuGet automáticamente
- ✅ Publica en NuGet.org con cada release
- ✅ Genera reportes de cobertura de código

**¡Aloha y feliz codificación! 🌺🚀**

---

*¿Preguntas? Abre un issue o consulta la documentación en `.github/SETUP.md`*
