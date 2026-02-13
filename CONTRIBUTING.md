# 🤝 Contribuyendo a AlohaPDF

¡Gracias por tu interés en contribuir a AlohaPDF! 🌺

## 🚀 Inicio Rápido

### Requisitos

- .NET 9.0 SDK o superior
- Visual Studio 2022, VS Code, o JetBrains Rider
- Git

### Configuración del Entorno

1. **Fork y clona el repositorio**
   ```bash
   git clone https://github.com/TU-USUARIO/AlohaPDF.git
   cd AlohaPDF
   ```

2. **Restaura las dependencias**
   ```bash
   dotnet restore
   ```

3. **Compila el proyecto**
   ```bash
   dotnet build
   ```

4. **Ejecuta los tests**
   ```bash
   dotnet test
   ```

## 🔄 Flujo de Trabajo

### 1. Crea una rama para tu feature/fix

```bash
git checkout -b feature/mi-nueva-funcionalidad
# o
git checkout -b fix/correccion-de-bug
```

### 2. Realiza tus cambios

- Escribe código limpio y bien documentado
- Sigue las convenciones de código existentes
- Agrega tests para nuevas funcionalidades
- Asegúrate de que todos los tests pasen

### 3. Ejecuta el build local

**Windows:**
```cmd
build-local.cmd
```

**Linux/macOS:**
```bash
chmod +x build-local.sh
./build-local.sh
```

Esto ejecutará:
- ✅ Compilación
- ✅ Todos los tests
- ✅ Análisis de cobertura de código
- ✅ Empaquetado de NuGet

### 4. Commit y Push

```bash
git add .
git commit -m "feat: descripción clara del cambio"
git push origin feature/mi-nueva-funcionalidad
```

### 5. Crea un Pull Request

- Ve a GitHub y crea un PR desde tu fork
- Describe claramente qué cambiaste y por qué
- Referencia cualquier issue relacionado

## 📝 Convenciones

### Mensajes de Commit

Usamos [Conventional Commits](https://www.conventionalcommits.org/):

- `feat:` - Nueva funcionalidad
- `fix:` - Corrección de bug
- `docs:` - Cambios en documentación
- `test:` - Agregar o modificar tests
- `refactor:` - Refactorización de código
- `style:` - Cambios de formato (espacios, punto y coma, etc.)
- `perf:` - Mejoras de rendimiento
- `chore:` - Tareas de mantenimiento

**Ejemplos:**
```
feat: agregar soporte para tablas con celdas combinadas
fix: corregir alineación de texto en headers
docs: actualizar README con ejemplos de uso
test: agregar tests para validación de páginas
```

### Estilo de Código

- **Indentación:** 4 espacios
- **Llaves:** Estilo Allman (nueva línea)
- **Nombres:**
  - PascalCase para clases, métodos, propiedades públicas
  - camelCase para variables locales y parámetros
  - _camelCase para campos privados
- **Documentación:** Todos los métodos públicos deben tener XML docs

### Tests

- Todos los tests deben pasar antes de hacer PR
- Nuevas funcionalidades deben incluir tests
- Usa nombres descriptivos: `Method_Scenario_ExpectedBehavior`
- Sigue el patrón AAA (Arrange, Act, Assert)

**Ejemplo:**
```csharp
[Test]
public void AddSection_WithValidText_ShouldIncrementCounter()
{
    // Arrange
    var pdf = new AlohaPdfDocument();
    pdf.Initialize(new PdfDocumentOptions { Title = "Test" });
    
    // Act
    pdf.AddSection("Test Section");
    
    // Assert
    pdf.SectionCounter.Should().Be(1);
}
```

## 🔍 CI/CD Pipeline

### Checks Automáticos

Cuando creas un PR, GitHub Actions ejecutará automáticamente:

1. **Build** - Compilación en Release mode
2. **Tests** - Todos los tests unitarios
3. **Code Coverage** - Análisis de cobertura

Tu PR debe pasar todos estos checks para ser considerado para merge.

### Ver el Estado del Pipeline

- Ve a la pestaña "Actions" en GitHub
- Busca el workflow de tu PR
- Revisa los logs si algo falla

### Problemas Comunes

**Tests fallan localmente pero pasan en CI (o viceversa):**
- Asegúrate de tener la misma versión de .NET
- Limpia y recompila: `dotnet clean && dotnet build`

**Build falla:**
- Verifica errores de compilación: `dotnet build`
- Asegúrate de no tener cambios en archivos generados

**Coverage bajo:**
- Agrega tests para código nuevo
- El objetivo es mantener >80% de cobertura

## 🎨 Áreas para Contribuir

### 🆕 Nuevas Funcionalidades

- Soporte para más tipos de elementos (gráficos, códigos QR, etc.)
- Mejoras en la API de estilizado
- Plantillas predefinidas
- Exportar a otros formatos

### 🐛 Corrección de Bugs

- Revisa los [issues abiertos](https://github.com/diegorenatob/AlohaPDF/issues)
- Reproduce el bug
- Crea un test que falle
- Implementa el fix
- Verifica que el test pase

### 📚 Documentación

- Mejorar el README
- Agregar más ejemplos
- Traducir documentación
- Crear tutoriales o guías

### 🧪 Tests

- Aumentar cobertura de código
- Agregar tests de integración
- Crear tests de rendimiento
- Validar casos edge

## 📊 Proceso de Review

### Lo que revisamos:

1. ✅ **Funcionalidad:** ¿Hace lo que promete?
2. ✅ **Tests:** ¿Incluye tests adecuados?
3. ✅ **Código:** ¿Es limpio y mantenible?
4. ✅ **Documentación:** ¿Está bien documentado?
5. ✅ **Performance:** ¿No degrada el rendimiento?
6. ✅ **Breaking Changes:** ¿Rompe compatibilidad?

### Tiempos de Respuesta

- Primera revisión: 1-3 días
- Revisiones subsecuentes: 1-2 días
- Merge después de aprobación: 1 día

## 🎁 Reconocimiento

Todos los contribuidores serán:
- Listados en el archivo CONTRIBUTORS.md
- Mencionados en las release notes
- Parte de la comunidad AlohaPDF 🌺

## 💬 ¿Preguntas?

- Abre un [Discussion](https://github.com/diegorenatob/AlohaPDF/discussions)
- Revisa los [Issues](https://github.com/diegorenatob/AlohaPDF/issues)
- Lee la [documentación](.github/SETUP.md)

## 📜 Código de Conducta

Sé respetuoso, inclusivo y constructivo. Estamos aquí para aprender y construir algo genial juntos. 🤙

---

¡Gracias por contribuir a AlohaPDF! 🌺🎉
