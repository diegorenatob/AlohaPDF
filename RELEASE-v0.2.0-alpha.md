# 🚀 Release v0.2.0-alpha - Instrucciones

## ✅ Cambios Completados

- ✅ Versión actualizada a `0.2.0-alpha` en `AlohaPDF.csproj`
- ✅ Pipeline CI/CD corregido para publicar en releases
- ✅ Release notes actualizadas con mejoras
- ✅ Secret `NUGET_API_KEY` configurado en GitHub
- ✅ 137 tests pasando correctamente
- ✅ SkiaSharp dependencies configuradas para Linux CI
- ✅ Logo del paquete creado y configurado (`logo.png`)

## 🎯 ¿Por Qué 0.2.0-alpha?

La versión 0.1.0-alpha tuvo problemas con el pipeline. Esta versión incluye:
- ✅ Pipeline corregido (pack y publish funcionan en releases)
- ✅ Mejor configuración de SkiaSharp para CI/CD
- ✅ Documentación completa del proceso

## 📝 Pasos para Publicar

### 1️⃣ Commit y Push

```bash
git add .
git commit -m "chore: bump version to 0.2.0-alpha

- Actualizada versión a 0.2.0-alpha
- Pipeline CI/CD corregido para releases
- SkiaSharp dependencies configuradas
- Agregado logo del paquete
- 137 tests pasando"

git push origin master
```

### 2️⃣ Verificar Build

1. Ve a: https://github.com/diegorenatob/AlohaPDF/actions
2. Espera que el workflow complete:
   - ✅ `build-and-test` - Tests deben pasar
   - ✅ `pack` - Debe crear `AlohaPDF.0.2.0-alpha.nupkg`

### 3️⃣ Crear Tag

```bash
git tag v0.2.0-alpha
git push origin v0.2.0-alpha
```

### 4️⃣ Crear Release en GitHub

1. Ve a: https://github.com/diegorenatob/AlohaPDF/releases/new

2. Configura:
   - **Choose a tag:** `v0.2.0-alpha`
   - **Release title:** `v0.2.0-alpha - Second Alpha Release`

3. **Description:** (copia y pega)

```markdown
## 🌺 AlohaPDF v0.2.0-alpha - Second Alpha Release

⚠️ **This is an alpha version** for testing and community feedback.

### ✨ What's New in 0.2.0-alpha

- 🔧 Fixed CI/CD pipeline for proper NuGet publishing
- ✅ Complete test suite with 137 passing tests
- 🐧 SkiaSharp native dependencies properly configured for Linux
- 📚 Improved documentation and setup guides
- 🚀 Automated release workflow to NuGet.org

### 📦 Features

- 🎨 Fluent API for intuitive PDF generation
- 📄 Support for sections, paragraphs, tables, and lists
- 🌴 Modern tropical-themed styling out of the box
- 🔄 Cross-platform support (.NET 9)
- ⚡ SkiaSharp-based high-performance rendering

### 📥 Installation

```bash
dotnet add package AlohaPDF --version 0.2.0-alpha
```

### 🚀 Quick Start

```csharp
using AlohaPDF;
using AlohaPDF.Core;

var pdf = new AlohaPdfDocument();

pdf.Initialize(new PdfDocumentOptions 
{
    Title = "My First PDF",
    Subtitle = "Created with AlohaPDF",
    PageSize = PageSize.A4
});

pdf.AddSection("Introduction")
   .AddParagraph("Welcome to AlohaPDF! This is a sample document.")
   .AddSection("Features")
   .AddList(new[] { "Easy to use", "Beautiful output", "Cross-platform" }, isNumbered: true);

pdf.Generate("output.pdf");
```

### 🐛 Known Issues

- Some advanced features may have rough edges
- Documentation is still being expanded
- **Breaking changes may occur** in future alpha/beta versions

### 📝 Feedback & Contributions

We'd love to hear your feedback!

- 🐛 [Report Issues](https://github.com/diegorenatob/AlohaPDF/issues)
- 💡 [Request Features](https://github.com/diegorenatob/AlohaPDF/discussions)
- 🤝 [Contribute](https://github.com/diegorenatob/AlohaPDF/blob/master/CONTRIBUTING.md)

### 📚 Documentation

- [README](https://github.com/diegorenatob/AlohaPDF/blob/master/README.md)
- [Quick Start Guide](https://github.com/diegorenatob/AlohaPDF/blob/master/README.md#-quick-start)
- [Pipeline Setup](.github/SETUP.md)
- [Contributing Guide](CONTRIBUTING.md)

### 🔄 Upgrading from 0.1.0-alpha

Simply update your package reference:

```bash
dotnet remove package AlohaPDF
dotnet add package AlohaPDF --version 0.2.0-alpha
```

---

**Aloha! 🌺** Thank you for being an early adopter and helping us improve AlohaPDF.
```

4. **IMPORTANTE:** ✅ Marca **"Set as a pre-release"**
5. Click **"Publish release"**

### 5️⃣ Verificar Publicación

1. **GitHub Actions** (2-5 minutos):
   - Job `publish` debe ejecutarse automáticamente
   - Verifica en: https://github.com/diegorenatob/AlohaPDF/actions
   - Debes ver:
     - ✅ Build and Test
     - ✅ Pack NuGet (ahora SÍ se ejecuta en release)
     - ✅ Publish to NuGet (publica a NuGet.org)

2. **NuGet.org** (5-15 minutos después):
   - Busca: https://www.nuget.org/packages/AlohaPDF/
   - Deberías ver: `0.2.0-alpha` con badge de "pre-release"
   - La versión 0.1.0-alpha quedará obsoleta

3. **Prueba de instalación:**
```bash
dotnet new console -n TestAlohaPDF
cd TestAlohaPDF
dotnet add package AlohaPDF --version 0.2.0-alpha
dotnet run
```

## 📊 Flujo Completo

```
1. git commit + push
   ↓
2. GitHub Actions:
   ✅ build-and-test (compila, 137 tests)
   ✅ pack (crea AlohaPDF.0.2.0-alpha.nupkg)
   📦 Artifact disponible

3. git tag v0.2.0-alpha + push
   ↓
4. Crear Release en GitHub
   ✅ Marcado como "pre-release"
   ↓
5. GitHub Actions (automático):
   ✅ pack (se ejecuta de nuevo por el release)
   ✅ publish (publica a NuGet.org)
   
6. ✨ Paquete disponible en NuGet.org
```

## 🎯 Checklist

- [ ] Commit realizado con versión 0.2.0-alpha
- [ ] Push a master exitoso
- [ ] Pipeline `build-and-test` pasó ✅
- [ ] Pipeline `pack` creó el .nupkg ✅
- [ ] Tag `v0.2.0-alpha` creado y pusheado
- [ ] Release creado en GitHub
- [ ] **✅ Marcado como "pre-release"**
- [ ] Job `pack` se ejecutó en release ✅
- [ ] Job `publish` ejecutado exitosamente ✅
- [ ] Paquete visible en NuGet.org
- [ ] Instalación de prueba exitosa

## 🔍 Verificar el Fix del Pipeline

En esta versión, el pipeline está corregido:

**Antes (0.1.0-alpha):**
```yaml
if: github.event_name == 'push' && ...
# ❌ Pack solo en push, NO en release
```

**Ahora (0.2.0-alpha):**
```yaml
if: (github.event_name == 'push' && ...) || github.event_name == 'release'
# ✅ Pack en push Y en release
```

Esto permite que el job `publish` tenga el artefacto necesario.

## 🔥 Si Algo Falla

### Pipeline no ejecuta `pack` o `publish`:
1. Verifica que el release esté marcado como "published" (no draft)
2. Revisa los logs en GitHub Actions
3. Confirma que el workflow tiene la condición correcta

### Paquete no aparece en NuGet:
1. Espera 10-15 minutos (indexación)
2. Verifica `NUGET_API_KEY` en GitHub Secrets
3. Revisa logs del job `publish`

### Error "Package already exists":
- Usa `--skip-duplicate` (ya incluido en el workflow)
- O incrementa la versión a 0.3.0-alpha

## 📚 Referencias

- [Pipeline Setup](PIPELINE-SETUP.md)
- [Release Guide](.github/RELEASE-GUIDE.md)
- [SkiaSharp Fix](FIX-SKIASHARP-CI.md)
- [Contributing](CONTRIBUTING.md)

## 🆚 Diferencias vs 0.1.0-alpha

| Aspecto | 0.1.0-alpha | 0.2.0-alpha |
|---------|-------------|-------------|
| Pipeline | ❌ Pack no ejecutaba en release | ✅ Pack ejecuta en release |
| SkiaSharp | ⚠️ Config básica | ✅ Fully configured |
| Tests | ✅ 137 tests | ✅ 137 tests |
| Docs | ⚠️ Básica | ✅ Completa |
| Publicación | ❌ Falló | ✅ Debería funcionar |

---

**¡Aloha! 🌺 Esta versión debería publicarse correctamente en NuGet.org**

## 💡 Tip

Para futuras versiones, simplemente:
1. Actualiza `<Version>` en `.csproj`
2. Actualiza `<PackageReleaseNotes>`
3. Commit, tag, y crea release
4. ¡El pipeline hace el resto! 🚀
