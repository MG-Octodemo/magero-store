---
name: Quality Assurance Plan
about: Plan de aseguramiento de calidad para feature/epic completo
title: '[QA-PLAN] '
labels: quality-assurance, iso25010, quality-gates
assignees: ''
---

# Quality Assurance: {Nombre de Feature}

## Alcance de Validación de Calidad
{Descripción general de la validación de calidad para feature/epic}

## Evaluación de Calidad ISO 25010

### Validación de Características de Calidad:
- [ ] **Idoneidad Funcional**: Completitud, corrección, pertinencia
- [ ] **Eficiencia de Desempeño**: Comportamiento temporal, utilización de recursos, capacidad
- [ ] **Usabilidad**: Estética de interfaz, accesibilidad, capacidad de aprendizaje, operabilidad
- [ ] **Seguridad**: Confidencialidad, integridad, autenticación, autorización
- [ ] **Fiabilidad**: Tolerancia a fallos, recuperabilidad, disponibilidad
- [ ] **Compatibilidad**: Compatibilidad de navegador, dispositivo, integración
- [ ] **Mantenibilidad**: Calidad de código, modularidad, testeabilidad
- [ ] **Portabilidad**: Adaptabilidad de entorno, procedimientos de instalación

## Validación de Puertas de Calidad

### Criterios de Entrada:
- [ ] Todas las tareas de implementación completadas
- [ ] Pruebas unitarias pasando
- [ ] Code review aprobado

### Criterios de Salida:
- [ ] Todos los tipos de prueba completados con 95% de tasa de éxito
- [ ] No hay defectos críticos o de alta severidad
- [ ] Benchmarks de rendimiento cumplidos
- [ ] Validación de seguridad pasada
- [ ] Pruebas de accesibilidad pasadas

## Métricas de Calidad

### Cobertura de Pruebas:
- [ ] Cobertura de código: {objetivo}%
- [ ] Cobertura funcional: {objetivo}%
- [ ] Cobertura de riesgos: 100% escenarios de alto riesgo

### Defectos:
- [ ] Densidad de defectos: {umbral} defectos/KLOC
- [ ] Tasa de escape de defectos: < 5%

### Rendimiento:
- [ ] Tiempo de respuesta: < {umbral}ms (p95)
- [ ] Throughput: > {umbral} req/seg
- [ ] Utilización de recursos: dentro de límites

### Seguridad:
- [ ] Cero vulnerabilidades críticas
- [ ] Cero vulnerabilidades altas sin mitigación
- [ ] Cumplimiento OWASP Top 10

### Accesibilidad:
- [ ] Cumplimiento WCAG {nivel}
- [ ] Navegación por teclado completa
- [ ] Compatibilidad con lectores de pantalla

## Tipos de Prueba Requeridos

### Pruebas Funcionales:
- [ ] Pruebas unitarias
- [ ] Pruebas de integración
- [ ] Pruebas E2E

### Pruebas No Funcionales:
- [ ] Pruebas de rendimiento
- [ ] Pruebas de carga
- [ ] Pruebas de seguridad
- [ ] Pruebas de accesibilidad

### Pruebas Relacionadas con Cambios:
- [ ] Suite de regresión completa
- [ ] Pruebas de confirmación de defectos

## Gestión de Riesgos

| Riesgo | Impacto | Probabilidad | Mitigación |
|--------|---------|--------------|------------|
| {Riesgo 1} | {Alto/Medio/Bajo} | {Alta/Media/Baja} | {Plan de mitigación} |

## Dependencias
- {Issue o componente bloqueante}

## Cronograma de QA

- **Inicio de Testing**: {Fecha}
- **Finalización de Testing**: {Fecha}
- **UAT**: {Fecha}
- **Sign-off**: {Fecha}

## Sign-off Requerido

- [ ] QA Lead
- [ ] Tech Lead
- [ ] Product Owner
- [ ] Security Lead (si aplica)

---

**Estimación**: {3-5 story points}
**Prioridad**: {critical/high/medium/low}
**Fase**: {Planning/Execution/Completion}
