# Estrategia de Pruebas: Catálogo de Productos

## Información General de la Estrategia de Pruebas

### Alcance de las Pruebas
**Características y componentes a probar:**
- [ ] ProductsController.cs - Controlador principal de productos
- [ ] Product.cs - Modelo de datos y validaciones
- [ ] Views/Products/ - Interfaces de usuario (Index, Details)
- [ ] Integración con ApplicationDbContext para acceso a datos
- [ ] Funcionalidad de búsqueda y filtrado
- [ ] Paginación de resultados
- [ ] Responsive design y compatibilidad móvil

### Objetivos de Calidad
**Objetivos de calidad medibles y criterios de éxito:**
- **Funcionalidad**: 100% de casos de uso principales validados
- **Rendimiento**: Tiempo de carga < 2 segundos para lista, < 1.5s para detalles
- **Usabilidad**: Cumplimiento WCAG 2.1 AA, responsive en dispositivos móviles/desktop
- **Seguridad**: Cero vulnerabilidades críticas, validación de entrada implementada

### Evaluación de Riesgos
**Riesgos identificados y estrategias de mitigación:**

| Riesgo | Probabilidad | Impacto | Estrategia de Mitigación |
|--------|--------------|---------|--------------------------|
| Rendimiento degradado con catálogos grandes | Alto | Alto | Pruebas de carga con 10,000+ productos, optimización de queries |
| Vulnerabilidades de inyección SQL | Medio | Crítico | Pruebas de seguridad automatizadas, revisión de código para Entity Framework |
| Problemas de accesibilidad | Medio | Alto | Pruebas automatizadas con herramientas WCAG, revisión manual |
| Incompatibilidad entre navegadores | Bajo | Medio | Testing automatizado en Chrome, Firefox, Safari, Edge |

### Enfoque de Pruebas
**Metodología general de pruebas y aplicación del framework:**
- Framework ISTQB aplicado: Combinación de técnicas de caja negra (partición equivalencia, valores límite) y experiencia
- Modelo de calidad ISO 25010: Priorización en Funcionalidad (Crítica), Rendimiento (Alto), Usabilidad (Alto), Seguridad (Alto)

## Implementación del Framework ISTQB

### Selección de Técnicas de Diseño de Pruebas

**Análisis completo de qué técnicas de diseño de pruebas ISTQB aplicar:**

#### Técnicas de Caja Negra
- [x] **Partición de Equivalencia**: Categorización de inputs de búsqueda (texto válido, vacío, caracteres especiales)
- [x] **Análisis de Valores Límite**: Pruebas en límites de paginación (página 1, última página, página 0, página negativa)
- [x] **Pruebas de Tabla de Decisión**: Validación de reglas de filtrado por categorías y disponibilidad
- [ ] **Pruebas de Transición de Estado**: No aplicable para esta característica

#### Técnicas Basadas en Experiencia
- [x] **Pruebas Exploratorias**: Exploración de combinaciones de filtros y búsquedas no documentadas
- [x] **Adivinación de Errores**: Identificación proactiva de errores como búsquedas con caracteres especiales, URLs malformadas

### Matriz de Cobertura de Tipos de Pruebas

**Definir cobertura completa de tipos de pruebas:**

#### Pruebas Funcionales
- [x] **Validación de Comportamiento de Características**: 
  - Visualización de lista de productos con paginación
  - Búsqueda de productos por texto
  - Filtrado por categorías
  - Visualización de detalles de producto
- [x] **Pruebas de Integración**: ProductsController ↔ ApplicationDbContext ↔ Product Model
- [x] **Pruebas de Extremo a Extremo**: Flujos completos de navegación usando Playwright

#### Pruebas No Funcionales
- [x] **Validación de Rendimiento**: Carga de 10,000 productos, tiempo de respuesta < 2s
- [x] **Validación de Usabilidad**: WCAG 2.1 AA, responsive design, navegación intuitiva
- [x] **Validación de Seguridad**: Inyección SQL, XSS, validación de parámetros
- [x] **Validación de Compatibilidad**: Chrome 120+, Firefox 121+, Safari 17+, Edge 120+

#### Pruebas Estructurales
- [x] **Cobertura de Código**: 80% cobertura de líneas, 90% cobertura de ramas para ProductsController
- [x] **Validación de Arquitectura**: Patrón MVC, separación de responsabilidades

#### Pruebas Relacionadas con Cambios
- [x] **Pruebas de Regresión**: Validación de funcionalidad existente después de cambios
- [x] **Pruebas de Confirmación**: Validación de correcciones de defectos específicos

## Evaluación de Características de Calidad ISO 25010

**Crear una matriz de priorización de características de calidad:**

### Análisis de Prioridad de Características

| Característica de Calidad | Prioridad | Justificación | Enfoque de Validación |
|---------------------------|-----------|---------------|----------------------|
| **Adecuación Funcional** | Crítica | Core business functionality | 100% casos de uso, criterios de aceptación |
| **Eficiencia de Rendimiento** | Alta | User experience critical | Pruebas de carga, benchmarks de tiempo |
| **Usabilidad** | Alta | Customer-facing interface | Testing WCAG, responsive, UX testing |
| **Seguridad** | Alta | E-commerce data protection | Penetration testing, vulnerability scans |
| **Confiabilidad** | Media | Standard web application | Error handling, recovery testing |
| **Compatibilidad** | Media | Multi-browser support needed | Cross-browser automated testing |
| **Mantenibilidad** | Media | Long-term code quality | Code review, static analysis |
| **Portabilidad** | Baja | Single deployment environment | Basic environment testing |

### Evaluación Detallada de Características

#### Adecuación Funcional
- **Completitud**: Validación de todos los casos de uso RF001-RF004
- **Corrección**: Verificación de comportamiento según especificaciones
- **Adecuación**: Evaluación de satisfacción de necesidades de usuario e-commerce

#### Eficiencia de Rendimiento
- **Comportamiento Temporal**: < 2s carga inicial, < 1.5s detalles, < 1s búsqueda
- **Utilización de Recursos**: < 80% CPU, < 85% memoria durante carga pico
- **Capacidad**: Soporte para 10,000 productos, 100 usuarios concurrentes

#### Usabilidad
- **Estética de la Interfaz**: Diseño consistente con Bootstrap, responsive grid
- **Accesibilidad**: WCAG 2.1 AA - alt text, keyboard navigation, color contrast
- **Capacidad de Aprendizaje**: Navegación intuitiva, convenciones e-commerce estándar
- **Operabilidad**: Búsqueda eficiente, filtros claros, paginación fácil

#### Seguridad
- **Confidencialidad**: No aplicable (catálogo público)
- **Integridad**: Validación de entrada, sanitización de parámetros
- **Autenticación**: No requerida para visualización de catálogo
- **Autorización**: Acceso público controlado, prevención de acceso a datos no autorizados

## Estrategia de Entorno de Pruebas y Datos

### Requisitos del Entorno de Pruebas
- **Hardware**: 4GB RAM mínimo, CPU 2 cores para performance testing
- **Software**: .NET 8.0 SDK, SQLite 3.45+, navegadores modernos
- **Red**: Conexión estable para pruebas de carga simuladas

### Gestión de Datos de Prueba
- **Preparación de Datos**: Dataset de 1,000 productos con categorías variadas
- **Privacidad**: Datos sintéticos, sin información real de productos
- **Mantenimiento**: Refresh de datos de prueba antes de cada ciclo de testing

### Selección de Herramientas
- **Herramientas de Prueba**: xUnit para pruebas unitarias, Playwright para E2E
- **Automatización**: GitHub Actions para CI/CD pipeline
- **Monitoreo**: Application Insights para métricas de rendimiento

### Integración CI/CD
- **Pipeline de Pruebas Continuas**: Pruebas unitarias → Pruebas de integración → Pruebas E2E
- **Automatización de Despliegue**: Deploy automático a staging después de pruebas exitosas
- **Retroalimentación**: Notificaciones Slack para resultados de pruebas

## Puertas de Calidad

### Criterios de Entrada
**Requisitos para comenzar cada fase de pruebas:**
- [x] ProductsController implementado con métodos Index, Details, Search
- [x] Product model con validaciones básicas
- [x] Views básicas implementadas (Index.cshtml, Details.cshtml)
- [x] ApplicationDbContext configurado con datos de ejemplo

### Criterios de Salida
**Estándares de calidad requeridos para completar cada fase:**
- [ ] 95% de pruebas unitarias e integración pasando
- [ ] Cobertura de código 80% para ProductsController
- [ ] Pruebas E2E de flujos críticos ejecutándose exitosamente
- [ ] Validación de rendimiento: < 2s carga de lista de productos
- [ ] Cero vulnerabilidades de seguridad críticas o altas
- [ ] Cumplimiento WCAG 2.1 AA validado

### Métricas de Calidad
**Indicadores medibles de logro de calidad:**
- **Cobertura de Código**: 80% cobertura de líneas para ProductsController
- **Tasa de Defectos**: < 2 defectos por 1000 líneas de código
- **Rendimiento**: Tiempo de respuesta promedio < 1.5s
- **Accesibilidad**: 100% cumplimiento criterios WCAG 2.1 AA aplicables

### Procedimientos de Escalamiento
**Proceso para abordar fallas de calidad:**
1. **Falla Menor** (1 métrica fuera de objetivo): Notificación a developer, fix en 24h
2. **Falla Moderada** (múltiples métricas o rendimiento crítico): Reunión de equipo, plan en 12h
3. **Falla Crítica** (seguridad o bloqueador): Escalamiento inmediato a Tech Lead, resolución prioritaria

## Estimación y Planificación

### Estimación de Esfuerzo de Pruebas
- **Pruebas Unitarias**: 8 horas (ProductsController, Product model)
- **Pruebas de Integración**: 6 horas (Controller ↔ DbContext ↔ Model)
- **Pruebas E2E**: 12 horas (3 flujos principales × 4 horas cada uno)
- **Pruebas de Rendimiento**: 4 horas (configuración y ejecución)
- **Pruebas de Seguridad**: 4 horas (análisis de vulnerabilidades)
- **Pruebas de Accesibilidad**: 6 horas (validación manual + automatizada)

### Cronograma de Pruebas
| Fase de Pruebas | Inicio | Fin | Duración | Dependencias |
|-----------------|--------|-----|----------|--------------|
| Planificación | Día 1 | Día 1 | 4h | Requisitos completados |
| Pruebas Unitarias | Día 2 | Día 3 | 8h | Código base implementado |
| Pruebas Integración | Día 3 | Día 4 | 6h | Pruebas unitarias pasando |
| Pruebas E2E | Día 4 | Día 6 | 12h | UI completada |
| Pruebas Rendimiento | Día 6 | Día 7 | 4h | Datos de prueba listos |
| Validación Final | Día 7 | Día 8 | 6h | Todas las pruebas completadas |

### Asignación de Recursos
- **Especialistas en Pruebas Funcionales**: 1 persona (pruebas unitarias/integración)
- **Especialistas en Automatización**: 1 persona (Playwright E2E)
- **Especialistas en Rendimiento**: 0.5 persona (part-time para load testing)
- **Especialistas en Seguridad**: 0.5 persona (security scanning y review)

## Criterios de Éxito

- [x] Todas las técnicas de diseño de pruebas ISTQB aplicadas apropiadamente
- [ ] Todas las características de calidad ISO 25010 evaluadas según prioridad
- [ ] Objetivos de cobertura de código alcanzados (80% líneas, 90% ramas críticas)
- [ ] Todos los riesgos identificados mitigados o aceptados
- [ ] Todas las puertas de calidad aprobadas
- [ ] Métricas de calidad dentro de umbrales establecidos:
  - Tiempo de respuesta < 2 segundos
  - Cobertura de código > 80%
  - Cero vulnerabilidades críticas
  - Cumplimiento WCAG 2.1 AA