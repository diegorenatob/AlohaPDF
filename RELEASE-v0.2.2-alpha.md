# 🚀 Release v0.2.2-alpha - Instrucciones

## ✅ Cambios Completados

- ✅ Versión actualizada a `0.2.2-alpha` en `AlohaPDF.csproj`
- ✅ Release notes actualizadas en el paquete NuGet

## 🎯 ¿Por Qué 0.2.2-alpha?

El tag `v0.2.1-alpha` apuntaba al commit **antiguo** (`16bf562`) en lugar del commit con la versión corregida (`c896d20`).  
El pipeline tomaba el código del tag (el viejo), ignorando el commit más reciente.  
Esta versión crea un tag fresco sobre el commit correcto.

## ⚠️ Problema que corrige

```
Tag v0.2.1-alpha → commit 16bf562 (Update AlohaPDF.csproj)   ← el que usaba CI
                   commit c896d20 (chore: bump version 0.2.1) ← el que tenía la fix
```

## 📝 Pasos para Publicar

### 1️⃣ Commit y Push

```bash
git add .
git commit -m "chore: bump version to 0.2.2-alpha"
git push origin master
```

### 2️⃣ Verificar Build en GitHub Actions

1. Ve a: https://github.com/diegorenatob/AlohaPDF/actions
2. Espera que completen:
   - ✅ `build-and-test` — 137 tests deben pasar
   - ✅ `pack` — debe crear `AlohaPDF.0.2.2-alpha.nupkg`

### 3️⃣ Crear Tag sobre el commit correcto

```bash
git tag v0.2.2-alpha
git push origin v0.2.2-alpha
```

> ⚠️ Hacer el tag **después** del push para que apunte al commit nuevo.

### 4️⃣ Crear Release en GitHub

1. Ve a: https://github.com/diegorenatob/AlohaPDF/releases/new
2. Configura:
   - **Choose a tag:** `v0.2.2-alpha`
   - **Release title:** `v0.2.2-alpha - Patch Release`
3. Marca **"Set as pre-release"** ✅
4. Haz clic en **"Publish release"**

### 5️⃣ Verificar Publicación en NuGet

Después de ~2 minutos:
- https://www.nuget.org/packages/AlohaPDF/
- El workflow `publish` debe aparecer exitoso en GitHub Actions
