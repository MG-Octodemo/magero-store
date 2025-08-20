# Estrategia de Pruebas: Gestión de Productos

## Resumen de la Estrategia de Pruebas

### Alcance de las Pruebas
- **Componentes a probar**: ProductsController, modelos Product, vistas de productos, funcionalidad de búsqueda
- **Objetivos de calidad**: Validación completa de funcionalidad de navegación, búsqueda y visualización de productos
- **Evaluación de riesgos**: Vulnerabilidades de seguridad identificadas (inyección SQL), rendimiento de búsqueda, experiencia de usuario
- **Enfoque de pruebas**: Metodología basada en riesgos siguiendo marcos ISTQB e ISO 25010

### Riesgos Identificados y Estrategias de Mitigación
- **Alto Riesgo**: Vulnerabilidad de inyección SQL en método Search de ProductsController
- **Medio Riesgo**: Rendimiento de búsqueda con grandes volúmenes de datos
- **Bajo Riesgo**: Problemas de experiencia de usuario en navegación de productos

## Implementación del Marco ISTQB

### Selección de Técnicas de Diseño de Pruebas

#### Partición de Equivalencia
- **Términos de búsqueda válidos**: Palabras clave existentes en productos
- **Términos de búsqueda inválidos**: Cadenas vacías, caracteres especiales, SQL injection
- **IDs de productos válidos**: Productos existentes en SampleData
- **IDs de productos inválidos**: IDs negativos, no existentes, tipos incorrectos

#### Análisis de Valores Límite
- **Búsqueda de productos**: Cadenas de 0, 1, 255, 256 caracteres
- **IDs de productos**: 0, 1, MAX_INT, valores negativos
- **Resultados de búsqueda**: 0 resultados, 1 resultado, múltiples resultados

#### Pruebas de Tabla de Decisión
- **Búsqueda de productos**: Combinaciones de términos válidos/inválidos con diferentes filtros
- **Visualización de detalles**: Estados de producto (disponible/no disponible) con diferentes roles de usuario

#### Pruebas de Transición de Estados
- **Estados de producto**: Carga inicial → Búsqueda → Resultados → Detalles → Retorno a lista
- **Estados de sesión**: Usuario anónimo → Navegación → Búsqueda → Visualización

#### Pruebas Basadas en Experiencia
- **Pruebas exploratorias**: Navegación intuitiva, comportamientos inesperados
- **Adivinanza de errores**: Ataques de inyección SQL, manipulación de URLs

### Matriz de Cobertura de Tipos de Pruebas

#### Pruebas Funcionales
- ✅ **Navegación de productos**: Listado, paginación, filtrado
- ✅ **Búsqueda de productos**: Funcionalidad de búsqueda por nombre y descripción
- ✅ **Detalles de productos**: Visualización completa de información del producto
- ✅ **Validación de entrada**: Manejo de parámetros de búsqueda

#### Pruebas No Funcionales
- ✅ **Rendimiento**: Tiempo de respuesta de búsqueda < 500ms
- ✅ **Usabilidad**: Interfaz intuitiva, accesibilidad WCAG 2.1 AA
- ✅ **Seguridad**: Prevención de inyección SQL, validación de entrada
- ✅ **Compatibilidad**: Navegadores modernos, dispositivos móviles

#### Pruebas Estructurales
- ✅ **Cobertura de código**: 80% cobertura de líneas, 90% cobertura de ramas críticas
- ✅ **Validación de arquitectura**: Separación MVC, gestión de dependencias

#### Pruebas Relacionadas con Cambios
- ✅ **Regresión**: Funcionalidad existente después de cambios
- ✅ **Confirmación**: Corrección de defectos identificados

## Evaluación de Características de Calidad ISO 25010

### Matriz de Priorización de Características de Calidad

#### Idoneidad Funcional - **CRÍTICA**
- **Completitud**: 100% de criterios de aceptación implementados
- **Corrección**: 0 defectos críticos en funcionalidad principal
- **Pertinencia**: Alineación completa con requisitos de negocio

#### Eficiencia de Rendimiento - **ALTA**
- **Comportamiento temporal**: Tiempo de respuesta < 500ms para búsquedas
- **Utilización de recursos**: Uso de memoria < 100MB por sesión
- **Capacidad**: Soporte para 1000 usuarios concurrentes

#### Compatibilidad - **ALTA**
- **Coexistencia**: Funcionamiento sin conflictos con otros sistemas
- **Interoperabilidad**: Integración correcta con base de datos SQLite

#### Usabilidad - **ALTA**
- **Reconocibilidad**: Interfaz clara e intuitiva
- **Capacidad de aprendizaje**: Usuario puede navegar sin formación previa
- **Operabilidad**: Navegación fluida en todos los dispositivos
- **Accesibilidad**: Cumplimiento WCAG 2.1 AA

#### Fiabilidad - **MEDIA**
- **Tolerancia a fallos**: Manejo adecuado de errores
- **Capacidad de recuperación**: Retorno a estado estable tras errores
- **Disponibilidad**: 99% de tiempo operativo

#### Seguridad - **CRÍTICA**
- **Confidencialidad**: Protección de datos sensibles
- **Integridad**: Prevención de manipulación de datos
- **Autenticación**: Validación correcta de entrada
- **Autorización**: Control de acceso apropiado

#### Mantenibilidad - **MEDIA**
- **Modularidad**: Separación clara de responsabilidades
- **Reutilización**: Componentes reutilizables
- **Capacidad de prueba**: Código fácilmente testeable

#### Portabilidad - **BAJA**
- **Adaptabilidad**: Funcionamiento en diferentes entornos
- **Capacidad de instalación**: Proceso de instalación simple

## Estrategia de Entorno y Datos de Prueba

### Requisitos de Entorno de Pruebas
- **Hardware**: Servidor local con .NET 8.0 runtime
- **Software**: SQLite, navegadores web (Chrome, Firefox, Safari, Edge)
- **Red**: Conexión HTTP/HTTPS local

### Estrategia de Gestión de Datos de Prueba
- **Preparación de datos**: Uso de SampleData.cs para datos consistentes
- **Privacidad**: No se manejan datos personales reales
- **Mantenimiento**: Reset automático de datos entre ejecuciones de prueba

### Selección de Herramientas
- **Pruebas unitarias**: xUnit, NUnit o MSTest
- **Pruebas de integración**: ASP.NET Core TestHost
- **Pruebas E2E**: Playwright para automatización de navegador
- **Pruebas de rendimiento**: NBomber o k6
- **Cobertura de código**: Coverlet

### Integración CI/CD
- **Pipeline de pruebas continuas**: GitHub Actions
- **Ejecución automática**: En cada push y pull request
- **Reporte de resultados**: Integración con GitHub Checks
- **Umbrales de calidad**: 80% cobertura mínima, 0 pruebas fallidas

## Criterios de Entrada y Salida

### Criterios de Entrada
- ✅ Código de implementación completado y revisado
- ✅ Entorno de pruebas configurado y disponible
- ✅ Datos de prueba preparados y validados
- ✅ Herramientas de prueba instaladas y configuradas

### Criterios de Salida
- ✅ 95% de pruebas ejecutadas exitosamente
- ✅ 0 defectos críticos o de alta severidad
- ✅ Cobertura de código ≥ 80%
- ✅ Umbrales de rendimiento cumplidos
- ✅ Validación de seguridad completada
- ✅ Documentación de resultados generada

## Métricas de Éxito

### Métricas de Cobertura de Pruebas
- **Cobertura de código**: 80% cobertura de líneas, 90% cobertura de ramas para rutas críticas
- **Cobertura funcional**: 100% validación de criterios de aceptación
- **Cobertura de riesgos**: 100% de escenarios de alto riesgo probados
- **Cobertura de características de calidad**: Validación para todas las características ISO 25010 aplicables

### Métricas de Validación de Calidad
- **Tasa de detección de defectos**: 95% de defectos encontrados antes de producción
- **Eficiencia de ejecución de pruebas**: 90% de cobertura de automatización
- **Cumplimiento de puertas de calidad**: 100% de puertas de calidad aprobadas antes del release
- **Mitigación de riesgos**: 100% de riesgos identificados abordados con estrategias de mitigación

### Métricas de Eficiencia del Proceso
- **Tiempo de planificación de pruebas**: 2 horas para crear estrategia de pruebas completa
- **Velocidad de implementación de pruebas**: 1 día por punto de historia de desarrollo de pruebas
- **Tiempo de retroalimentación de calidad**: 2 horas desde finalización de pruebas hasta evaluación de calidad
- **Completitud de documentación**: 100% de issues de prueba tienen información completa de plantilla