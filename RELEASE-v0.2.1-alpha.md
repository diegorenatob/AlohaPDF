# 🚀 Release v0.2.1-alpha - Instrucciones

## ✅ Cambios Completados

- ✅ Versión actualizada a `0.2.1-alpha` en `AlohaPDF.csproj`
- ✅ Tag `v0.2.1-alpha` creado en Git
- ✅ Release notes actualizadas en el paquete NuGet

## 🎯 ¿Por Qué 0.2.1-alpha?

Patch sobre `0.2.0-alpha` que corrige la discrepancia entre el tag de Git y la versión declarada en el `.csproj`.

## 📝 Pasos para Publicar

### 1️⃣ Verificar que el tag ya existe

```bash
git tag -l
# Debe mostrar: v0.2.1-alpha
```

### 2️⃣ Push del commit y del tag (si aún no se hizo)

```bash
git add .
git commit -m "chore: bump version to 0.2.1-alpha"
git push origin master
git push origin v0.2.1-alpha
```

### 3️⃣ Verificar Build

1. Ve a: https://github.com/diegorenatob/AlohaPDF/actions
2. Espera que el workflow complete:
   - ✅ `build-and-test` - Tests deben pasar
   - ✅ `pack` - Debe crear `AlohaPDF.0.2.1-alpha.nupkg`

### 4️⃣ Crear Release en GitHub

1. Ve a: https://github.com/diegorenatob/AlohaPDF/releases/new

2. Configura:
   - **Choose a tag:** `v0.2.1-alpha`
   - **Release title:** `v0.2.1-alpha - Patch Release`

3. **Description:** (copia y pega)

```markdown
## 🌺 AlohaPDF v0.2.1-alpha - Patch Release

⚠️ **This is an alpha version** for testing and community feedback.

### ✨ What's New in 0.2.1-alpha

- 🔧 Fixed version mismatch between Git tag and NuGet package version
- ✅ 137 tests passing
- 🐧 SkiaSharp native dependencies properly configured for Linux CI/CD

### 📦 Features

- 🎨 Fluent API for intuitive PDF generation
- 📄 Support for sections, paragraphs, tables, and lists
- 🌴 Modern tropical-themed styling out of the box
- 🔄 Cross-platform support (.NET 9)
- ⚡ SkiaSharp-based high-performance rendering

### 🐛 Known Issues

- Some advanced features may have rough edges
- Documentation is still being expanded
- Breaking changes may occur in future versions

📝 **Feedback:** https://github.com/diegorenatob/AlohaPDF/issues
```

4. Marca **"Set as pre-release"** ✅
5. Haz clic en **"Publish release"**

### 5️⃣ Verificar Publicación

Después de ~2 minutos, verifica en:
- https://www.nuget.org/packages/AlohaPDF/
- El workflow `publish` debe aparecer exitoso en GitHub Actions
