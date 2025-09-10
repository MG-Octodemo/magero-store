---
name: Garantía de Calidad
about: Crear un issue de garantía de calidad siguiendo estándares ISO 25010
title: 'Garantía de Calidad: [Nombre de la Característica]'
labels: ['quality-assurance', 'iso25010', 'quality-gates']
assignees: ''
---

# Garantía de Calidad: {Nombre de la Característica}

## Alcance de Validación de Calidad

**Validación general de calidad para característica/épica:**
{Describir el alcance completo de validación de calidad}

## Evaluación de Calidad ISO 25010

### Validación de Características de Calidad

#### Adecuación Funcional
- [ ] **Completitud**: Completitud, corrección, adecuación
  - {Describir criterios de completitud}
- [ ] **Corrección**: Validación de comportamiento correcto
  - {Describir pruebas de corrección}
- [ ] **Adecuación**: Evaluación de adecuación para el propósito
  - {Describir criterios de adecuación}

#### Eficiencia de Rendimiento
- [ ] **Comportamiento Temporal**: Tiempo de comportamiento, utilización de recursos, capacidad
  - Tiempo de respuesta objetivo: {X}ms
  - Throughput objetivo: {X} TPS
- [ ] **Utilización de Recursos**: CPU, memoria, almacenamiento, red
  - CPU máximo: {X}%
  - Memoria máxima: {X}%
- [ ] **Capacidad**: Límites máximos del sistema
  - Usuarios concurrentes: {X}
  - Volumen de datos: {X}

#### Usabilidad
- [ ] **Estética de Interfaz**: Estética de interfaz, accesibilidad, aprendizaje, operabilidad
  - {Describir estándares de diseño}
- [ ] **Accesibilidad**: Cumplimiento WCAG {nivel}
  - {Describir criterios específicos}
- [ ] **Capacidad de Aprendizaje**: Facilidad de aprendizaje para nuevos usuarios
  - {Describir métricas de aprendizaje}
- [ ] **Operabilidad**: Facilidad de operación y control
  - {Describir criterios de operabilidad}

#### Seguridad
- [ ] **Confidencialidad**: Confidencialidad, integridad, autenticación, autorización
  - {Describir controles de confidencialidad}
- [ ] **Integridad**: Protección de datos y validación
  - {Describir validaciones de integridad}
- [ ] **Autenticación**: Sistemas de autenticación
  - {Describir mecanismos de autenticación}
- [ ] **Autorización**: Control de acceso y permisos
  - {Describir matriz de permisos}

#### Confiabilidad
- [ ] **Tolerancia a Fallos**: Tolerancia a fallos, recuperabilidad, disponibilidad
  - {Describir manejo de fallos}
- [ ] **Recuperabilidad**: Capacidades de recuperación
  - RTO objetivo: {X} minutos
  - RPO objetivo: {X} minutos
- [ ] **Disponibilidad**: Objetivos de tiempo de actividad
  - SLA objetivo: {X}% disponibilidad

#### Compatibilidad
- [ ] **Coexistencia**: Compatibilidad con navegadores, dispositivos, integración
  - {Listar plataformas soportadas}
- [ ] **Interoperabilidad**: Capacidades de integración
  - {Describir integraciones}

#### Mantenibilidad
- [ ] **Modularidad**: Calidad de código, modularidad, capacidad de prueba
  - {Describir métricas de código}
- [ ] **Reutilización**: Oportunidades de reutilización
  - {Describir componentes reutilizables}
- [ ] **Capacidad de Prueba**: Facilidad de prueba y validación
  - {Describir estrategia de pruebas}

#### Portabilidad
- [ ] **Adaptabilidad**: Adaptabilidad del entorno, procedimientos de instalación
  - {Describir requisitos de entorno}
- [ ] **Capacidad de Instalación**: Facilidad de instalación
  - {Describir proceso de instalación}
- [ ] **Capacidad de Reemplazo**: Facilidad de reemplazo
  - {Describir estrategia de migración}

## Validación de Puertas de Calidad

### Criterios de Entrada
- [ ] **Tareas de implementación completadas**
  - {Listar tareas críticas}
- [ ] **Pruebas unitarias aprobadas**
  - Cobertura mínima: {X}%
- [ ] **Revisión de código aprobada**
  - {Describir criterios de revisión}

### Criterios de Salida
- [ ] **Todos los tipos de prueba completados con 95% de tasa de éxito**
  - {Describir tipos de prueba}
- [ ] **No hay defectos críticos/alta severidad**
  - {Describir criterios de severidad}
- [ ] **Benchmarks de rendimiento cumplidos**
  - {Listar benchmarks específicos}
- [ ] **Validación de seguridad aprobada**
  - {Describir validaciones de seguridad}

## Métricas de Calidad

### Métricas de Cobertura
- [ ] **Cobertura de prueba**: {objetivo}%
- [ ] **Cobertura funcional**: {objetivo}%
- [ ] **Cobertura de riesgo**: {objetivo}%

### Métricas de Defectos
- [ ] **Densidad de defectos**: {objetivo} defectos/KLOC
- [ ] **Tiempo de resolución**: Defectos críticos < {X} horas
- [ ] **Tasa de escape**: < {X}% defectos en producción
- [ ] **Efectividad de detección**: > {X}% defectos encontrados pre-producción

### Métricas de Rendimiento
- [ ] **Tiempo de respuesta**: {X}% transacciones < {Y}ms
- [ ] **Throughput**: {X} transacciones por segundo
- [ ] **Utilización de recursos**: CPU < {X}%, memoria < {Y}%
- [ ] **Disponibilidad**: {X}% tiempo de actividad

### Métricas de Seguridad
- [ ] **Vulnerabilidades críticas**: Cero vulnerabilidades críticas
- [ ] **Pruebas de penetración**: Aprobación de auditoría
- [ ] **Autenticación**: 100% endpoints protegidos validados
- [ ] **Autorización**: 100% controles de acceso probados

### Métricas de Usabilidad
- [ ] **Accesibilidad WCAG**: Nivel {AA/AAA}
- [ ] **Tiempo de tarea**: Tareas principales < {X} segundos
- [ ] **Tasa de error de usuario**: < {X}% errores
- [ ] **Satisfacción**: Puntuación > {X}/10

## Proceso de Validación

### Fases de Validación
1. **Validación de Implementación**
   - [ ] Revisión de código completada
   - [ ] Pruebas unitarias aprobadas
   - [ ] Integración básica validada

2. **Validación Funcional**
   - [ ] Casos de prueba funcional ejecutados
   - [ ] Criterios de aceptación validados
   - [ ] Flujos de usuario verificados

3. **Validación No Funcional**
   - [ ] Pruebas de rendimiento ejecutadas
   - [ ] Validación de seguridad completada
   - [ ] Pruebas de usabilidad realizadas

4. **Validación de Integración**
   - [ ] Pruebas de integración completadas
   - [ ] Validación de sistemas externos
   - [ ] Pruebas de regresión ejecutadas

## Gestión de Riesgos de Calidad

### Riesgos Identificados
| Riesgo | Probabilidad | Impacto | Mitigación |
|--------|--------------|---------|------------|
| {Riesgo 1} | Alto/Medio/Bajo | Alto/Medio/Bajo | {Estrategia} |
| {Riesgo 2} | Alto/Medio/Bajo | Alto/Medio/Bajo | {Estrategia} |

### Plan de Contingencia
- [ ] **Riesgos Críticos**: {Describir plan para riesgos críticos}
- [ ] **Riesgos de Cronograma**: {Describir mitigaciones de tiempo}
- [ ] **Riesgos Técnicos**: {Describir alternativas técnicas}

## Estimación y Cronograma

**Esfuerzo de validación de calidad:** {3-5} puntos de historia

### Cronograma de Validación
| Actividad | Duración | Dependencias | Responsable |
|-----------|----------|--------------|-------------|
| Planificación QA | {X} días | Estrategia aprobada | QA Lead |
| Validación Funcional | {X} días | Implementación completa | QA Team |
| Validación No Funcional | {X} días | Entorno configurado | Especialistas |
| Reporte Final | {X} días | Todas las validaciones | QA Lead |

## Dependencias de Calidad

### Dependencias de Implementación
- [ ] {Tarea 1} - #{issue_number}
- [ ] {Tarea 2} - #{issue_number}

### Dependencias de Entorno
- [ ] Entorno de QA configurado
- [ ] Datos de prueba preparados
- [ ] Herramientas de monitoreo instaladas

### Dependencias de Revisión
- [ ] Revisión de arquitectura completada
- [ ] Revisión de seguridad aprobada
- [ ] Revisión de rendimiento validada

## Criterios de Aceptación

### Criterios Funcionales
- [ ] **100% criterios de aceptación validados**
- [ ] **Cero defectos críticos pendientes**
- [ ] **Flujos de usuario principales verificados**

### Criterios No Funcionales
- [ ] **Objetivos de rendimiento cumplidos**
- [ ] **Estándares de seguridad validados**
- [ ] **Requisitos de accesibilidad cumplidos**

### Criterios de Proceso
- [ ] **Todas las puertas de calidad aprobadas**
- [ ] **Documentación de calidad completada**
- [ ] **Métricas de calidad dentro de umbrales**

## Entregables de QA

- [ ] **Reporte de Validación de Calidad**
- [ ] **Matriz de Trazabilidad de Requisitos**
- [ ] **Reporte de Métricas de Calidad**
- [ ] **Certificación de Lanzamiento**

## Enlaces Relacionados

- [ ] Issue de estrategia de pruebas: #{número}
- [ ] Issues de implementación de pruebas: #{números}
- [ ] Documentación de arquitectura: [enlace]
- [ ] Requisitos de calidad: [enlace]

---

**Notas de Calidad:**
{Cualquier consideración especial de calidad, limitaciones conocidas, o recomendaciones para futuras mejoras}