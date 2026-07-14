---
name: Security Test Issue
about: Pruebas de seguridad y validación de vulnerabilidades
title: '[SECURITY-TEST] '
labels: security-test, owasp, critical
assignees: ''
---

# Security Tests: {Nombre del Componente/Feature}

## Alcance de Pruebas de Seguridad
{Descripción de los aspectos de seguridad siendo validados}

## Categoría OWASP
**OWASP Top 10**: {Categoría específica, ej: A03:2021 - Injection}
**Severidad Potencial**: {Crítico/Alto/Medio/Bajo}

## Vectores de Ataque a Validar

### Injection Attacks:
- [ ] SQL Injection
- [ ] NoSQL Injection
- [ ] Command Injection
- [ ] LDAP Injection

### Authentication & Authorization:
- [ ] Broken Authentication
- [ ] Session Management
- [ ] Authorization Bypass
- [ ] Privilege Escalation

### Cross-Site Attacks:
- [ ] Cross-Site Scripting (XSS)
  - [ ] Stored XSS
  - [ ] Reflected XSS
  - [ ] DOM-based XSS
- [ ] Cross-Site Request Forgery (CSRF)

### Data Exposure:
- [ ] Sensitive Data Exposure
- [ ] Insecure Direct Object References
- [ ] Information Disclosure in Errors

### Security Misconfiguration:
- [ ] Default Credentials
- [ ] Unnecessary Features Enabled
- [ ] Error Messages Verbose
- [ ] HTTPS Configuration

### Other Vulnerabilities:
- [ ] {Vulnerabilidad específica 1}
- [ ] {Vulnerabilidad específica 2}

## Casos de Prueba de Seguridad

### Pruebas Automatizadas:
```
Test Case: {Nombre}
Input: {Payload de ataque}
Expected: {Comportamiento esperado - bloqueo, sanitización, etc}
```

### Pruebas Manuales:
- [ ] {Escenario de ataque manual 1}
- [ ] {Escenario de ataque manual 2}

## Herramientas de Testing

- [ ] **OWASP ZAP**: Escaneo automatizado
- [ ] **Burp Suite**: Pruebas manuales
- [ ] **sqlmap**: SQL injection testing
- [ ] **Custom Scripts**: {Descripción}
- [ ] **Code Analysis**: Static analysis tools

## Datos de Prueba (Payloads)

### SQL Injection Payloads:
```sql
' OR '1'='1
'; DROP TABLE users; --
' UNION SELECT null, null, null --
```

### XSS Payloads:
```html
<script>alert('XSS')</script>
<img src=x onerror="alert('XSS')">
```

### CSRF Payloads:
{Descripción de técnicas CSRF a probar}

## Criterios de Aceptación
- [ ] Todas las vulnerabilidades identificadas están mitigadas
- [ ] Escaneo automatizado sin críticos/altos
- [ ] Validación manual de controles de seguridad
- [ ] Input validation implementada
- [ ] Output encoding aplicado
- [ ] Security headers configurados
- [ ] Logging de intentos de ataque habilitado

## Controles de Seguridad Validados

| Control | Implementado | Validado |
|---------|--------------|----------|
| Input Validation | ☐ | ☐ |
| Output Encoding | ☐ | ☐ |
| Parameterized Queries | ☐ | ☐ |
| CSRF Tokens | ☐ | ☐ |
| Security Headers | ☐ | ☐ |
| Error Handling | ☐ | ☐ |
| Logging & Monitoring | ☐ | ☐ |

## Impacto y Remediación

### Impacto si Explotado:
- {Descripción del impacto potencial}

### Plan de Remediación:
- {Paso 1}
- {Paso 2}
- {Paso 3}

## Referencias
- OWASP Top 10: https://owasp.org/www-project-top-ten/
- CWE: {CWE ID si aplica}
- CVE: {CVE ID si aplica}

## Dependencias
- {Issue de implementación relacionado}

---

**Estimación**: {1-4 story points}
**Prioridad**: {critical/high} (Las pruebas de seguridad son siempre alta prioridad)
**Severidad**: {Critical/High/Medium/Low}
**OWASP Category**: {A01-A10}
