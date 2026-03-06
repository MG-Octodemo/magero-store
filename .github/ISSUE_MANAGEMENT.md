# Gestión de Issues - magero-store

## Descripción General

Este documento describe el sistema de gestión de issues implementado en el repositorio magero-store y confirma su correcto funcionamiento.

## Verificación del Sistema

### Estado: ✅ Verificado

El sistema de gestión de issues de GitHub ha sido verificado y funciona correctamente con las siguientes capacidades:

- ✅ Creación de issues
- ✅ Listado y visualización de issues
- ✅ Sistema de etiquetas (labels)
- ✅ Comentarios en issues
- ✅ Integración con workflows de GitHub Actions

## Plantillas de Issues

Se han creado las siguientes plantillas para facilitar la gestión de issues:

### 🐛 Reporte de Bug (`bug_report.yml`)
Plantilla estructurada para reportar errores y problemas en la aplicación, incluyendo:
- Descripción del problema
- Pasos para reproducir
- Comportamiento esperado vs. actual
- Nivel de severidad
- Información del entorno

### ✨ Solicitud de Funcionalidad (`feature_request.yml`)
Plantilla para proponer nuevas funcionalidades, incluyendo:
- Problema que resuelve
- Solución propuesta
- Alternativas consideradas
- Nivel de prioridad

### 🧪 Issue de Prueba (`test_issue.yml`)
Plantilla específica para issues de verificación y testing, incluyendo:
- Objetivo de la prueba
- Tareas de verificación (checklist)
- Resultados esperados
- Notas adicionales

## Etiquetas Configuradas

El sistema utiliza las siguientes etiquetas principales:

- `bug` - Para reportes de errores
- `enhancement` - Para solicitudes de funcionalidades
- `testing` - Para issues relacionados con pruebas
- `verification` - Para tareas de verificación del sistema

## Flujo de Trabajo con Issues

### 1. Creación de Issues
Los usuarios pueden crear issues utilizando las plantillas predefinidas o crear issues en blanco según sus necesidades.

### 2. Etiquetado
Las plantillas asignan automáticamente las etiquetas apropiadas, pero estas pueden ser modificadas según sea necesario.

### 3. Gestión y Seguimiento
Los issues pueden ser asignados, comentados y organizados usando:
- Asignación de responsables
- Etiquetas adicionales
- Milestones
- Proyectos

### 4. Cierre de Issues
Los issues deben cerrarse cuando:
- El problema ha sido resuelto
- La funcionalidad ha sido implementada
- La verificación ha sido completada
- El issue ya no es relevante

## Integración con GitHub Actions

El sistema de issues está integrado con los workflows de GitHub Actions definidos en `.github/workflows/`:

- **compile.yml**: Workflow de compilación que se ejecuta en PRs
- Los issues pueden referenciar builds fallidos
- Los commits pueden cerrar issues automáticamente usando palabras clave como "fixes #issue-number" o "closes #issue-number"

## Mejores Prácticas

1. **Usa las plantillas apropiadas**: Selecciona la plantilla que mejor se ajuste al tipo de issue que estás creando
2. **Proporciona información completa**: Completa todos los campos requeridos para facilitar la resolución
3. **Usa etiquetas descriptivas**: Las etiquetas ayudan a organizar y priorizar el trabajo
4. **Referencia issues en commits**: Usa "fixes #123" en mensajes de commit para vincular cambios con issues
5. **Mantén los issues actualizados**: Agrega comentarios sobre el progreso o cambios en el estado

## Recursos Adicionales

- [Documentación del Proyecto](../README.md)
- [Guía de Contribución](../README.md#contributing)
- [GitHub Issues Documentation](https://docs.github.com/en/issues)

## Historial de Verificación

| Fecha | Verificador | Resultado | Notas |
|-------|-------------|-----------|-------|
| 2025-10-31 | Sistema Automatizado | ✅ Exitoso | Verificación inicial completa. Sistema operativo. |

---

*Última actualización: 2025-10-31*
