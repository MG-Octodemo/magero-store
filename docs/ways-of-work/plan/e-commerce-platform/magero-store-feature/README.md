# Magero Store - Test Planning Documentation

Este directorio contiene la documentación completa de planificación de pruebas y aseguramiento de calidad para la plataforma e-commerce Magero Store, basada en los marcos ISTQB e ISO 25010.

## Contenido

### 📋 Documentos de Planificación

1. **[test-strategy.md](./test-strategy.md)** - Estrategia Integral de Testing
   - Enfoque de testing basado en ISTQB
   - Evaluación de características de calidad ISO 25010
   - Estrategia de ambiente y datos de prueba
   - Quality gates y criterios de éxito

2. **[test-issues-checklist.md](./test-issues-checklist.md)** - Checklist de Issues de Testing
   - Desglose completo de issues de testing
   - Priorización y estimaciones
   - Documentación de dependencias
   - Objetivos de cobertura de pruebas

3. **[qa-plan.md](./qa-plan.md)** - Plan de Aseguramiento de Calidad
   - Quality gates y checkpoints
   - Estándares para GitHub issues
   - Sistema de etiquetado y priorización
   - Gestión de dependencias y riesgos
   - Precisión de estimaciones

## 🎯 Frameworks Aplicados

### ISTQB (International Software Testing Qualifications Board)

Este proyecto aplica los siguientes conceptos y técnicas ISTQB:

- **Técnicas de Diseño de Pruebas:**
  - Equivalence Partitioning (Particionamiento de Equivalencia)
  - Boundary Value Analysis (Análisis de Valores Límite)
  - Decision Table Testing (Pruebas de Tabla de Decisión)
  - State Transition Testing (Pruebas de Transición de Estados)
  - Experience-Based Testing (Pruebas Basadas en Experiencia)

- **Tipos de Pruebas:**
  - Functional Testing (Pruebas Funcionales)
  - Non-Functional Testing (Pruebas No Funcionales)
  - Structural Testing (Pruebas Estructurales)
  - Change-Related Testing (Pruebas Relacionadas con Cambios)

### ISO 25010 - Modelo de Calidad de Software

Características de calidad evaluadas y validadas:

1. **Functional Suitability** (Idoneidad Funcional)
   - Completeness, Correctness, Appropriateness

2. **Performance Efficiency** (Eficiencia de Desempeño)
   - Time Behavior, Resource Utilization, Capacity

3. **Compatibility** (Compatibilidad)
   - Co-existence, Interoperability

4. **Usability** (Usabilidad)
   - User Interface Aesthetics, Accessibility, Learnability, Operability

5. **Reliability** (Confiabilidad)
   - Fault Tolerance, Recoverability, Availability

6. **Security** (Seguridad)
   - Confidentiality, Integrity, Authentication, Authorization

7. **Maintainability** (Mantenibilidad)
   - Modularity, Reusability, Testability

8. **Portability** (Portabilidad)
   - Adaptability, Installability, Replaceability

## 🛠️ Herramientas de Testing

### Unit & Integration Testing
- **xUnit**: Framework de pruebas unitarias para .NET
- **Coverlet**: Herramienta de cobertura de código
- **ReportGenerator**: Generación de reportes de cobertura

### End-to-End Testing
- **Playwright**: Framework E2E para testing cross-browser
- **axe-core**: Testing de accesibilidad (WCAG compliance)

### Performance Testing
- **k6**: Herramienta de load testing
- **Lighthouse**: Auditoría de performance y calidad web
- **Apache JMeter**: Alternative para load testing

### Security Testing
- **OWASP ZAP**: Security scanning
- **Snyk**: Escaneo de vulnerabilidades en dependencias
- **GitHub Security Advisories**: Alertas de seguridad

### Code Quality
- **SonarCloud**: Análisis estático de código
- **Dependabot**: Actualización automática de dependencias

## 📊 Métricas de Calidad

### Objetivos de Cobertura
- **Code Coverage**: ≥ 80% líneas, ≥ 90% ramas (rutas críticas)
- **Functional Coverage**: 100% acceptance criteria
- **Risk Coverage**: 100% escenarios de alto riesgo

### Quality Gates
- **Test Pass Rate**: ≥ 95%
- **Defectos Críticos**: 0 en producción
- **Performance**: Page load < 2 segundos (p90)
- **Security**: 0 vulnerabilidades críticas
- **Accessibility**: WCAG 2.1 Level AA compliance

## 📝 GitHub Issue Templates

Templates disponibles en `.github/ISSUE_TEMPLATE/`:

1. **[test-strategy.md](../../../../../.github/ISSUE_TEMPLATE/test-strategy.md)**
   - Para definir estrategia de testing de features/epics
   - Incluye aplicación de ISTQB e ISO 25010
   - Define quality gates y métricas

2. **[playwright-test.md](../../../../../.github/ISSUE_TEMPLATE/playwright-test.md)**
   - Para implementación de pruebas E2E con Playwright
   - Incluye test cases funcionales y no funcionales
   - Cross-browser y responsive testing

3. **[quality-assurance.md](../../../../../.github/ISSUE_TEMPLATE/quality-assurance.md)**
   - Para validación integral de calidad
   - Evaluación completa ISO 25010
   - Quality gates y métricas de calidad

## 🏷️ Sistema de Etiquetado

### Test Type Labels
- `unit-test`, `integration-test`, `e2e-test`
- `performance-test`, `security-test`, `accessibility-test`
- `regression-test`, `smoke-test`

### Quality Labels
- `quality-gate`, `iso25010`, `istqb-technique`
- `risk-based`, `quality-validation`, `test-strategy`

### Priority Labels
- `test-critical`, `test-high`, `test-medium`, `test-low`

### Component Labels
- `frontend-test`, `backend-test`, `api-test`, `database-test`
- `models`, `controllers`, `helpers`, `views`

### Status Labels
- `test-blocked`, `test-in-progress`, `test-review`
- `test-approved`, `test-failed`, `test-flaky`

## 🔄 Proceso de Testing

### 1. Planning Phase
- Revisar test strategy
- Identificar test cases
- Estimar esfuerzo
- Crear issues de testing

### 2. Implementation Phase
- Configurar test framework
- Implementar unit tests
- Implementar integration tests
- Implementar E2E tests
- Configurar CI/CD

### 3. Execution Phase
- Ejecutar test suites
- Validar quality gates
- Reportar defectos
- Retest fixes

### 4. Reporting Phase
- Generar reportes de testing
- Documentar métricas de calidad
- QA sign-off
- Lessons learned

## 📈 Estimaciones

### Story Points por Tipo de Test

| Tipo de Test | Estimación | Duración Típica |
|--------------|------------|-----------------|
| Unit Test (simple) | 0.5 puntos | 1-2 horas |
| Unit Test (estándar) | 1 punto | 4 horas |
| Integration Test | 1-2 puntos | 4-8 horas |
| E2E Test (simple) | 2 puntos | 1 día |
| E2E Test (complejo) | 3 puntos | 1.5 días |
| Performance Test | 3-5 puntos | 2-3 días |
| Security Test | 2-4 puntos | 1-2 días |

### Esfuerzo Total Estimado
- **Total Story Points**: ~60 puntos
- **Timeline**: 3-4 sprints (6-8 semanas)
- **Team Size**: 2-3 QA Engineers

## 🚀 Getting Started

### Para crear nuevos test issues:

1. **Revisa la documentación:**
   - Lee [test-strategy.md](./test-strategy.md) para entender el enfoque
   - Consulta [test-issues-checklist.md](./test-issues-checklist.md) para ver issues planificados
   - Revisa [qa-plan.md](./qa-plan.md) para estándares de calidad

2. **Usa los templates:**
   - Ve a GitHub Issues → New Issue
   - Selecciona el template apropiado
   - Completa todos los campos requeridos

3. **Aplica labels correctos:**
   - Test type (e.g., `e2e-test`)
   - Priority (e.g., `test-critical`)
   - Component (e.g., `frontend-test`)
   - Quality (e.g., `iso25010`)

4. **Documenta dependencias:**
   - Identifica issues bloqueantes
   - Enlaza issues relacionados
   - Actualiza dependency chain

### Para implementar tests:

1. **Setup:**
   ```bash
   # Instalar dependencias
   dotnet restore
   
   # Instalar Playwright (para E2E tests)
   npm install -D @playwright/test
   npx playwright install
   ```

2. **Run Tests:**
   ```bash
   # Unit tests
   dotnet test
   
   # E2E tests
   npx playwright test
   
   # Code coverage
   dotnet test /p:CollectCoverage=true
   ```

3. **View Reports:**
   ```bash
   # Coverage report
   reportgenerator -reports:coverage.cobertura.xml -targetdir:coverage
   
   # Playwright report
   npx playwright show-report
   ```

## 📚 Referencias

### ISTQB Resources
- [ISTQB Official Website](https://www.istqb.org/)
- [ISTQB Glossary](https://glossary.istqb.org/)
- [Test Design Techniques](https://istqb-glossary.page/test-design-techniques/)

### ISO 25010 Resources
- [ISO/IEC 25010:2011](https://www.iso.org/standard/35733.html)
- [ISO 25010 Quality Model Overview](https://iso25000.com/index.php/en/iso-25000-standards/iso-25010)

### Testing Tools Documentation
- [xUnit Documentation](https://xunit.net/)
- [Playwright Documentation](https://playwright.dev/)
- [k6 Documentation](https://k6.io/docs/)
- [OWASP ZAP User Guide](https://www.zaproxy.org/docs/)

### Accessibility Standards
- [WCAG 2.1 Guidelines](https://www.w3.org/WAI/WCAG21/quickref/)
- [axe-core Documentation](https://github.com/dequelabs/axe-core)

## 🤝 Contribución

Para contribuir a la mejora de este framework de testing:

1. Revisa la documentación existente
2. Propone mejoras via GitHub Issues
3. Sigue los estándares establecidos en [qa-plan.md](./qa-plan.md)
4. Participa en retrospectivas de testing
5. Comparte lessons learned

## 📞 Contacto

Para preguntas sobre el framework de testing:
- **QA Lead**: [Nombre]
- **Tech Lead**: [Nombre]
- **Engineering Manager**: [Nombre]

## 📝 Changelog

### Version 1.0 (2024)
- ✅ Estrategia de testing inicial
- ✅ Templates de GitHub Issues
- ✅ Plan de QA
- ✅ Checklist de test issues
- ✅ Documentación de frameworks (ISTQB, ISO 25010)

---

**Última actualización:** 2024  
**Versión:** 1.0  
**Mantenido por:** QA Team
