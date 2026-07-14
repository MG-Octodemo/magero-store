---
name: Accessibility Test Issue
about: Pruebas de accesibilidad y cumplimiento WCAG
title: '[A11Y-TEST] '
labels: accessibility-test, wcag, usability
assignees: ''
---

# Accessibility Tests: {Nombre del Componente/Página}

## Alcance de Pruebas de Accesibilidad
{Descripción de las páginas/componentes siendo validados para accesibilidad}

## Nivel de Conformidad WCAG
**Target**: WCAG 2.1 Level {A/AA/AAA}
**Prioridad**: {Crítico/Alto/Medio/Bajo}

## Principios WCAG a Validar

### 1. Perceptible
- [ ] **Alternativas de Texto (1.1)**
  - [ ] Todas las imágenes tienen alt text
  - [ ] Alt text es descriptivo y significativo
  - [ ] Imágenes decorativas tienen alt vacío
  
- [ ] **Medios Basados en Tiempo (1.2)**
  - [ ] Videos tienen captions/subtítulos
  - [ ] Audio tiene transcripción
  
- [ ] **Adaptable (1.3)**
  - [ ] Estructura semántica correcta (headings, lists, etc)
  - [ ] Orden de lectura lógico
  - [ ] Información no depende solo de forma/tamaño/ubicación
  
- [ ] **Distinguible (1.4)**
  - [ ] Contraste de color ≥ 4.5:1 (texto normal)
  - [ ] Contraste de color ≥ 3:1 (texto grande)
  - [ ] Texto puede redimensionarse 200% sin pérdida de contenido
  - [ ] Texto en imágenes evitado (o alternativa disponible)

### 2. Operable
- [ ] **Accesible por Teclado (2.1)**
  - [ ] Toda funcionalidad disponible por teclado
  - [ ] Sin keyboard traps
  - [ ] Focus order lógico
  - [ ] Skip links disponibles
  
- [ ] **Tiempo Suficiente (2.2)**
  - [ ] Timeouts ajustables o deshabilitados
  - [ ] Pausar/detener contenido en movimiento
  
- [ ] **Convulsiones (2.3)**
  - [ ] Sin contenido que parpadea > 3 veces por segundo
  
- [ ] **Navegable (2.4)**
  - [ ] Títulos de página descriptivos
  - [ ] Focus visible
  - [ ] Múltiples formas de navegación
  - [ ] Headings y labels descriptivos

### 3. Comprensible
- [ ] **Legible (3.1)**
  - [ ] Idioma de página especificado (lang attribute)
  - [ ] Idioma de partes especificado si cambia
  
- [ ] **Predecible (3.2)**
  - [ ] Focus no causa cambios de contexto
  - [ ] Input no causa cambios de contexto inesperados
  - [ ] Navegación consistente
  
- [ ] **Asistencia de Entrada (3.3)**
  - [ ] Errores identificados claramente
  - [ ] Labels o instrucciones proporcionadas
  - [ ] Sugerencias de corrección de errores
  - [ ] Prevención de errores en envío de datos

### 4. Robusto
- [ ] **Compatible (4.1)**
  - [ ] HTML válido (no errores críticos)
  - [ ] Name, Role, Value disponibles para AT
  - [ ] ARIA attributes correctos

## Herramientas de Testing

### Automated Testing:
- [ ] **axe DevTools**: Escaneo automático
- [ ] **WAVE**: Evaluación web accessibility
- [ ] **Lighthouse**: Accessibility audit
- [ ] **pa11y**: Automated testing en CI/CD

### Manual Testing:
- [ ] **Keyboard Navigation**: Navegación completa por teclado
- [ ] **Screen Readers**:
  - [ ] NVDA (Windows)
  - [ ] JAWS (Windows)
  - [ ] VoiceOver (macOS/iOS)
  - [ ] TalkBack (Android)
- [ ] **Zoom/Magnification**: 200% zoom test
- [ ] **Color Contrast Analyzer**: Validación manual de contraste

## Casos de Prueba Específicos

### Navegación por Teclado:
```
Test: Navegar formulario solo con teclado
Steps:
1. Tab a través de todos los campos
2. Verificar focus visible
3. Completar y enviar formulario con Enter
Expected: Todo funciona sin mouse
```

### Screen Reader:
```
Test: Lectura de página con screen reader
Steps:
1. Activar NVDA/VoiceOver
2. Navegar por la página
3. Verificar anuncios de headings, links, form fields
Expected: Información clara y estructurada
```

### Color Contrast:
```
Test: Validar contraste de colores
Tool: Color Contrast Analyzer
Elementos: Todos los textos, iconos, bordes
Expected: Ratios cumplen WCAG AA
```

## ARIA Implementation

### ARIA Roles:
- [ ] Roles apropiados asignados (navigation, main, complementary, etc)
- [ ] Landmarks correctamente implementados

### ARIA Properties:
- [ ] aria-label/aria-labelledby en elementos interactivos
- [ ] aria-describedby para información adicional
- [ ] aria-required en campos obligatorios
- [ ] aria-invalid en errores de validación

### ARIA States:
- [ ] aria-expanded en accordions/dropdowns
- [ ] aria-hidden en contenido decorativo
- [ ] aria-live para actualizaciones dinámicas

## Criterios de Aceptación
- [ ] Escaneo automatizado sin issues críticos
- [ ] Navegación por teclado completa funcional
- [ ] Screen reader testing pasado
- [ ] Contraste de color cumple WCAG AA
- [ ] Formularios accesibles y usables
- [ ] Focus management correcto
- [ ] ARIA attributes apropiados
- [ ] HTML semántico y válido

## Issues de Accesibilidad Identificados

| Issue | Severidad | WCAG Criterion | Estado |
|-------|-----------|----------------|--------|
| {Issue 1} | {Critical/High/Medium/Low} | {#.#.#} | ☐ |
| {Issue 2} | {Critical/High/Medium/Low} | {#.#.#} | ☐ |

## Métricas de Accesibilidad

- **axe Score**: {puntuación}/100
- **Lighthouse Score**: {puntuación}/100
- **WCAG Violations**: {número}
- **Manual Test Pass Rate**: {porcentaje}%

## Usuarios Afectados
- Usuarios con discapacidad visual
- Usuarios con discapacidad motriz
- Usuarios con discapacidad cognitiva
- Usuarios que navegan solo con teclado
- Usuarios de lectores de pantalla

## Dependencias
- {Issue de implementación UI}

## Referencias
- WCAG 2.1: https://www.w3.org/WAI/WCAG21/quickref/
- ARIA Authoring Practices: https://www.w3.org/WAI/ARIA/apg/
- MDN Accessibility: https://developer.mozilla.org/en-US/docs/Web/Accessibility

---

**Estimación**: {2-4 story points}
**Prioridad**: {high/medium}
**WCAG Level**: {A/AA/AAA}
**Component**: {nombre del componente}
