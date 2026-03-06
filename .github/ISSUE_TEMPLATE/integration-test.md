---
name: Integration Test Issue
about: Pruebas de integración entre componentes
title: '[INTEGRATION-TEST] '
labels: integration-test, testing
assignees: ''
---

# Integration Tests: {Nombre de la Integración}

## Alcance de Integración
{Descripción de los componentes que se están integrando y validando}

## Componentes Integrados
- **Componente A**: {Nombre y descripción}
- **Componente B**: {Nombre y descripción}
- **Componente C**: {Nombre y descripción (si aplica)}

## Técnica de Diseño ISTQB
**Enfoque de Integración**: {Big-bang/Incremental/Top-down/Bottom-up}
**Técnica de Prueba**: {Técnica aplicada}

## Casos de Prueba de Integración

### Flujos de Integración Principales:
- [ ] {Flujo de integración 1}
- [ ] {Flujo de integración 2}
- [ ] {Flujo de integración 3}

### Validación de Interfaces:
- [ ] Validar contratos de API/interfaces
- [ ] Validar formatos de datos
- [ ] Validar manejo de errores en integración

### Transacciones y Persistencia:
- [ ] {Caso de prueba de transacción 1}
- [ ] {Caso de prueba de persistencia 1}

### Manejo de Errores:
- [ ] Fallo de componente A
- [ ] Fallo de componente B
- [ ] Timeout de comunicación
- [ ] Datos inválidos entre componentes

## Configuración de Entorno

### Base de Datos:
- Tipo: {In-memory/Test DB/Docker container}
- Setup: {Descripción de configuración}
- Cleanup: {Estrategia de limpieza}

### Servicios Externos:
- {Servicio 1}: {Mock/Stub/Real}
- {Servicio 2}: {Mock/Stub/Real}

### Datos de Prueba:
```csharp
// Ejemplo de setup de datos
{ejemplo de configuración}
```

## Criterios de Aceptación
- [ ] Todos los flujos de integración validados
- [ ] Manejo de errores verificado
- [ ] Transacciones funcionando correctamente
- [ ] Rollback de transacciones validado (si aplica)
- [ ] Performance de integración dentro de SLA
- [ ] Tests pasando en CI/CD

## Métricas de Calidad
- **Cobertura de Interfaces**: 100%
- **Tasa de Éxito**: ≥ 95%
- **Tiempo de Ejecución**: < {valor} segundos

## Dependencias
- [ ] {Unit tests de componente A}
- [ ] {Unit tests de componente B}
- [ ] {Configuración de entorno de pruebas}

---

**Estimación**: {1-3 story points}
**Prioridad**: {critical/high/medium/low}
**Componentes**: {Lista de componentes}
