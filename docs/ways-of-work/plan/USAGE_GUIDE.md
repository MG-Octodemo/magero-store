# Guía de Uso del Framework de Planificación de Pruebas

## Introducción

Esta guía proporciona instrucciones paso a paso para utilizar el framework de planificación de pruebas y garantía de calidad implementado en el proyecto magero-store. El framework sigue los estándares ISTQB e ISO 25010 para asegurar una cobertura de pruebas integral y calidad del software.

## Estructura del Framework

### Documentos Principales por Característica

Para cada nueva característica o épica, debes crear la siguiente estructura:

```
docs/ways-of-work/plan/{epic-name}/{feature-name}/
├── {feature-name}.md                    # PRD de la característica
├── technical-breakdown.md               # Análisis técnico detallado
├── implementation-plan.md               # Plan de implementación técnica
├── project-plan.md                     # Plan de gestión de proyecto GitHub
├── test-strategy.md                    # Estrategia de pruebas (ISTQB)
├── test-issues-checklist.md           # Lista de verificación de issues de prueba
└── qa-plan.md                          # Plan de garantía de calidad (ISO 25010)
```

## Proceso Paso a Paso

### Paso 1: Planificación de la Característica

1. **Crear PRD de la Característica**
   - Copia la plantilla base o usa el ejemplo del catálogo de productos
   - Define requisitos funcionales y no funcionales
   - Establece criterios de aceptación medibles
   - Identifica casos de uso principales

2. **Desarrollar Desglose Técnico**
   - Analiza la arquitectura requerida
   - Identifica componentes y dependencias
   - Estima complejidad técnica
   - Define interfaces y contratos

### Paso 2: Aplicación del Framework ISTQB

1. **Crear Estrategia de Pruebas**
   - Usa la plantilla: `templates/test-strategy-template.md`
   - Selecciona técnicas de diseño de pruebas ISTQB apropiadas:
     - **Partición de Equivalencia**: Para clasificar entradas
     - **Análisis de Valores Límite**: Para casos extremos
     - **Pruebas de Tabla de Decisión**: Para lógica compleja
     - **Pruebas Basadas en Experiencia**: Para casos no documentados

2. **Definir Tipos de Pruebas**
   ```
   Funcionales:    ✓ Comportamiento de características
   No Funcionales: ✓ Rendimiento, Usabilidad, Seguridad
   Estructurales:  ✓ Cobertura de código, Arquitectura
   Cambios:        ✓ Regresión, Confirmación
   ```

### Paso 3: Evaluación ISO 25010

1. **Priorizar Características de Calidad**
   - Evalúa cada característica ISO 25010:
     - Adecuación Funcional (generalmente Crítica)
     - Eficiencia de Rendimiento (Alta para interfaces usuario)
     - Usabilidad (Alta para características customer-facing)
     - Seguridad (Alta para manejo de datos)
     - Confiabilidad, Compatibilidad, Mantenibilidad, Portabilidad

2. **Definir Criterios de Validación**
   - Establece métricas específicas para cada característica priorizada
   - Crea umbrales de aceptación cuantificables
   - Define métodos de validación

### Paso 4: Planificación de Issues de GitHub

1. **Crear Lista de Verificación de Issues**
   - Usa la plantilla: `templates/test-issues-checklist-template.md`
   - Identifica todos los tipos de prueba necesarios
   - Estima esfuerzo usando directrices del framework
   - Documenta dependencias entre issues

2. **Crear Issues de GitHub**
   - Usa las plantillas en `.github/ISSUE_TEMPLATE/`:
     - `test-strategy.md` para estrategia general
     - `playwright-test.md` para pruebas E2E
     - `quality-assurance.md` para validación QA
   - Aplica etiquetas consistentes
   - Asigna prioridades basadas en riesgo

### Paso 5: Plan de Garantía de Calidad

1. **Definir Puertas de Calidad**
   - Usa la plantilla: `templates/qa-plan-template.md`
   - Establece criterios de entrada y salida para cada fase
   - Define métricas de calidad específicas
   - Crea procedimientos de escalamiento

2. **Configurar Métricas y Monitoreo**
   - Cobertura de código: 80% líneas, 90% ramas críticas
   - Métricas de defectos: < 2 defectos/1000 líneas
   - Métricas de rendimiento: específicas por característica
   - Métricas de seguridad: cero vulnerabilidades críticas

## Plantillas Disponibles

### Plantillas de Documentación

#### Test Strategy Template
```bash
cp docs/ways-of-work/plan/templates/test-strategy-template.md \
   docs/ways-of-work/plan/{epic}/{feature}/test-strategy.md
```

#### Test Issues Checklist Template  
```bash
cp docs/ways-of-work/plan/templates/test-issues-checklist-template.md \
   docs/ways-of-work/plan/{epic}/{feature}/test-issues-checklist.md
```

#### QA Plan Template
```bash
cp docs/ways-of-work/plan/templates/qa-plan-template.md \
   docs/ways-of-work/plan/{epic}/{feature}/qa-plan.md
```

### Plantillas de Issues de GitHub

#### Crear Issue de Estrategia de Pruebas
1. Ve a GitHub → Issues → New Issue
2. Selecciona "Estrategia de Pruebas"
3. Completa todos los campos obligatorios
4. Aplica etiquetas: `test-strategy`, `istqb`, `iso25010`

#### Crear Issue de Pruebas Playwright
1. Selecciona "Pruebas Playwright"
2. Define alcance específico (componente/flujo)
3. Lista casos de prueba E2E requeridos
4. Aplica etiquetas: `playwright`, `e2e-test`

#### Crear Issue de Garantía de Calidad
1. Selecciona "Garantía de Calidad"
2. Define evaluación ISO 25010 requerida
3. Establece métricas de calidad específicas
4. Aplica etiquetas: `quality-assurance`, `iso25010`

## Mejores Prácticas

### Estimación de Esfuerzo

#### Directrices Generales
- **Pruebas Unitarias**: 0.5-1 punto por componente
- **Pruebas de Integración**: 1-2 puntos por interfaz
- **Pruebas E2E**: 2-3 puntos por flujo de usuario
- **Pruebas de Rendimiento**: 3-5 puntos por requisito
- **Pruebas de Seguridad**: 2-4 puntos por requisito

#### Factores de Ajuste
- **Complejidad Técnica**: +20-50% para componentes complejos
- **Nuevas Tecnologías**: +25% para herramientas no utilizadas
- **Dependencias Externas**: +20% para dependencias fuera del control
- **Equipo Nuevo**: +15% para miembros sin experiencia en dominio

### Gestión de Riesgos

#### Identificación de Riesgos
1. **Riesgos Técnicos**: Rendimiento, compatibilidad, integración
2. **Riesgos de Proceso**: Dependencias, recursos, cronograma
3. **Riesgos de Calidad**: Cobertura insuficiente, defectos críticos

#### Estrategias de Mitigación
- **Paralelización**: Trabajar en múltiples tracks simultáneamente
- **Prototipos Tempranos**: Validar enfoques antes de implementación completa
- **Buffers de Tiempo**: 15-25% adicional para tareas de alta incertidumbre
- **Plan B**: Alternativas para dependencias críticas

### Validación Continua

#### Reviews Requeridos
- **Estrategia de Pruebas**: Aprobación de Tech Lead y QA Lead
- **Casos de Prueba**: Revisión por pares antes de implementación
- **Resultados de Prueba**: Validación de métricas antes de release

#### Métricas de Tracking
- **Precisión de Estimación**: Target 90% dentro de 20% del actual
- **Velocidad de Equipo**: Tracking de story points por sprint
- **Calidad de Release**: Defectos encontrados post-release

## Ejemplo Completo: Catálogo de Productos

Consulta la implementación completa en:
```
docs/ways-of-work/plan/e-commerce/product-catalog/
```

Este ejemplo muestra:
- ✅ Aplicación completa del framework ISTQB
- ✅ Evaluación exhaustiva ISO 25010
- ✅ Plan detallado de issues de GitHub
- ✅ Estrategias de mitigación de riesgos
- ✅ Métricas de calidad específicas

## Herramientas y Tecnologías

### Frameworks de Prueba Recomendados
- **Pruebas Unitarias**: xUnit para .NET
- **Pruebas de Integración**: Microsoft.AspNetCore.Mvc.Testing
- **Pruebas E2E**: Playwright para automatización de navegador
- **Pruebas de Rendimiento**: JMeter o NBomber
- **Pruebas de Seguridad**: OWASP ZAP

### CI/CD Integration
```yaml
# Ejemplo GitHub Actions workflow
- name: Unit Tests
  run: dotnet test --collect:"XPlat Code Coverage"
  
- name: E2E Tests  
  run: npx playwright test
  
- name: Quality Gates
  run: dotnet sonarscanner end
```

## Soporte y Recursos

### Documentación de Referencia
- [ISTQB Foundation Level Syllabus](https://www.istqb.org/)
- [ISO/IEC 25010 Quality Model](https://iso25000.com/index.php/en/iso-25000-standards/iso-25010)
- [Playwright Documentation](https://playwright.dev/)

### Contactos del Equipo
- **QA Lead**: Responsable de estrategia de pruebas y calidad
- **Tech Lead**: Validación técnica y arquitectura de pruebas
- **DevOps**: Configuración de pipeline CI/CD y entornos

### Proceso de Mejora Continua
- **Retrospectivas Sprint**: Identificar mejoras en proceso de testing
- **Calibración de Estimaciones**: Refinar factores de estimación basado en actuals
- **Actualización de Plantillas**: Evolucionar plantillas basado en aprendizajes