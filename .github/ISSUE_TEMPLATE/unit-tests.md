---
name: Pruebas Unitarias
about: Plantilla para implementación de pruebas unitarias con xUnit.net
title: 'Pruebas Unitarias: [Nombre del Componente]'
labels: ['unit-test', 'xunit', 'istqb-technique']
assignees: ''
---

# Pruebas Unitarias: {Nombre del Componente}

## Alcance del Componente

{Componente específico o clase siendo probada}

## Técnica ISTQB Aplicada

**Técnica de Diseño**: {Partición de Equivalencia/Análisis de Valores Límite/Tabla de Decisión}
**Justificación**: {Por qué esta técnica es apropiada para este componente}

## Casos de Prueba a Implementar

### Pruebas de Funcionalidad Principal
- [ ] Escenarios de entrada válida
- [ ] Escenarios de entrada inválida
- [ ] Casos límite y extremos
- [ ] Comportamiento por defecto

### Pruebas de Manejo de Errores
- [ ] Excepciones esperadas lanzadas correctamente
- [ ] Validación de parámetros nulos
- [ ] Validación de parámetros fuera de rango
- [ ] Manejo de estados inválidos

### Pruebas de Lógica de Negocio
- [ ] Cálculos y transformaciones correctas
- [ ] Reglas de negocio aplicadas apropiadamente
- [ ] Validaciones de datos implementadas
- [ ] Estados de objeto mantenidos correctamente

## Configuración de Pruebas

### Framework y Herramientas
- [ ] xUnit.net configurado
- [ ] Moq para mocking configurado
- [ ] FluentAssertions para aserciones claras
- [ ] AutoFixture para generación de datos de prueba

### Estructura de Pruebas
- [ ] Patrón Arrange-Act-Assert seguido
- [ ] Nombres de pruebas descriptivos
- [ ] Métodos de setup y cleanup implementados
- [ ] Categorización de pruebas aplicada

## Cobertura de Código

**Objetivos de Cobertura:**
- [ ] Cobertura de líneas: ≥ 85%
- [ ] Cobertura de ramas: ≥ 90%
- [ ] Cobertura de métodos: 100%

**Exclusiones Justificadas:**
- [ ] Código generado automáticamente
- [ ] Constructores simples
- [ ] Propiedades auto-implementadas

## Mocking y Dependencias

**Dependencias a Mockear:**
- [ ] Servicios externos
- [ ] Repositorios de datos
- [ ] Configuraciones
- [ ] Loggers

**Estrategia de Mocking:**
- [ ] Interfaces mockeadas, no implementaciones concretas
- [ ] Comportamiento esperado configurado
- [ ] Verificación de interacciones implementada

## Datos de Prueba

**Generación de Datos:**
- [ ] Datos válidos representativos
- [ ] Datos límite y extremos
- [ ] Datos inválidos para pruebas negativas
- [ ] Objetos complejos con AutoFixture

## Criterios de Aceptación

- [ ] Todas las pruebas unitarias pasan
- [ ] Objetivos de cobertura alcanzados
- [ ] Sin advertencias de análisis estático
- [ ] Tiempo de ejecución < 5 segundos para suite completa
- [ ] Pruebas son determinísticas (no flaky)

## Validación de Calidad

### Características ISO 25010 Validadas
- [ ] **Idoneidad Funcional**: Corrección de lógica implementada
- [ ] **Fiabilidad**: Manejo robusto de errores
- [ ] **Mantenibilidad**: Código fácil de probar y modificar

### Técnicas ISTQB Aplicadas
- [ ] **Partición de Equivalencia**: Clases de entrada identificadas y probadas
- [ ] **Análisis de Valores Límite**: Valores límite probados sistemáticamente
- [ ] **Tabla de Decisión**: Combinaciones de condiciones probadas

## Estimación

{Esfuerzo de desarrollo: 1-2 puntos de historia}

## Dependencias

- [ ] Código del componente completado
- [ ] Framework de pruebas configurado
- [ ] Interfaces para mocking disponibles
- [ ] Documentación de requisitos clara

## Tareas de Implementación

- [ ] Configurar proyecto de pruebas
- [ ] Implementar casos de prueba positivos
- [ ] Implementar casos de prueba negativos
- [ ] Configurar mocks y dependencias
- [ ] Validar cobertura de código
- [ ] Integrar con CI/CD pipeline
- [ ] Documentar casos de prueba especiales

## Definición de Completado

- [ ] Todas las pruebas implementadas y pasando
- [ ] Cobertura de código dentro de objetivos
- [ ] Revisión de código completada
- [ ] Pruebas ejecutándose en CI/CD
- [ ] Documentación actualizada