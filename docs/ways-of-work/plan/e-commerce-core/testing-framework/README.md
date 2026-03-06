# Framework de Testing y Aseguramiento de Calidad - magero-store

## Índice de Documentación

Este directorio contiene la documentación completa del framework de testing y aseguramiento de calidad para el proyecto magero-store, basado en estándares ISTQB e ISO 25010.

### Documentos Principales

1. **[test-strategy.md](./test-strategy.md)** - Estrategia de Pruebas
   - Visión general de la estrategia de testing
   - Aplicación del framework ISTQB
   - Evaluación de características de calidad ISO 25010
   - Estrategia de entorno y datos de prueba
   - Integración CI/CD
   - Métricas de éxito

2. **[test-issues-checklist.md](./test-issues-checklist.md)** - Lista de Verificación de Issues de Pruebas
   - Checklist completo de issues de testing por nivel
   - Desglose de pruebas unitarias por componente
   - Pruebas de integración identificadas
   - Pruebas E2E con Playwright
   - Pruebas de seguridad (OWASP)
   - Pruebas de accesibilidad (WCAG)
   - Pruebas de performance y carga
   - Orden de implementación recomendado y dependencias

3. **[qa-plan.md](./qa-plan.md)** - Plan de Aseguramiento de Calidad
   - Puertas de calidad (Quality Gates) en múltiples niveles
   - Estándares para GitHub Issues
   - Sistema de etiquetado y priorización
   - Gestión de dependencias y ruta crítica
   - Estimaciones y revisión de precisión
   - Métricas y KPIs de calidad
   - Gestión de defectos
   - Plan de capacitación

### GitHub Issue Templates

Los templates de GitHub Issues están ubicados en `/.github/ISSUE_TEMPLATE/`:

- **test-strategy.md** - Template para issues de estrategia de pruebas
- **unit-test.md** - Template para issues de pruebas unitarias
- **integration-test.md** - Template para issues de pruebas de integración
- **playwright-test.md** - Template para issues de pruebas E2E con Playwright
- **security-test.md** - Template para issues de pruebas de seguridad
- **accessibility-test.md** - Template para issues de pruebas de accesibilidad
- **quality-assurance.md** - Template para issues de plan de QA

## Resumen Ejecutivo

### Objetivos de Calidad

| Objetivo | Métrica | Target |
|----------|---------|--------|
| Cobertura de Pruebas | Code Coverage | 80% líneas, 90% rutas críticas |
| Automatización | Test Automation Rate | ≥ 90% |
| Detección de Defectos | Pre-production Detection | ≥ 95% |
| Rendimiento | Response Time p95 | < 500ms |
| Seguridad | Critical Vulnerabilities | 0 |
| Accesibilidad | WCAG Compliance | Level AA |

### Framework de Estándares

**ISTQB (International Software Testing Qualifications Board)**
- Técnicas de diseño de pruebas aplicadas
- Tipos de prueba: Funcional, No Funcional, Estructural, Relacionadas con Cambios
- Niveles de prueba: Unitarias, Integración, Sistema, Aceptación

**ISO 25010 (Software Quality Model)**
- 8 características de calidad evaluadas
- Functional Suitability, Performance Efficiency, Usability
- Security, Reliability, Maintainability, Compatibility, Portability

### Tipos de Prueba Implementados

1. **Pruebas Unitarias (xUnit)**
   - Controllers, Models, Helpers
   - Cobertura objetivo: 80%+
   - Ejecución: Por cada commit

2. **Pruebas de Integración**
   - Controller + Database
   - Controller + Session
   - Flujos completos de subsistemas
   - Ejecución: Por cada PR

3. **Pruebas E2E (Playwright)**
   - Flujos de usuario completos
   - Cross-browser testing
   - Responsive testing
   - Ejecución: Por merge a main

4. **Pruebas de Performance**
   - Load testing (k6)
   - Response time testing
   - Capacity testing
   - Ejecución: Pre-release

5. **Pruebas de Seguridad**
   - OWASP Top 10 validation
   - SQL injection testing (CRÍTICO)
   - XSS, CSRF testing
   - Dependency scanning
   - Ejecución: Por cada PR + nightly

6. **Pruebas de Accesibilidad**
   - WCAG 2.1 Level AA compliance
   - Keyboard navigation
   - Screen reader testing
   - Color contrast validation
   - Ejecución: Por feature + pre-release

7. **Pruebas de Regresión**
   - Suite completa automatizada
   - Visual regression testing
   - Ejecución: Por cada merge + nightly

### Puertas de Calidad (Quality Gates)

El proyecto implementa 5 niveles de puertas de calidad:

1. **Commit Level** (< 5 min)
   - Build exitoso
   - Unit tests pasando
   - Static analysis

2. **Pull Request Level** (< 30 min)
   - Suite completa de tests
   - Code coverage ≥ 80%
   - Security scanning
   - Code review aprobado

3. **Integration Level** (< 15 min)
   - Integration tests
   - E2E smoke tests
   - Performance benchmarks

4. **Pre-Release Level** (2-3 días)
   - Regression completa
   - Full E2E suite
   - Security audit
   - UAT sign-off

5. **Production Deployment** (tiempo real)
   - Health checks
   - Smoke tests en producción
   - Performance monitoring

### Herramientas de Testing

| Categoría | Herramienta | Propósito |
|-----------|-------------|-----------|
| Unit Testing | xUnit | Framework de pruebas .NET |
| Mocking | Moq | Mock objects |
| E2E Testing | Playwright | Pruebas de UI automatizadas |
| API Testing | REST Client | Pruebas de endpoints |
| Load Testing | k6 | Performance y carga |
| Security Testing | OWASP ZAP, CodeQL | Vulnerability scanning |
| Accessibility | axe-core | WCAG compliance |
| Code Coverage | coverlet | Medición de cobertura |
| CI/CD | GitHub Actions | Automation pipeline |

### Cronograma de Implementación

**Sprint 1: Fundamentos** (13 SP)
- Setup de frameworks (xUnit, Playwright)
- Pruebas unitarias iniciales
- CI/CD pipeline básico
- Seguridad crítica (SQL injection)

**Sprint 2: Controllers e Integración** (15 SP)
- Unit tests completos de controllers
- Integration tests
- E2E tests iniciales

**Sprint 3: E2E y Non-Functional** (16 SP)
- Suite completa E2E
- Performance testing
- Cross-browser testing

**Sprint 4: Seguridad y Accesibilidad** (15 SP)
- Security testing completo
- WCAG compliance
- Regression suite

**Sprint 5: Optimización** (12 SP)
- Mobile testing
- Advanced performance
- Refinamiento de suite

### Métricas de Seguimiento

**Dashboards Principales:**
1. **Code Coverage Dashboard**
   - Cobertura por componente
   - Trend histórico
   - Gap analysis

2. **Quality Metrics Dashboard**
   - Defect density
   - Test pass rate
   - Build success rate

3. **CI/CD Pipeline Dashboard**
   - Pipeline duration
   - Quality gate pass rate
   - Deployment frequency

4. **Security Dashboard**
   - Vulnerability count por severidad
   - Security test results
   - Dependency vulnerabilities

### Riesgos Críticos Identificados

| Riesgo | Severidad | Mitigación |
|--------|-----------|------------|
| SQL Injection en búsqueda | CRÍTICO | Pruebas exhaustivas, código review, parameterized queries |
| Pérdida de datos del carrito | ALTO | Pruebas de sesión, backup strategy |
| Performance con catálogo grande | MEDIO | Load testing, optimización de queries |
| Vulnerabilidades de dependencias | ALTO | Escaneo continuo, actualizaciones regulares |

## Uso de Esta Documentación

### Para QA Engineers
1. Revisar **test-strategy.md** para entender el enfoque general
2. Usar **test-issues-checklist.md** para identificar trabajo pendiente
3. Seguir **qa-plan.md** para procesos y estándares
4. Usar templates de issues para crear trabajo de testing

### Para Developers
1. Revisar criterios de puertas de calidad en **qa-plan.md**
2. Entender requisitos de coverage en **test-strategy.md**
3. Usar templates para crear issues de testing
4. Consultar checklist para validar completitud

### Para Product Owners
1. Revisar objetivos de calidad y métricas de éxito
2. Entender quality gates para planning
3. Review de riesgos y estrategias de mitigación
4. UAT requirements y sign-off criteria

### Para Tech Leads
1. Revisar arquitectura de testing en **test-strategy.md**
2. Validar estimaciones y dependencias técnicas
3. Code review de estrategias de testing
4. Mentoring de equipo en best practices

## Proceso de Creación de Issues de Testing

### 1. Seleccionar Template Apropiado
Elegir el template correcto según el tipo de prueba:
- Unit Test
- Integration Test
- Playwright E2E
- Security Test
- Accessibility Test
- Quality Assurance Plan

### 2. Completar Campos Requeridos
- Title descriptivo
- Descripción completa del alcance
- Técnica ISTQB aplicada
- Casos de prueba específicos
- Criterios de aceptación
- Estimación
- Labels apropiados
- Prioridad

### 3. Identificar Dependencias
- Issues bloqueantes
- Componentes requeridos
- Setup necesario

### 4. Validación de Template
- Verificar completitud
- QA Lead review
- Tech Lead review de estimación

### 5. Sprint Planning
- Priorizar basado en riesgo
- Considerar dependencias
- Asignar a equipo

## Contactos y Responsabilidades

| Rol | Responsabilidad | Contacto |
|-----|----------------|----------|
| QA Lead | Estrategia de testing, mentoring | TBD |
| Tech Lead | Arquitectura de tests, code review | TBD |
| DevOps | CI/CD pipeline, infraestructura | TBD |
| Security Lead | Security testing, vulnerabilities | TBD |

## Referencias Externas

### Estándares
- [ISTQB Syllabus](https://www.istqb.org/)
- [ISO 25010 Quality Model](https://iso25000.com/index.php/en/iso-25000-standards/iso-25010)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [WCAG 2.1 Guidelines](https://www.w3.org/WAI/WCAG21/quickref/)

### Herramientas
- [xUnit Documentation](https://xunit.net/)
- [Playwright Documentation](https://playwright.dev/)
- [Moq Quickstart](https://github.com/moq/moq4)
- [k6 Documentation](https://k6.io/docs/)
- [OWASP ZAP User Guide](https://www.zaproxy.org/docs/)
- [axe-core Documentation](https://github.com/dequelabs/axe-core)

### Best Practices
- [Microsoft .NET Testing Best Practices](https://docs.microsoft.com/en-us/dotnet/core/testing/)
- [Testing Library Best Practices](https://kentcdodds.com/blog/common-mistakes-with-react-testing-library)
- [Playwright Best Practices](https://playwright.dev/docs/best-practices)

## Historial de Versiones

| Versión | Fecha | Cambios | Autor |
|---------|-------|---------|-------|
| 1.0 | 2024 | Creación inicial del framework de testing | GitHub Copilot Agent |

## Próximos Pasos

1. ✅ Documentación de estrategia completada
2. ⬜ Setup de xUnit test project
3. ⬜ Configuración de Playwright
4. ⬜ Implementación de CI/CD pipeline
5. ⬜ Primeras pruebas unitarias
6. ⬜ Primera suite E2E
7. ⬜ Security testing crítico
8. ⬜ Regression suite

---

**Última Actualización**: 2024
**Mantenido por**: QA Team
**Estado**: ✅ Documentación completa, lista para implementación
