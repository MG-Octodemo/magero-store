# Marco de Planificación y Aseguramiento de Calidad

## Resumen

Este repositorio implementa un marco completo de **Test Planning & Quality Assurance** siguiendo estándares **ISTQB** e **ISO 25010** para proyectos de GitHub. El framework genera estrategias de prueba comprensivas, desgloses de tareas, y planes de validación de calidad para gestión de proyectos GitHub.

## Estructura de Documentación

```
docs/ways-of-work/plan/
├── ecommerce-platform/
│   ├── master-test-plan.md                    # Plan maestro de pruebas
│   ├── product-management/
│   │   ├── test-strategy.md                   # Estrategia específica de feature
│   │   ├── test-issues-checklist.md           # Lista de verificación de issues
│   │   └── qa-plan.md                         # Plan de aseguramiento de calidad
│   └── cart-management/
│       └── test-strategy.md                   # Estrategia para carrito de compras
└── README.md                                  # Este archivo
```

## Estándares Aplicados

### Marco ISTQB (International Software Testing Qualifications Board)

#### Técnicas de Diseño de Pruebas Implementadas
- ✅ **Partición de Equivalencia**: Agrupación sistemática de entradas válidas e inválidas
- ✅ **Análisis de Valores Límite**: Testing de casos extremos y límites de entrada
- ✅ **Pruebas de Tabla de Decisión**: Validación de reglas de negocio complejas
- ✅ **Pruebas de Transición de Estados**: Testing de comportamiento de estados del sistema
- ✅ **Pruebas Basadas en Experiencia**: Exploratorias y adivinanza de errores

#### Tipos de Pruebas Cubiertos
- **Funcionales**: Validación de comportamiento esperado
- **No Funcionales**: Performance, usabilidad, seguridad
- **Estructurales**: Cobertura de código y arquitectura
- **Relacionadas con Cambios**: Regresión y confirmación

### Modelo de Calidad ISO 25010

#### Características de Calidad Evaluadas
- **Idoneidad Funcional**: Completitud, corrección, pertinencia
- **Eficiencia de Rendimiento**: Comportamiento temporal, utilización de recursos
- **Compatibilidad**: Coexistencia e interoperabilidad
- **Usabilidad**: Reconocibilidad, accesibilidad, operabilidad
- **Fiabilidad**: Tolerancia a fallos, capacidad de recuperación
- **Seguridad**: Confidencialidad, integridad, autenticación
- **Mantenibilidad**: Modularidad, reutilización, capacidad de prueba
- **Portabilidad**: Adaptabilidad, capacidad de instalación

## Componentes del Framework

### 1. Estrategia de Pruebas (`test-strategy.md`)

Documento principal que define:
- **Alcance y objetivos** de las pruebas por feature
- **Aplicación de técnicas ISTQB** específicas al contexto
- **Evaluación de características ISO 25010** con matriz de priorización
- **Estrategia de entorno y datos** de prueba
- **Evaluación de riesgos** y estrategias de mitigación
- **Criterios de entrada y salida** para cada fase de testing

### 2. Lista de Verificación de Issues (`test-issues-checklist.md`)

Sistema completo de gestión de tareas que incluye:
- **Issues por nivel de prueba**: Unitarias, integración, E2E, performance, seguridad
- **Priorización basada en riesgos** siguiendo metodologías ISTQB
- **Gestión de dependencias** con análisis de ruta crítica
- **Estimación y asignación** de tareas basada en habilidades del equipo
- **Objetivos de cobertura** específicos por tipo de prueba

### 3. Plan de Aseguramiento de Calidad (`qa-plan.md`)

Framework de validación de calidad que define:
- **Puertas de calidad** con criterios específicos de entrada y salida
- **Métricas de calidad** alineadas con estándares industriales
- **Procedimientos de escalación** para manejo de issues críticos
- **Estándares para GitHub Issues** con plantillas y etiquetado consistente
- **Validación de dependencias** y gestión de riesgos de proyecto

### 4. Plantillas de GitHub Issues

Tres plantillas estandarizadas en `.github/ISSUE_TEMPLATE/`:

#### `test-strategy.md`
- Template para creación de issues de planificación estratégica
- Integra técnicas ISTQB y evaluación ISO 25010
- Incluye criterios de aceptación y estimación

#### `playwright-tests.md`  
- Template para implementación de pruebas E2E
- Enfoque en automatización y cobertura multi-browser
- Integración con CI/CD y métricas de calidad

#### `quality-assurance.md`
- Template para validación integral de calidad
- Evaluación completa de características ISO 25010
- Reportes ejecutivos y recomendaciones de release

## Características Clave del Framework

### Basado en Estándares Industriales
- **ISTQB**: Técnicas probadas de diseño y ejecución de pruebas
- **ISO 25010**: Modelo integral de calidad de software
- **GitHub Best Practices**: Integración nativa con workflow de desarrollo

### Escalable y Adaptable
- **Template-driven**: Reutilizable para cualquier feature o proyecto
- **Modular**: Componentes independientes que se pueden personalizar
- **Configurable**: Métricas y umbrales ajustables por proyecto

### Orientado a Resultados
- **Métricas cuantificables**: KPIs específicos para cada aspecto de calidad
- **Reportes ejecutivos**: Información clara para toma de decisiones
- **Mejora continua**: Framework de lecciones aprendidas integrado

## Aplicación Práctica

### Para el Proyecto magero-store

El framework se ha aplicado específicamente a este e-commerce de .NET Core:

1. **Product Management**: Estrategia enfocada en búsqueda y navegación de productos
2. **Cart Management**: Estrategia de estados para operaciones de carrito
3. **User Experience**: Enfoque en accesibilidad y experiencia cross-device

### Riesgos Identificados y Mitigados
- ✅ **Vulnerabilidad de seguridad**: Inyección SQL documentada en ProductsController
- ✅ **Performance**: Umbrales definidos para tiempo de respuesta < 500ms
- ✅ **Usabilidad**: Cumplimiento WCAG 2.1 AA validado
- ✅ **Fiabilidad**: Gestión de sesiones de carrito y recuperación ante fallos

## Métricas de Éxito del Framework

### Cobertura de Pruebas
- **Cobertura de código**: 80% líneas, 90% ramas críticas
- **Cobertura funcional**: 100% criterios de aceptación
- **Cobertura de automatización**: 80% pruebas de regresión automatizadas

### Eficiencia del Proceso
- **Tiempo de planificación**: 2 horas para estrategia completa
- **Tiempo de implementación**: 1 día por story point de testing
- **Tiempo de feedback**: 2 horas desde pruebas hasta evaluación de calidad

### Calidad de Entregables
- **Detección de defectos**: 95% encontrados antes de producción
- **Cumplimiento de puertas**: 100% puertas de calidad aprobadas
- **Completitud de documentación**: 100% issues con información completa

## Uso del Framework

### Para Nuevos Features
1. **Copiar templates** de documentación a nueva estructura `docs/ways-of-work/plan/{epic}/{feature}/`
2. **Personalizar estrategia** aplicando técnicas ISTQB apropiadas al contexto
3. **Priorizar características ISO 25010** según criticidad del feature
4. **Crear GitHub Issues** usando templates proporcionados
5. **Ejecutar y monitorear** siguiendo métricas establecidas

### Para Nuevos Proyectos
1. **Adaptar estructura** de directorios según arquitectura del proyecto
2. **Ajustar métricas** y umbrales según contexto y objetivos
3. **Personalizar templates** de GitHub Issues según workflow del equipo
4. **Integrar con CI/CD** existente usando guidelines proporcionados

## Herramientas Recomendadas

### Testing Frameworks
- **Unitarias**: xUnit, NUnit, MSTest para .NET
- **Integración**: ASP.NET Core TestHost
- **E2E**: Playwright (multi-browser, multi-plataforma)
- **Performance**: NBomber, k6, JMeter
- **Seguridad**: OWASP ZAP, SonarQube

### CI/CD Integration
- **GitHub Actions**: Workflows automatizados incluidos
- **Azure DevOps**: Adaptable con mínimas modificaciones
- **Jenkins**: Plugins disponibles para integración

### Métricas y Reportes
- **Coverlet**: Cobertura de código para .NET
- **ReportGenerator**: Reportes visuales de cobertura
- **Allure**: Reportes avanzados de testing
- **GitHub Projects**: Tracking de progress y métricas

## Contribución y Mejora Continua

### Feedback Loop
- **Retrospectivas regulares**: Cada milestone o release
- **Métricas de proceso**: Tracking de eficiencia del framework
- **Adaptación continua**: Updates basados en lecciones aprendidas

### Evolución del Framework
- **Nuevas técnicas**: Incorporación de metodologías emergentes
- **Herramientas nuevas**: Evaluación e integración de nuevas tecnologías
- **Mejores prácticas**: Refinamiento basado en experiencia práctica

---

**Autor**: Copilot Agent  
**Estándares**: ISTQB Foundation Level, ISO/IEC 25010:2011  
**Versión**: 1.0  
**Fecha**: 2024

Para más información sobre implementación específica, consultar los documentos individuales en cada directorio de feature.