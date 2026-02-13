# 🚀 Guía de Release - AlohaPDF

Esta guía describe el proceso completo para publicar una nueva versión de AlohaPDF en NuGet.org.

## 📋 Pre-requisitos

- [ ] Configurar `NUGET_API_KEY` en GitHub Secrets (ver `.github/SETUP.md`)
- [ ] Todos los tests pasando localmente
- [ ] Branch `master` actualizado
- [ ] Changelog preparado con los cambios

## 🔢 Versionado Semántico

AlohaPDF usa [Semantic Versioning](https://semver.org/): `MAJOR.MINOR.PATCH`

- **MAJOR**: Cambios incompatibles con versiones anteriores
- **MINOR**: Nueva funcionalidad compatible con versiones anteriores
- **PATCH**: Correcciones de bugs compatibles

### Ejemplos

```
1.0.0 → 1.0.1  (Bug fix)
1.0.1 → 1.1.0  (Nueva feature)
1.1.0 → 2.0.0  (Breaking change)
```

### Pre-releases

Para versiones beta o RC:

```
1.0.0-beta.1
1.0.0-rc.1
2.0.0-alpha.1
```

## 📝 Proceso de Release Paso a Paso

### 1. Preparar el Release

#### 1.1 Actualizar la versión

Edita `src/AlohaPDF/AlohaPDF.csproj`:

```xml
<PropertyGroup>
    <Version>1.0.1</Version>
    <PackageReleaseNotes>
        🎉 Release 1.0.1
        
        ✨ Nuevas Características:
        - Soporte para tablas con celdas combinadas
        - Nuevos estilos de encabezados
        
        🐛 Correcciones:
        - Fix: Alineación de texto en headers
        - Fix: Memory leak en generación de páginas
        
        🚀 Mejoras:
        - Mejor rendimiento en documentos grandes
        - API más intuitiva para estilos
    </PackageReleaseNotes>
</PropertyGroup>
```

#### 1.2 Actualizar CHANGELOG.md

Si no existe, créalo:

```markdown
# Changelog

## [1.0.1] - 2025-01-XX

### Added
- Soporte para tablas con celdas combinadas
- Nuevos estilos de encabezados

### Fixed
- Alineación de texto en headers
- Memory leak en generación de páginas

### Changed
- Mejor rendimiento en documentos grandes
- API más intuitiva para estilos

## [1.0.0] - 2025-01-XX

### Added
- Release inicial de AlohaPDF
```

### 2. Verificar Todo Localmente

```bash
# 1. Limpia build anterior
dotnet clean

# 2. Restaura dependencias
dotnet restore

# 3. Compila en Release
dotnet build --configuration Release

# 4. Ejecuta todos los tests
dotnet test --configuration Release

# 5. Empaqueta (verifica que se crea correctamente)
dotnet pack src/AlohaPDF/AlohaPDF.csproj --configuration Release --output ./artifacts
```

Si todo pasa correctamente, continúa.

### 3. Commit y Push

```bash
# 1. Agrega los cambios
git add src/AlohaPDF/AlohaPDF.csproj CHANGELOG.md
git commit -m "chore: bump version to 1.0.1"

# 2. Push a master
git push origin master

# 3. Espera que el pipeline de CI pase
# Ve a GitHub Actions y verifica que Build and Test pase ✅
```

### 4. Crear Tag

```bash
# 1. Crea el tag
git tag v1.0.1

# 2. Push el tag
git push origin v1.0.1
```

### 5. Crear Release en GitHub

#### Opción A: Desde la Web UI

1. Ve a tu repositorio en GitHub
2. Click en "Releases" → "Draft a new release"
3. Configuración:
   - **Choose a tag**: `v1.0.1` (selecciona el tag que creaste)
   - **Release title**: `v1.0.1 - Descripción Corta`
   - **Description**: Copia el contenido del CHANGELOG para esta versión
   
   ```markdown
   ## 🎉 AlohaPDF v1.0.1
   
   ### ✨ Nuevas Características
   - Soporte para tablas con celdas combinadas
   - Nuevos estilos de encabezados
   
   ### 🐛 Correcciones
   - Fix: Alineación de texto en headers (#123)
   - Fix: Memory leak en generación de páginas (#124)
   
   ### 🚀 Mejoras
   - Mejor rendimiento en documentos grandes
   - API más intuitiva para estilos
   
   ### 📦 Instalación
   
   ```bash
   dotnet add package AlohaPDF --version 1.0.1
   ```
   
   ### 🔗 Links
   - [Documentación](https://github.com/diegorenatob/AlohaPDF/blob/master/README.md)
   - [Changelog Completo](https://github.com/diegorenatob/AlohaPDF/blob/master/CHANGELOG.md)
   ```

4. **Set as the latest release**: ✅ (marca si es una release estable)
5. Click en "Publish release"

#### Opción B: Desde la CLI (con GitHub CLI)

```bash
gh release create v1.0.1 \
  --title "v1.0.1 - Descripción Corta" \
  --notes-file RELEASE_NOTES.md
```

### 6. Verificar la Publicación Automática

1. Ve a la pestaña "Actions" en GitHub
2. Deberías ver un nuevo workflow ejecutándose: "CI/CD Pipeline"
3. Espera que complete todos los jobs:
   - ✅ Build and Test
   - ✅ Pack
   - ✅ Publish

4. Verifica en NuGet.org:
   - Ve a https://www.nuget.org/packages/AlohaPDF/
   - Deberías ver la nueva versión 1.0.1 publicada
   - Puede tardar 10-15 minutos en indexarse completamente

### 7. Anunciar el Release

Después de que el paquete esté disponible en NuGet:

- [ ] Actualiza el README si es necesario
- [ ] Comparte en redes sociales
- [ ] Notifica en tu Discord/Slack/comunidad
- [ ] Actualiza ejemplos y documentación

## 🔥 Hotfix Release (Urgente)

Para releases urgentes de corrección de bugs:

```bash
# 1. Crea una rama hotfix
git checkout -b hotfix/1.0.2

# 2. Aplica el fix
# ... realiza los cambios ...

# 3. Actualiza la versión a 1.0.2
# ... edita AlohaPDF.csproj ...

# 4. Commit, test, y merge a master
git add .
git commit -m "fix: critical bug in PDF generation"
git push origin hotfix/1.0.2

# 5. Crea PR, merge a master
# 6. Sigue el proceso normal de release desde el paso 4
```

## 🎯 Checklist de Release

Usa este checklist para cada release:

### Pre-Release
- [ ] Todos los tests pasando
- [ ] Cobertura de código >80%
- [ ] Documentación actualizada
- [ ] CHANGELOG.md actualizado
- [ ] Versión actualizada en .csproj
- [ ] Build local exitoso

### Release
- [ ] Commit y push a master
- [ ] CI pipeline pasa en GitHub Actions
- [ ] Tag creado (v1.0.x)
- [ ] Release creado en GitHub
- [ ] Pipeline de publicación completado

### Post-Release
- [ ] Versión visible en NuGet.org
- [ ] README actualizado si es necesario
- [ ] Release anunciado
- [ ] Issues relacionados cerrados

## 📊 Monitoreo Post-Release

Después de publicar, monitorea:

- **GitHub Issues**: Nuevos bugs reportados
- **NuGet Downloads**: Estadísticas de descarga
- **CI/CD**: Cualquier fallo en el pipeline
- **Community Feedback**: Comentarios en GitHub/NuGet

## 🆘 Rollback (Deshacer un Release)

Si necesitas revertir un release problemático:

### En NuGet.org
1. Ve a https://www.nuget.org/packages/AlohaPDF/manage
2. Selecciona la versión problemática
3. Click en "Unlist" (esto la oculta pero no la elimina)

### En GitHub
1. Marca el release como "Pre-release" o elimínalo
2. Crea un nuevo release hotfix con la corrección

### Comunicación
- Anuncia el problema y la solución
- Documenta la causa en el CHANGELOG
- Publica una nueva versión corregida lo antes posible

## 📝 Plantillas

### Plantilla de Release Notes

```markdown
## 🎉 AlohaPDF vX.Y.Z

[Descripción breve de 1-2 líneas sobre este release]

### ✨ Nuevas Características
- Feature 1 (#issue-number)
- Feature 2 (#issue-number)

### 🐛 Correcciones
- Fix 1 (#issue-number)
- Fix 2 (#issue-number)

### 🚀 Mejoras
- Improvement 1 (#issue-number)
- Improvement 2 (#issue-number)

### ⚠️ Breaking Changes (si aplica)
- Change 1 - **Migración**: [explicar cómo migrar]

### 📦 Instalación

``​`bash
dotnet add package AlohaPDF --version X.Y.Z
``​`

### 📚 Documentación
- [README](link)
- [Changelog](link)
- [Examples](link)

### 🙏 Contribuidores
Gracias a todos los que contribuyeron a este release!

@usuario1, @usuario2, @usuario3
```

### Plantilla de CHANGELOG

```markdown
# Changelog

Todos los cambios notables en AlohaPDF serán documentados en este archivo.

El formato está basado en [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
y este proyecto adhiere a [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Nuevas features en desarrollo

## [X.Y.Z] - YYYY-MM-DD

### Added
- Nuevas características

### Changed
- Cambios en funcionalidad existente

### Deprecated
- Funcionalidad que será removida

### Removed
- Funcionalidad removida

### Fixed
- Correcciones de bugs

### Security
- Vulnerabilidades corregidas
```

## 💡 Tips y Buenas Prácticas

1. **Release Frecuente**: Es mejor hacer releases pequeños y frecuentes
2. **Comunicación Clara**: Documenta bien los cambios en el CHANGELOG
3. **Testing**: Siempre prueba antes de publicar
4. **Semántico**: Sigue semantic versioning estrictamente
5. **Rollback Plan**: Ten un plan de rollback para emergencias
6. **Anuncios**: Comunica los releases a tu comunidad

## 🔗 Referencias

- [Semantic Versioning](https://semver.org/)
- [Keep a Changelog](https://keepachangelog.com/)
- [NuGet Best Practices](https://docs.microsoft.com/en-us/nuget/create-packages/package-authoring-best-practices)
- [GitHub Releases](https://docs.github.com/en/repositories/releasing-projects-on-github)

---

**¡Aloha y felices releases! 🌺🚀**
