---
name: Unit Test Issue
about: Pruebas unitarias para componentes individuales
title: '[UNIT-TEST] '
labels: unit-test, testing
assignees: ''
---

# Unit Tests: {Nombre del Componente}

## Alcance de Pruebas Unitarias
{Descripción del componente o módulo siendo probado}

## Técnica de Diseño ISTQB
**Técnica Aplicada**: {Particionamiento de Equivalencia/Análisis de Valores Límite/Tabla de Decisión}
**Tipo de Prueba**: Funcional/Estructural

## Casos de Prueba a Implementar

### Escenarios Positivos (Happy Path):
- [ ] {Caso de prueba 1}
- [ ] {Caso de prueba 2}

### Escenarios Negativos:
- [ ] {Caso de prueba 1}
- [ ] {Caso de prueba 2}

### Valores Límite:
- [ ] {Caso de prueba 1}
- [ ] {Caso de prueba 2}

### Casos de Error:
- [ ] {Caso de prueba 1}
- [ ] {Caso de prueba 2}

## Configuración de Pruebas

### Dependencias Mock/Stub:
- {Dependencia 1 a mockear}
- {Dependencia 2 a mockear}

### Datos de Prueba:
```csharp
// Ejemplo de datos de prueba
{ejemplo de datos}
```

### Fixtures Requeridos:
- {Fixture 1}
- {Fixture 2}

## Criterios de Aceptación
- [ ] Todos los casos de prueba implementados
- [ ] Todas las pruebas pasando
- [ ] Cobertura del componente ≥ 90%
- [ ] No warnings de compilación
- [ ] Code review de tests aprobado
- [ ] Tests ejecutándose en CI/CD

## Métricas de Cobertura Objetivo

- **Cobertura de Líneas**: {porcentaje}%
- **Cobertura de Ramas**: {porcentaje}%
- **Cobertura de Métodos**: {porcentaje}%

## Dependencias
- {Issue bloqueante, ej: Setup de xUnit}

---

**Estimación**: {0.5-2 story points}
**Prioridad**: {critical/high/medium/low}
**Componente**: {Controller/Model/Service/Helper}
