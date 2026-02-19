# 🚀 Release v0.1.0-alpha - Instrucciones

## ✅ Cambios Completados

- ✅ Versión actualizada a `0.1.0-alpha` en `AlohaPDF.csproj`
- ✅ Release notes actualizadas
- ✅ Descripción corregida (emoji 🌺)
- ✅ Pipeline CI/CD configurado
- ✅ Secret `NUGET_API_KEY` configurado en GitHub

## 📝 Próximos Pasos

### 1️⃣ Commit y Push

```bash
git add .
git commit -m "chore: bump version to 0.1.0-alpha para first release

- Actualizada versión a 0.1.0-alpha
- Release notes para versión alpha
- Pipeline CI/CD completo con soporte SkiaSharp
- Correcciones en tests"

git push origin master
```

### 2️⃣ Verificar el Pipeline

1. Ve a: https://github.com/diegorenatob/AlohaPDF/actions
2. Espera a que el workflow complete:
   - ✅ `build-and-test` - Debe pasar
   - ✅ `pack` - Debe crear `AlohaPDF.0.1.0-alpha.nupkg`

### 3️⃣ Crear Tag

```bash
git tag v0.1.0-alpha
git push origin v0.1.0-alpha
```

### 4️⃣ Crear Release en GitHub

1. Ve a: https://github.com/diegorenatob/AlohaPDF/releases/new

2. Configura:
   - **Choose a tag:** `v0.1.0-alpha`
   - **Release title:** `v0.1.0-alpha - Initial Alpha Release`

3. **Description:** (copia y pega esto)

```markdown
## 🌺 AlohaPDF v0.1.0-alpha - Initial Alpha Release

⚠️ **This is an early alpha version** for testing and community feedback. Use in production at your own risk.

### ✨ Features

- 🎨 Fluent API for intuitive PDF generation
- 📄 Support for sections, paragraphs, tables, and lists
- 🌴 Modern tropical-themed styling out of the box
- 🔄 Cross-platform support (.NET 9)
- ⚡ SkiaSharp-based high-performance rendering

### 📦 Installation

```bash
dotnet add package AlohaPDF --version 0.1.0-alpha
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

---

**Aloha! 🌺** Thank you for being an early adopter.
```

4. **IMPORTANTE:** ✅ Marca **"Set as a pre-release"**
5. Click **"Publish release"**

### 5️⃣ Verificar Publicación

1. **GitHub Actions:**
   - El job `publish` se ejecutará automáticamente
   - Verifica en: https://github.com/diegorenatob/AlohaPDF/actions

2. **NuGet.org** (5-10 minutos después):
   - Busca: https://www.nuget.org/packages/AlohaPDF/
   - Deberías ver: `0.1.0-alpha` con badge de "pre-release"

3. **Prueba de instalación:**
```bash
dotnet new console -n TestAlohaPDF
cd TestAlohaPDF
dotnet add package AlohaPDF --version 0.1.0-alpha
```

## 📊 ¿Qué Pasará?

```
1. git push origin master
   ↓
2. GitHub Actions ejecuta:
   ✅ build-and-test (compila, testea)
   ✅ pack (crea .nupkg)
   📦 Artifact: AlohaPDF.0.1.0-alpha.nupkg

3. git tag + push tag
   ↓
4. Crear Release en GitHub (marcado como pre-release)
   ↓
5. GitHub Actions ejecuta:
   ✅ publish (publica a NuGet.org)
   
6. Paquete disponible en NuGet.org 🎉
```

## 🎯 Checklist

- [ ] Commit realizado
- [ ] Push a master exitoso
- [ ] Pipeline `build-and-test` pasó ✅
- [ ] Pipeline `pack` creó el .nupkg ✅
- [ ] Tag `v0.1.0-alpha` creado y pusheado
- [ ] Release creado en GitHub
- [ ] **✅ Marcado como "pre-release"**
- [ ] Job `publish` ejecutado exitosamente
- [ ] Paquete visible en NuGet.org
- [ ] Instalación de prueba exitosa

## 🔍 Si Algo Falla

### Pipeline falla en tests:
```bash
dotnet test --verbosity detailed
```

### No se crea el .nupkg:
```bash
dotnet pack src/AlohaPDF/AlohaPDF.csproj --configuration Release -o ./artifacts
```

### No se publica en NuGet:
- Verifica que `NUGET_API_KEY` esté configurado en GitHub Secrets
- Verifica los logs en GitHub Actions → job `publish`

## 📚 Referencias

- [Pipeline Setup](PIPELINE-SETUP.md)
- [Release Guide](.github/RELEASE-GUIDE.md)
- [SkiaSharp Dependencies](.github/SKIASHARP-DEPENDENCIES.md)

---

**¡Aloha! 🌺 Estás listo para publicar tu primera versión alpha.**
