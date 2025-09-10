# Test Planning & Quality Assurance Framework

## Descripción General

Este framework de planificación de pruebas y garantía de calidad está diseñado para proporcionar un enfoque integral y estandarizado para la validación de calidad en proyectos de desarrollo de software, siguiendo los estándares ISTQB e ISO 25010.

## Estructura de Documentación

Para cada épica y característica, se debe crear la siguiente estructura de documentación:

```
docs/ways-of-work/plan/{epic-name}/{feature-name}/
├── feature-name.md                    # PRD de la característica
├── technical-breakdown.md             # Desglose técnico
├── implementation-plan.md             # Plan de implementación
├── project-plan.md                   # Plan de proyecto GitHub
├── test-strategy.md                  # Estrategia de pruebas (ISTQB)
├── test-issues-checklist.md          # Lista de verificación de problemas de prueba
└── qa-plan.md                        # Plan de garantía de calidad (ISO 25010)
```

## Estándares de Calidad

### Framework ISTQB

- **Actividades del Proceso de Pruebas**: Planificación, monitoreo, análisis, diseño, implementación, ejecución, finalización
- **Técnicas de Diseño de Pruebas**: Enfoques de caja negra, caja blanca y basados en experiencia
- **Tipos de Pruebas**: Funcionales, no funcionales, estructurales y relacionadas con cambios
- **Pruebas Basadas en Riesgo**: Estrategias de evaluación y mitigación de riesgos

### Modelo de Calidad ISO 25010

- **Características de Calidad**: Adecuación funcional, eficiencia de rendimiento, compatibilidad, usabilidad, confiabilidad, seguridad, mantenibilidad, portabilidad
- **Validación de Calidad**: Enfoques de medición y evaluación para cada característica
- **Puertas de Calidad**: Criterios de entrada y salida para puntos de control de calidad

## Plantillas Disponibles

### Plantillas de Documentación
- [Estrategia de Pruebas](templates/test-strategy-template.md)
- [Lista de Verificación de Problemas de Prueba](templates/test-issues-checklist-template.md)
- [Plan de Garantía de Calidad](templates/qa-plan-template.md)

### Plantillas de Issues de GitHub
- [Estrategia de Pruebas](../../.github/ISSUE_TEMPLATE/test-strategy.md)
- [Implementación de Pruebas Playwright](../../.github/ISSUE_TEMPLATE/playwright-test.md)
- [Garantía de Calidad](../../.github/ISSUE_TEMPLATE/quality-assurance.md)

## Métricas de Éxito

### Métricas de Cobertura de Pruebas
- **Cobertura de Código**: 80% cobertura de líneas, 90% cobertura de ramas para rutas críticas
- **Cobertura Funcional**: 100% validación de criterios de aceptación
- **Cobertura de Riesgo**: 100% pruebas de escenarios de alto riesgo
- **Cobertura de Características de Calidad**: Enfoque de validación para cada característica ISO 25010

### Métricas de Validación de Calidad
- **Tasa de Detección de Defectos**: 95% de defectos encontrados antes de producción
- **Eficiencia de Ejecución de Pruebas**: 90% cobertura de automatización de pruebas
- **Cumplimiento de Puertas de Calidad**: 100% puertas de calidad aprobadas antes del lanzamiento
- **Mitigación de Riesgos**: 100% riesgos identificados abordados con estrategias de mitigación

## Uso del Framework

1. **Crear estructura de épica/característica** en `docs/ways-of-work/plan/{epic-name}/{feature-name}/`
2. **Completar documentos de planificación** (PRD, desglose técnico, plan de implementación)
3. **Desarrollar estrategia de pruebas** usando plantillas ISTQB
4. **Crear issues de GitHub** usando plantillas proporcionadas
5. **Implementar plan de QA** siguiendo estándares ISO 25010
6. **Validar métricas de calidad** en cada puerta de calidad

## Ejemplos

Ver la implementación de ejemplo en:
- [E-commerce Epic / Product Catalog Feature](e-commerce/product-catalog/)

Este ejemplo muestra la aplicación completa del framework para una característica real del proyecto magero-store.