# 📚 Guía de Componentes AlohaPDF

Referencia rápida de todos los componentes con ejemplos.

---

## 📊 Table (Tabla)

**Uso**: Mostrar datos en filas y columnas.

```csharp
// Básico
pdf.AddTable(
    headers: new[] { "Nombre", "Edad", "Ciudad" },
    rows: new[]
    {
        new[] { "Juan", "30", "Madrid" },
        new[] { "María", "25", "Barcelona" }
    }
);

// Con estilo
pdf.AddTable(
    headers: new[] { "Producto", "Precio", "Stock" },
    rows: datos,
    alternateRows: true,                    // Filas alternadas
    headerStyle: TableHeaderStyle.Primary,  // Cabecera coral
    leftMargin: 24f                         // Margen izquierdo
);
```

**Estilos de cabecera**:
- `Primary` - Coral (cálido)
- `Secondary` - Azul océano (profesional)
- `Dark` - Gris oscuro (elegante)
- `Light` - Gris claro (limpio)
- `Minimal` - Solo borde inferior (moderno)

---

## 📝 Paragraph (Párrafo)

**Uso**: Texto con ajuste automático de línea.

```csharp
// Básico
pdf.AddParagraph("Esto es un párrafo simple.");

// Con formato
pdf.AddParagraph(
    text: "Texto importante aquí.",
    lineHeight: 2f,      // Más espacio entre líneas
    isBold: true,        // Negrita
    leftMargin: 24f      // Sangría (para citas)
);
```

**Casos de uso**:
- Texto normal: `AddParagraph("texto...")`
- Cita indentada: `leftMargin: 24f`
- Énfasis: `isBold: true`

---

## 📋 List (Lista)

**Uso**: Listas con viñetas o numeradas.

```csharp
// Lista con viñetas
pdf.AddList(new[]
{
    "Primer punto",
    "Segundo punto",
    "Tercer punto"
});

// Lista numerada
pdf.AddList(
    items: new[] { "Paso 1", "Paso 2", "Paso 3" },
    isNumbered: true
);

// Con prefijo personalizado
pdf.AddList(
    items: puntos,
    customPrefix: "✓ "
);
```

**Opciones**:
- `isNumbered: true` - 1. 2. 3. en lugar de •
- `useMonospace: true` - Fuente monoespaciada
- `withMargin: true` - Margen izquierdo
- `alternateRows: true` - Fondos alternados
- `customPrefix: "→ "` - Prefijo personalizado

---

## 🏷️ Section (Sección)

**Uso**: Títulos de sección.

```csharp
// Título simple
pdf.AddSection("1. Introducción");

// Estilo "pill" (badge)
pdf.AddSection("🌺 Bienvenida", pill: true);
```

**Estilos**:
- Sin `pill`: Texto simple
- Con `pill: true`: Fondo coral, bordes redondeados

---

## ➖ Line (Línea)

**Uso**: Separadores horizontales.

```csharp
// Línea completa
pdf.AddLine();

// Con márgenes
pdf.AddLine(leftMargin: 24f, rightMargin: 24f);

// Grosor personalizado
pdf.AddLine(strokeWidth: 2f);
```

---

## 🎨 Space (Espacio)

**Uso**: Espaciado vertical.

```csharp
using AlohaPDF.Styling;

pdf.AddSpace(PdfLayout.SpaceXs);    // 4 puntos
pdf.AddSpace(PdfLayout.SpaceSm);    // 8 puntos
pdf.AddSpace(PdfLayout.SpaceMd);    // 16 puntos
pdf.AddSpace(PdfLayout.SpaceLg);    // 24 puntos
pdf.AddSpace(PdfLayout.SpaceXl);    // 32 puntos
pdf.AddSpace(PdfLayout.Space2xl);   // 48 puntos

// Personalizado
pdf.AddSpace(100f);                  // 100 puntos
```

---

## 💡 Mejores Prácticas

### Estructura Recomendada

```csharp
pdf
    .AddSection("Título Principal", pill: true)
    .AddParagraph("Introducción...")
    .AddSpace(PdfLayout.SpaceLg)
    
    .AddSection("Datos")
    .AddTable(headers, rows, headerStyle: TableHeaderStyle.Primary)
    .AddSpace(PdfLayout.SpaceMd)
    
    .AddSection("Puntos Clave")
    .AddList(items, isNumbered: true)
    .AddSpace(PdfLayout.SpaceMd)
    
    .AddLine()
    .AddParagraph("Conclusión...");
```

### Guía de Espaciado

| Después de... | Usar | Motivo |
|---------------|------|--------|
| Sección | `SpaceLg` | Separación clara |
| Tabla | `SpaceMd` | Flujo legible |
| Párrafo | `SpaceSm` | Texto compacto |
| Lista | `SpaceMd` | Separar grupos |
| Línea | `SpaceSm` | Ruptura sutil |

### Márgenes de Página

```csharp
// Margen por defecto (recomendado)
PageMargin = PdfLayout.MarginDefault  // 48pt (~17mm)

// Margen compacto (más contenido)
PageMargin = PdfLayout.MarginCompact  // 32pt (~11mm)

// Margen relajado (más espacio)
PageMargin = PdfLayout.MarginRelaxed  // 64pt (~23mm)
```

---

## 🎯 Ejemplo Completo

```csharp
using AlohaPDF;
using AlohaPDF.Core;
using AlohaPDF.Styling;

var pdf = new AlohaPdfDocument();

pdf.Initialize(new PdfDocumentOptions
{
    Title = "Reporte Mensual",
    Subtitle = "Enero 2026",
    PageSize = PageSize.A4,
    Orientation = PageOrientation.Portrait,
    Info = new DocumentInfo
    {
        Author = "Juan Pérez",
        CreatedDate = DateTime.Now
    }
});

pdf
    .AddSection("📋 Resumen Ejecutivo", pill: true)
    .AddParagraph(
        "Este reporte presenta un resumen de nuestro desempeño...",
        lineHeight: 2f
    )
    .AddSpace(PdfLayout.SpaceLg)
    
    .AddSection("📊 Métricas Clave")
    .AddTable(
        headers: new[] { "Métrica", "Objetivo", "Real", "Estado" },
        rows: new[]
        {
            new[] { "Ingresos", "€100K", "€125K", "✓ En curso" },
            new[] { "Clientes", "500", "632", "✓ Superado" }
        },
        headerStyle: TableHeaderStyle.Primary,
        alternateRows: true
    )
    .AddSpace(PdfLayout.SpaceMd)
    
    .AddSection("✅ Acciones")
    .AddList(
        items: new[]
        {
            "Completar revisión Q1",
            "Planificar iniciativas Q2",
            "Actualizar pronósticos"
        },
        isNumbered: true
    )
    .AddSpace(PdfLayout.SpaceMd)
    
    .AddLine()
    .AddSpace(PdfLayout.SpaceSm)
    
    .AddParagraph(
        "Para preguntas, contactar: juan.perez@empresa.com",
        leftMargin: 24f
    );

pdf.Generate("reporte-mensual.pdf");
```

---

## 📊 Resumen de Componentes

| Componente | Propósito | Opciones Principales |
|------------|-----------|---------------------|
| **Table** | Datos tabulares | `headerStyle`, `alternateRows`, `leftMargin` |
| **Paragraph** | Bloques de texto | `isBold`, `lineHeight`, `leftMargin` |
| **List** | Viñetas/numeradas | `isNumbered`, `useMonospace`, `customPrefix` |
| **Section** | Títulos | `pill`, `fontSize` |
| **Line** | Separadores | `leftMargin`, `rightMargin`, `strokeWidth` |
| **Space** | Espacios verticales | Constantes `PdfLayout.Space*` |

---

## 🔧 Configuración Avanzada

### Uso Directo de Elementos

```csharp
using AlohaPDF.Elements.Table;
using AlohaPDF.Elements.List;
using AlohaPDF.Elements.Paragraph;

// Tabla con configuración completa
var tableConfig = new TableConfig
{
    Headers = new[] { "Col1", "Col2" },
    Rows = datos,
    AlternateRows = true,
    HeaderStyle = TableHeaderStyle.Primary,
    RepeatHeadersOnPageBreak = true  // Repetir en páginas nuevas
};
pdf.AddElement(new TableElement(tableConfig));

// Lista con configuración completa
var listConfig = new ListConfig
{
    Items = new List<string> { "Item 1", "Item 2" },
    IsNumbered = true,
    WithMargin = true,
    AlternateRows = false,
    CustomPrefix = "→ "
};
pdf.AddElement(new ListElement(listConfig));

// Párrafo con configuración completa
var paraConfig = new ParagraphConfig
{
    Text = "Texto largo...",
    LineHeight = 2f,
    IsBold = false,
    LeftMargin = 24f,
    FontSize = 12f
};
pdf.AddElement(new ParagraphElement(paraConfig));
```

---

## 📖 Ver También

- [README.md](README.md) - Documentación principal
- [COMPONENTS_GUIDE.md](COMPONENTS_GUIDE.md) - Guía en inglés
- [ARCHITECTURE.md](ARCHITECTURE.md) - Arquitectura SOLID
- [PAGESIZE_GUIDE.md](PAGESIZE_GUIDE.md) - Tamaños de página
- [ORIENTATION_GUIDE.md](ORIENTATION_GUIDE.md) - Orientaciones

---

*Hecho con 🌺 Aloha Spirit - ¡Componentes simples, PDFs hermosos!*
