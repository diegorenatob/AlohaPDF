# 🏗️ AlohaPDF - Arquitectura SOLID

## 📐 Estructura del Proyecto

AlohaPDF sigue principios SOLID con separación clara de responsabilidades:

```
AlohaPDF/
├── AlohaPDF.Core.Contracts/          # Interfaces y contratos
│   ├── IPdfElement.cs                 # Interface para elementos renderizables
│   ├── IRenderContext.cs              # Interface para contexto de rendering
│   ├── IFontProvider.cs               # Interface para proveer fuentes
│   └── IColorProvider.cs              # Interface para proveer colores
│
├── AlohaPDF.Elements/                 # Implementaciones de elementos
│   ├── Table/
│   │   ├── TableElement.cs            # Elemento de tabla
│   │   ├── TableConfig.cs             # Configuración de tabla
│   │   └── TableRenderer.cs           # Lógica de rendering de tabla
│   ├── List/
│   │   ├── ListElement.cs             # Elemento de lista
│   │   ├── ListConfig.cs              # Configuración de lista
│   │   └── ListRenderer.cs            # Lógica de rendering de lista
│   ├── Paragraph/
│   │   ├── ParagraphElement.cs        # Elemento de párrafo
│   │   ├── ParagraphConfig.cs         # Configuración de párrafo
│   │   └── ParagraphRenderer.cs       # Lógica de rendering de párrafo
│   ├── Section/
│   │   ├── SectionElement.cs          # Elemento de sección
│   │   ├── SectionConfig.cs           # Configuración de sección
│   │   └── SectionRenderer.cs         # Lógica de rendering de sección
│   └── Line/
│       ├── LineElement.cs             # Elemento de línea
│       └── LineConfig.cs              # Configuración de línea
│
└── AlohaPDF/                          # Proyecto principal (orquestación)
    ├── AlohaPdfDocument.cs            # API pública fluida
    ├── Rendering/
    │   ├── RenderContext.cs           # Implementación de IRenderContext
    │   ├── FontProvider.cs            # Implementación de IFontProvider
    │   └── ColorProvider.cs           # Implementación de IColorProvider
    ├── Core/
    │   ├── PdfDocumentOptions.cs      # Configuración del documento
    │   └── DocumentInfo.cs            # Información del documento
    └── Styling/
        ├── PdfColors.cs               # Paleta de colores Aloha
        ├── PdfTypography.cs           # Sistema tipográfico
        └── PdfLayout.cs               # Sistema de layout
```

---

## 🎯 Principios SOLID Aplicados

### 1. **S**ingle Responsibility Principle (SRP)

Cada clase tiene una única responsabilidad:

**✅ Ejemplo - TableElement**:
```csharp
// TableElement: Solo representa un elemento de tabla
public class TableElement : IPdfElement
{
    private readonly TableConfig _config;
    
    public void Render(IRenderContext context)
    {
        var renderer = new TableRenderer();  // Delega rendering
        renderer.Render(context, _config);
    }
}

// TableConfig: Solo holds configuration data
public class TableConfig
{
    public string[] Headers { get; init; }
    public List<string[]> Rows { get; init; }
    // ... más config
}

// TableRenderer: Solo maneja la lógica de rendering
public class TableRenderer
{
    public void Render(IRenderContext context, TableConfig config)
    {
        // Drawing logic here
    }
}
```

**Ventajas**:
- Fácil de testear cada componente
- Fácil de modificar sin afectar otros
- Claro qué hace cada clase

---

### 2. **O**pen/Closed Principle (OCP)

Abierto para extensión, cerrado para modificación:

**✅ Ejemplo - Nuevos Elementos**:
```csharp
// Agregar un nuevo elemento SIN modificar código existente
public class ImageElement : IPdfElement
{
    public void Render(IRenderContext context)
    {
        // Nueva implementación
    }
}

// Usar el nuevo elemento:
pdf.AddElement(new ImageElement(config));
```

**Ventajas**:
- Extensible sin romper código existente
- Nuevas features no requieren cambios en core
- Plugins/extensions posibles

---

### 3. **L**iskov Substitution Principle (LSP)

Cualquier `IPdfElement` puede sustituirse sin romper el código:

**✅ Ejemplo**:
```csharp
// Todos estos son IPdfElement y funcionan igual
IPdfElement element1 = new TableElement(tableConfig);
IPdfElement element2 = new ListElement(listConfig);
IPdfElement element3 = new ParagraphElement(paraConfig);

// Todos se renderizan igual
foreach (var element in elements)
{
    element.Render(context);  // Polimorfismo
}
```

**Ventajas**:
- Código genérico y reutilizable
- Fácil agregar nuevos tipos
- Type-safe

---

### 4. **I**nterface Segregation Principle (ISP)

Interfaces pequeñas y específicas:

**✅ Ejemplo**:
```csharp
// En lugar de una interfaz grande:
// interface IHugeContext { ... 50 métodos ... }

// Usamos interfaces segregadas:
interface IRenderContext
{
    SKCanvas Canvas { get; }
    float CurrentY { get; set; }
    void EnsureSpace(float height);
}

interface IFontProvider
{
    SKTypeface? Regular { get; }
    SKTypeface? Bold { get; }
}

interface IColorProvider
{
    SKColor Primary { get; }
    SKColor TextPrimary { get; }
}
```

**Ventajas**:
- Clientes solo dependen de lo que necesitan
- Fácil de mockear en tests
- Interfaces cohesivas

---

### 5. **D**ependency Inversion Principle (DIP)

Depender de abstracciones, no de implementaciones:

**✅ Ejemplo**:
```csharp
// TableRenderer depende de IRenderContext (abstracción)
public class TableRenderer
{
    public void Render(IRenderContext context, TableConfig config)
    {
        // Usa context.Fonts, context.Colors
        // No sabe de implementación concreta
    }
}

// Podemos inyectar diferentes implementaciones:
IRenderContext context1 = new RenderContext(...);
IRenderContext context2 = new MockRenderContext(...); // Para tests
```

**Ventajas**:
- Testeable (usar mocks)
- Flexible (cambiar implementaciones)
- Desacoplado

---

## 📦 Cómo Agregar Nuevos Elementos

### Paso 1: Crear Config

```csharp
public class MyElementConfig
{
    public string SomeProperty { get; init; }
    // ... más propiedades
}
```

### Paso 2: Crear Element

```csharp
public class MyElement : IPdfElement
{
    private readonly MyElementConfig _config;

    public MyElement(MyElementConfig config)
    {
        _config = config;
    }

    public float GetRequiredHeight(IRenderContext context)
    {
        // Calcular altura
        return 50f;
    }

    public void Render(IRenderContext context)
    {
        var renderer = new MyElementRenderer();
        renderer.Render(context, _config);
    }
}
```

### Paso 3: Crear Renderer

```csharp
public class MyElementRenderer
{
    public void Render(IRenderContext context, MyElementConfig config)
    {
        // Lógica de dibujo
        context.Canvas.DrawText(...);
    }
}
```

### Paso 4: Usar en AlohaPdfDocument

```csharp
public IAlohaPdfDocument AddMyElement(string someProperty)
{
    var config = new MyElementConfig { SomeProperty = someProperty };
    var element = new MyElement(config);
    _elements.Add(element);
    return this;
}
```

---

## 🧪 Ventajas de Esta Arquitectura

### 1. **Testeable**
```csharp
[Fact]
public void TableRenderer_Should_DrawHeader()
{
    // Arrange
    var mockContext = new Mock<IRenderContext>();
    var config = new TableConfig { Headers = new[] { "Col1" }, ... };
    var renderer = new TableRenderer();

    // Act
    renderer.Render(mockContext.Object, config);

    // Assert
    mockContext.Verify(c => c.Canvas.DrawText(...));
}
```

### 2. **Extensible**
- Agregar nuevos elementos sin tocar código existente
- Plugins/extensions posibles
- Custom renderers

### 3. **Mantenible**
- Cada clase es pequeña y enfocada
- Fácil encontrar y arreglar bugs
- Cambios aislados

### 4. **Documentado**
- Código autodocumentado con XML comments
- Estructura clara y obvia
- Ejemplos en README

---

## 🔄 Comparación con Código Monolítico

### Antes (Monolítico):
```csharp
// AlohaPdfDocument.cs (2000+ líneas)
public class AlohaPdfDocument
{
    private record TableElement(...) { ... }  // Inline
    private record ListElement(...) { ... }   // Inline
    private record ParagraphElement(...) { ... }  // Inline
    // ... todo mezclado
}
```

**Problemas**:
- ❌ Difícil de testear partes individuales
- ❌ Un cambio puede romper todo
- ❌ Difícil agregar nuevos elementos
- ❌ Violación de SRP

### Ahora (SOLID):
```
AlohaPDF.Core.Contracts/    (Interfaces puras)
AlohaPDF.Elements/          (Implementaciones separadas)
  Table/                    (Todo sobre tablas)
  List/                     (Todo sobre listas)
  Paragraph/                (Todo sobre párrafos)
AlohaPDF/                   (Orquestación)
```

**Ventajas**:
- ✅ Cada componente es testeable individualmente
- ✅ Cambios aislados
- ✅ Fácil agregar nuevos elementos
- ✅ Cumple todos los principios SOLID

---

## 📚 Referencias

- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Dependency Inversion](https://martinfowler.com/articles/dipInTheWild.html)

---

*Arquitectura diseñada con 🌺 Aloha Spirit y SOLID principles*
