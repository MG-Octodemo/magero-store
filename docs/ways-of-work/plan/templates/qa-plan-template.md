# Plan de Garantía de Calidad: {Nombre de la Característica}

## Puertas de Calidad y Puntos de Control

### Creación de puntos de control de validación de calidad integral

#### Criterios de Entrada
**Requisitos para comenzar cada fase de pruebas:**

##### Fase de Planificación de Pruebas
- [ ] **Requisitos completados y aprobados**: Todos los requisitos funcionales y no funcionales documentados
- [ ] **Arquitectura técnica definida**: Diseño técnico revisado y aprobado
- [ ] **Entorno de desarrollo configurado**: Entorno base preparado para desarrollo
- [ ] **Equipo de pruebas asignado**: Recursos humanos identificados y disponibles

##### Fase de Diseño de Pruebas
- [ ] **Estrategia de pruebas aprobada**: Enfoque ISTQB y ISO 25010 validado
- [ ] **Casos de uso completados**: Documentación de casos de uso finalizada
- [ ] **Datos de prueba identificados**: Requisitos de datos de prueba especificados
- [ ] **Herramientas de prueba seleccionadas**: Framework y herramientas aprobadas

##### Fase de Implementación de Pruebas
- [ ] **Código base estable**: Funcionalidad principal implementada y estable
- [ ] **Entorno de pruebas configurado**: Infraestructura de pruebas operativa
- [ ] **Framework de automatización preparado**: Herramientas de automatización configuradas
- [ ] **Datos de prueba preparados**: Conjuntos de datos de prueba disponibles

##### Fase de Ejecución de Pruebas
- [ ] **Casos de prueba implementados**: Todos los casos de prueba desarrollados
- [ ] **Revisiones de código completadas**: Código revisado y aprobado
- [ ] **Pruebas unitarias pasando**: Cobertura mínima de pruebas unitarias alcanzada
- [ ] **Integración continua funcionando**: Pipeline CI/CD operativo

#### Criterios de Salida
**Estándares de calidad requeridos para completar cada fase:**

##### Fase de Planificación de Pruebas
- [ ] **Estrategia de pruebas aprobada**: Documento de estrategia revisado y aceptado
- [ ] **Plan de pruebas detallado**: Cronograma y recursos asignados
- [ ] **Matriz de riesgos completada**: Riesgos identificados y mitigaciones definidas
- [ ] **Métricas de calidad definidas**: KPIs y umbrales establecidos

##### Fase de Diseño de Pruebas
- [ ] **Casos de prueba diseñados**: 100% cobertura de requisitos en casos de prueba
- [ ] **Marcos de automatización configurados**: Framework de automatización preparado
- [ ] **Datos de prueba preparados**: Conjuntos de datos de prueba generados
- [ ] **Revisión de diseño completada**: Diseño de pruebas revisado por pares

##### Fase de Implementación de Pruebas
- [ ] **Automatización de pruebas completada**: 90% de pruebas automatizadas
- [ ] **Entorno de pruebas validado**: Infraestructura probada y operativa
- [ ] **Integración CI/CD configurada**: Pipeline de pruebas continuas funcionando
- [ ] **Documentación de pruebas actualizada**: Documentación técnica completada

##### Fase de Ejecución de Pruebas
- [ ] **95% de pruebas pasando**: Tasa de éxito de pruebas dentro del umbral
- [ ] **Cobertura de código alcanzada**: 80% cobertura de líneas, 90% ramas críticas
- [ ] **Defectos críticos resueltos**: Cero defectos de severidad crítica/alta
- [ ] **Métricas de rendimiento validadas**: Todos los umbrales de rendimiento cumplidos

### Métricas de Calidad
**Indicadores medibles de logro de calidad:**

#### Métricas de Cobertura
- [ ] **Cobertura de Código**: 80% cobertura de líneas, 90% cobertura de ramas críticas
- [ ] **Cobertura Funcional**: 100% validación de criterios de aceptación
- [ ] **Cobertura de Riesgo**: 100% escenarios de alto riesgo probados
- [ ] **Cobertura de Características ISO 25010**: Validación para todas las características aplicables

#### Métricas de Defectos
- [ ] **Tasa de Defectos**: Menos de {X} defectos por 1000 líneas de código
- [ ] **Tiempo de Resolución**: Defectos críticos resueltos en 24 horas
- [ ] **Tasa de Escape de Defectos**: Menos del 5% de defectos encontrados en producción
- [ ] **Efectividad de Detección**: 95% de defectos encontrados antes de producción

#### Métricas de Rendimiento
- [ ] **Tiempo de Respuesta**: 95% de transacciones bajo {X}ms
- [ ] **Throughput**: Sistema capaz de manejar {X} transacciones por segundo
- [ ] **Utilización de Recursos**: CPU bajo 80%, memoria bajo 85%
- [ ] **Disponibilidad**: 99.9% de tiempo de actividad

#### Métricas de Seguridad
- [ ] **Vulnerabilidades Críticas**: Cero vulnerabilidades de severidad crítica
- [ ] **Pruebas de Penetración**: Aprobación de auditoría de seguridad
- [ ] **Autenticación**: 100% de endpoints protegidos validados
- [ ] **Autorización**: 100% de controles de acceso probados

#### Métricas de Usabilidad
- [ ] **Accesibilidad WCAG**: Nivel {AA/AAA} de conformidad
- [ ] **Tiempo de Tarea del Usuario**: Tareas principales completadas en {X} segundos
- [ ] **Tasa de Error del Usuario**: Menos del 5% de errores de usuario
- [ ] **Satisfacción del Usuario**: Puntuación de satisfacción mayor a {X}/10

### Procedimientos de Escalamiento
**Proceso para abordar fallas de calidad:**

#### Nivel 1: Fallas de Calidad Menores
1. **Detección**: Métrica fuera del rango objetivo pero dentro del umbral aceptable
2. **Acción**: Notificación al equipo de desarrollo, investigación requerida
3. **Timeframe**: Resolución dentro de 48 horas
4. **Responsable**: Lead de desarrollo del componente

#### Nivel 2: Fallas de Calidad Significativas
1. **Detección**: Métrica fuera del umbral aceptable o múltiples fallas menores
2. **Acción**: Reunión del equipo, plan de corrección requerido
3. **Timeframe**: Plan de corrección dentro de 24 horas, implementación dentro de 72 horas
4. **Responsable**: Tech Lead y QA Lead

#### Nivel 3: Fallas de Calidad Críticas
1. **Detección**: Bloqueo de lanzamiento o riesgo de seguridad/datos
2. **Acción**: Escalamiento inmediato a gestión, todos los recursos disponibles
3. **Timeframe**: Respuesta inmediata, resolución dentro de 24 horas
4. **Responsable**: Engineering Manager y Product Owner

#### Proceso de Escalamiento
```
Detección de Falla → Clasificación → Asignación → Resolución → Validación → Cierre
     ↓                    ↓             ↓           ↓           ↓          ↓
  Monitoreo         Nivel 1-3      Responsable   Plan de     Pruebas    Lecciones
  Automático        Según            Asignado     Acción      de          Aprendidas
                    Criterios                    Ejecutado   Validación
```

## Estándares de Calidad de Issues de GitHub

### Cumplimiento de Plantillas
- [ ] **Todos los issues de prueba siguen plantillas estandarizadas**:
  - Plantilla de Estrategia de Pruebas utilizada
  - Plantilla de Implementación de Pruebas Playwright utilizada
  - Plantilla de Garantía de Calidad utilizada

#### Campos Obligatorios para Issues de Prueba
- [ ] **Título**: Formato "Tipo de Prueba: {Componente/Característica}"
- [ ] **Descripción**: Alcance claro y objetivos de prueba
- [ ] **Criterios de Aceptación**: Criterios específicos y medibles
- [ ] **Técnica ISTQB**: Técnica de diseño de prueba especificada
- [ ] **Característica ISO 25010**: Característica de calidad objetivo
- [ ] **Estimación**: Puntos de historia o esfuerzo estimado
- [ ] **Dependencias**: Enlaces a issues dependientes
- [ ] **Etiquetas**: Etiquetas estandarizadas aplicadas

### Consistencia de Etiquetado
- [ ] **Etiquetas estandarizadas en todos los issues de trabajo de prueba**:

#### Etiquetas de Tipo de Prueba
- `unit-test`: Pruebas unitarias a nivel de componente
- `integration-test`: Pruebas de integración entre componentes
- `e2e-test`: Pruebas de extremo a extremo de flujos de usuario
- `performance-test`: Pruebas de rendimiento y carga
- `security-test`: Pruebas de seguridad y vulnerabilidades
- `accessibility-test`: Pruebas de accesibilidad y WCAG
- `regression-test`: Pruebas de regresión y validación de cambios

#### Etiquetas de Calidad
- `quality-gate`: Issue relacionado con puerta de calidad
- `iso25010`: Validación de característica ISO 25010
- `istqb-technique`: Aplicación de técnica ISTQB
- `risk-based`: Prueba basada en análisis de riesgo

#### Etiquetas de Prioridad
- `test-critical`: Prueba crítica para el lanzamiento
- `test-high`: Prueba de alta prioridad
- `test-medium`: Prueba de prioridad media
- `test-low`: Prueba de baja prioridad

#### Etiquetas de Componente
- `frontend-test`: Pruebas de interfaz de usuario
- `backend-test`: Pruebas de lógica de servidor
- `api-test`: Pruebas de API y servicios web
- `database-test`: Pruebas de base de datos y persistencia

### Asignación de Prioridad
- [ ] **Asignación de prioridad basada en riesgo usando criterios definidos**:

#### Criterios de Prioridad Crítica
- Funcionalidad que bloquea flujos de usuario principales
- Vulnerabilidades de seguridad de alta severidad
- Componentes con historial de defectos frecuentes
- Funcionalidad con impacto directo en ingresos

#### Criterios de Prioridad Alta
- Funcionalidad de usuario importante pero no crítica
- Componentes con dependencias externas complejas
- Características con requisitos de rendimiento estrictos
- Funcionalidad con impacto en experiencia de usuario

#### Criterios de Prioridad Media
- Funcionalidad de soporte y utilidades
- Componentes con riesgo moderado de defectos
- Características con requisitos de calidad estándar
- Funcionalidad con impacto limitado en usuarios

#### Criterios de Prioridad Baja
- Funcionalidad de conveniencia y mejoras menores
- Componentes estables con bajo riesgo
- Características de optimización y pulimiento
- Funcionalidad con impacto mínimo en usuarios

### Evaluación de Valor
- [ ] **Evaluación de valor comercial e impacto de calidad**:

#### Matriz de Valor Comercial
| Impacto en Usuario | Impacto en Negocio | Riesgo Técnico | Prioridad Final |
|-------------------|-------------------|----------------|-----------------|
| Alto | Alto | Alto | Crítica |
| Alto | Alto | Medio/Bajo | Alta |
| Alto | Medio | Alto | Alta |
| Medio | Alto | Alto | Alta |
| Otros Combinaciones | - | - | Media/Baja |

## Validación y Gestión de Dependencias

### Detección de Dependencias Circulares
- [ ] **Validación para prevenir relaciones de bloqueo**:

#### Proceso de Validación de Dependencias
1. **Mapeo de Dependencias**: Crear grafo de dependencias de todos los issues
2. **Análisis de Ciclos**: Ejecutar algoritmo de detección de ciclos
3. **Resolución de Conflictos**: Identificar y resolver dependencias circulares
4. **Validación Continua**: Revisar dependencias en cada actualización

#### Herramientas de Validación
- Análisis automático de dependencias en GitHub Projects
- Scripts de validación en pipeline CI/CD
- Revisión manual por Tech Lead en planificación de sprint

### Análisis de Ruta Crítica
- [ ] **Identificación de dependencias de pruebas en cronograma de entrega**:

#### Identificación de Ruta Crítica
- **Tareas sin Holgura**: Issues que no pueden retrasarse sin afectar entrega
- **Dependencias Largas**: Cadenas de dependencias que impactan cronograma
- **Recursos Limitados**: Tareas que requieren especialistas específicos
- **Validaciones Externas**: Dependencias de sistemas o equipos externos

#### Mitigación de Riesgos de Ruta Crítica
- **Paralelización**: Identificar oportunidades de trabajo paralelo
- **Recursos Adicionales**: Asignar recursos extra a tareas críticas
- **Dependencias Tempranas**: Resolver dependencias lo antes posible
- **Plan B**: Preparar alternativas para dependencias de alto riesgo

### Evaluación de Impacto
- [ ] **Análisis de impacto de retrasos de dependencias en validación de calidad**:

#### Análisis de Impacto de Retrasos
| Dependencia | Probabilidad de Retraso | Impacto en Cronograma | Impacto en Calidad | Plan de Mitigación |
|-------------|------------------------|----------------------|-------------------|-------------------|
| {Dependencia 1} | Alto/Medio/Bajo | {X} días | Alto/Medio/Bajo | {Plan específico} |
| {Dependencia 2} | Alto/Medio/Bajo | {X} días | Alto/Medio/Bajo | {Plan específico} |

### Estrategias de Mitigación
- [ ] **Enfoques alternativos para actividades de prueba bloqueadas**:

#### Estrategias de Mitigación por Tipo
- **Dependencias de Código**: Pruebas con mocks, stubs, simuladores
- **Dependencias de Datos**: Generación de datos sintéticos, sandbox
- **Dependencias de Entorno**: Entornos virtualizados, contenedores
- **Dependencias de Integración**: APIs simuladas, contratos de interfaz

## Precisión de Estimación y Revisión

### Análisis de Datos Históricos
- [ ] **Uso de datos de proyectos anteriores para precisión de estimación**:

#### Métricas Históricas de Referencia
- **Velocidad Promedio del Equipo**: {X} puntos de historia por sprint
- **Precisión de Estimación**: {X}% de estimaciones dentro de 20% del real
- **Factores de Complejidad**: Multiplicadores por tipo de componente
- **Overhead de Testing**: Porcentaje adicional para actividades de prueba

#### Base de Datos de Estimaciones
| Tipo de Tarea | Complejidad | Estimación Base | Factor de Ajuste | Estimación Final |
|---------------|-------------|-----------------|------------------|------------------|
| Prueba Unitaria | Baja | 0.5 SP | 1.0 | 0.5 SP |
| Prueba Unitaria | Media | 1.0 SP | 1.2 | 1.2 SP |
| Prueba Unitaria | Alta | 1.5 SP | 1.5 | 2.25 SP |
| Prueba E2E | Baja | 2.0 SP | 1.0 | 2.0 SP |
| Prueba E2E | Media | 3.0 SP | 1.3 | 3.9 SP |
| Prueba E2E | Alta | 5.0 SP | 1.8 | 9.0 SP |

### Revisión de Lead Técnico
- [ ] **Validación experta de estimaciones de complejidad de pruebas**:

#### Proceso de Revisión de Estimaciones
1. **Revisión Inicial**: Tech Lead revisa todas las estimaciones
2. **Calibración de Equipo**: Sesión de equipo para alinear entendimiento
3. **Ajustes Basados en Experiencia**: Modificaciones basadas en conocimiento histórico
4. **Aprobación Final**: Confirmación de estimaciones por stakeholders

#### Criterios de Revisión
- **Complejidad Técnica**: Evaluación de dificultad de implementación
- **Dependencias**: Impacto de dependencias en esfuerzo requerido
- **Riesgo de Unknowns**: Buffer adicional para incertidumbres
- **Capacidad del Equipo**: Ajuste basado en experiencia del equipo

### Asignación de Buffer de Riesgo
- [ ] **Tiempo adicional para tareas de alta incertidumbre**:

#### Factores de Buffer de Riesgo
- **Nuevas Tecnologías**: +25% para herramientas no utilizadas anteriormente
- **Dependencias Externas**: +20% para dependencias fuera del control del equipo
- **Requisitos Ambiguos**: +30% para requisitos no completamente definidos
- **Equipo Nuevo**: +15% para miembros de equipo sin experiencia en el dominio

#### Matriz de Buffer de Riesgo
| Factor de Riesgo | Impacto | Buffer Sugerido | Justificación |
|------------------|---------|-----------------|---------------|
| Complejidad Técnica Alta | Alto | +40% | Solución no probada anteriormente |
| Dependencias Críticas | Medio | +25% | Riesgo de bloqueo por dependencias |
| Requisitos Cambiantes | Alto | +35% | Historial de cambios de requisitos |
| Equipo Distribuido | Bajo | +10% | Overhead de comunicación |

### Refinamiento de Estimaciones
- [ ] **Mejora iterativa de precisión de estimación**:

#### Proceso de Refinamiento Continuo
1. **Medición de Precisión**: Comparar estimaciones vs. tiempo real cada sprint
2. **Análisis de Variaciones**: Identificar patrones en diferencias de estimación
3. **Ajuste de Factores**: Modificar multiplicadores basado en datos reales
4. **Entrenamiento de Equipo**: Sesiones de calibración de estimación regulares

#### Métricas de Mejora de Estimación
- **Precisión de Sprint**: Porcentaje de estimaciones dentro de 15% del real
- **Tendencia de Mejora**: Mejora de precisión a lo largo del tiempo
- **Variabilidad de Estimador**: Consistencia entre diferentes estimadores
- **Factores de Corrección**: Ajustes aplicados basados en aprendizaje

## Criterios de Éxito del Plan de QA

### Criterios de Finalización
- [ ] **Todas las puertas de calidad definidas e implementadas**
- [ ] **Métricas de calidad establecidas con umbrales claros**
- [ ] **Procedimientos de escalamiento documentados y comunicados**
- [ ] **Estándares de issues de GitHub implementados y seguidos**
- [ ] **Sistema de gestión de dependencias operativo**
- [ ] **Proceso de estimación calibrado y validado**

### Indicadores de Éxito
- [ ] **100% cumplimiento de puertas de calidad**
- [ ] **95% precisión en estimaciones de prueba**
- [ ] **Cero dependencias circulares en plan final**
- [ ] **100% issues siguiendo estándares de plantilla**
- [ ] **Tiempo de resolución de problemas de calidad dentro de SLA**
- [ ] **Satisfacción del equipo con proceso de QA > 8/10**