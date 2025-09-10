---
name: Pruebas de Rendimiento
about: Plantilla para pruebas de carga y rendimiento
title: 'Pruebas de Rendimiento: [Nombre del Escenario]'
labels: ['performance-test', 'load-test', 'iso25010']
assignees: ''
---

# Pruebas de Rendimiento: {Nombre del Escenario}

## Alcance de Pruebas de Rendimiento

{Escenarios específicos de rendimiento a validar}

## Requisitos de Rendimiento

### Umbrales de Tiempo de Respuesta
- [ ] **Páginas principales**: ≤ 2 segundos
- [ ] **Búsqueda de productos**: ≤ 1.5 segundos
- [ ] **Operaciones de carrito**: ≤ 1 segundo
- [ ] **Proceso de checkout**: ≤ 3 segundos

### Umbrales de Carga
- [ ] **Usuarios concurrentes**: 100 usuarios simultáneos
- [ ] **Transacciones por segundo**: ≥ 50 TPS
- [ ] **Tiempo de actividad**: 99.5% disponibilidad
- [ ] **Escalabilidad**: Degradación < 10% con carga pico

### Utilización de Recursos
- [ ] **CPU**: < 70% bajo carga normal
- [ ] **Memoria**: < 512MB por instancia
- [ ] **Base de datos**: < 80% utilización de conexiones
- [ ] **Red**: < 1MB/s bandwidth promedio

## Escenarios de Prueba

### Prueba de Carga Normal
- [ ] **Usuarios**: 50 usuarios concurrentes
- [ ] **Duración**: 30 minutos
- [ ] **Patrón**: Carga constante
- [ ] **Operaciones**: Navegación, búsqueda, carrito

### Prueba de Carga Pico
- [ ] **Usuarios**: 100 usuarios concurrentes
- [ ] **Duración**: 15 minutos
- [ ] **Patrón**: Rampa gradual (10 min subida, 5 min sostenido)
- [ ] **Operaciones**: Flujo completo de compra

### Prueba de Stress
- [ ] **Usuarios**: 150+ usuarios concurrentes
- [ ] **Duración**: 20 minutos
- [ ] **Patrón**: Incremento gradual hasta falla
- [ ] **Objetivo**: Identificar punto de quiebre

### Prueba de Resistencia
- [ ] **Usuarios**: 75 usuarios concurrentes
- [ ] **Duración**: 2 horas
- [ ] **Patrón**: Carga sostenida
- [ ] **Objetivo**: Detectar memory leaks y degradación

## Herramientas y Configuración

### Herramientas de Prueba
- [ ] **NBomber** para pruebas .NET nativas
- [ ] **Artillery** para pruebas HTTP alternativas
- [ ] **Application Insights** para monitoreo
- [ ] **Perfview** para análisis de memoria

### Configuración del Entorno
- [ ] Entorno dedicado de performance testing
- [ ] Base de datos con datos representativos
- [ ] Monitoreo de recursos del servidor
- [ ] Red aislada para eliminar variables externas

## Escenarios de Usuario

### Flujo de Navegación (40% tráfico)
1. [ ] Página principal
2. [ ] Lista de productos
3. [ ] Detalles de producto
4. [ ] Regreso a lista

### Flujo de Búsqueda (30% tráfico)
1. [ ] Página principal
2. [ ] Búsqueda de productos
3. [ ] Refinamiento de resultados
4. [ ] Ver detalles de producto

### Flujo de Compra (25% tráfico)
1. [ ] Búsqueda de producto
2. [ ] Agregar al carrito
3. [ ] Ver carrito
4. [ ] Proceso de checkout
5. [ ] Confirmación

### Flujo de Gestión de Carrito (5% tráfico)
1. [ ] Agregar múltiples productos
2. [ ] Modificar cantidades
3. [ ] Remover productos
4. [ ] Continuar comprando

## Datos de Prueba

### Volumen de Datos
- [ ] **Productos**: 1,000+ productos en base de datos
- [ ] **Usuarios**: 500+ perfiles de usuario simulados
- [ ] **Sesiones**: Gestión de 100+ sesiones concurrentes
- [ ] **Transacciones**: Historial de 10,000+ transacciones

### Distribución de Datos
- [ ] Productos con diferentes tamaños de descripción
- [ ] Imágenes de productos de varios tamaños
- [ ] Carritos con 1-10 productos
- [ ] Búsquedas con términos populares y raros

## Métricas a Recolectar

### Métricas de Respuesta
- [ ] Tiempo de respuesta promedio
- [ ] Tiempo de respuesta percentil 95
- [ ] Tiempo de respuesta máximo
- [ ] Tasa de error por endpoint

### Métricas de Throughput
- [ ] Requests por segundo
- [ ] Transacciones completadas por minuto
- [ ] Datos transferidos por segundo
- [ ] Operaciones de base de datos por segundo

### Métricas de Recursos
- [ ] Utilización de CPU del servidor
- [ ] Uso de memoria RAM
- [ ] I/O de disco
- [ ] Conexiones de base de datos activas

### Métricas de Usuario
- [ ] Tiempo de carga percibido
- [ ] Tasa de abandono de sesión
- [ ] Tiempo para completar transacciones
- [ ] Errores experimentados por usuario

## Criterios de Aceptación

- [ ] Todos los umbrales de tiempo de respuesta alcanzados
- [ ] Sistema soporta carga objetivo sin degradación significativa
- [ ] Sin memory leaks detectados en prueba de resistencia
- [ ] Tasa de error < 1% bajo carga normal
- [ ] Utilización de recursos dentro de límites especificados

## Validación ISO 25010

### Eficiencia de Rendimiento
- [ ] **Comportamiento Temporal**: Tiempos de respuesta validados
- [ ] **Utilización de Recursos**: Uso eficiente de CPU/memoria
- [ ] **Capacidad**: Sistema maneja carga esperada

### Fiabilidad
- [ ] **Disponibilidad**: Sistema permanece disponible bajo carga
- [ ] **Tolerancia a Fallos**: Degradación elegante en sobrecarga

## Estimación

{Esfuerzo de implementación y ejecución: 4-6 puntos de historia}

## Dependencias

- [ ] Aplicación desplegada en entorno de performance
- [ ] Datos de prueba poblados
- [ ] Herramientas de monitoreo configuradas
- [ ] Acceso a métricas del servidor

## Entregables

- [ ] Scripts de prueba automatizados
- [ ] Reporte de resultados de rendimiento
- [ ] Análisis de cuellos de botella
- [ ] Recomendaciones de optimización
- [ ] Dashboard de métricas de rendimiento

## Plan de Ejecución

### Fase 1: Preparación (1 día)
- [ ] Configurar entorno y herramientas
- [ ] Crear scripts de prueba
- [ ] Validar datos de prueba

### Fase 2: Ejecución (2 días)
- [ ] Ejecutar pruebas de carga normal
- [ ] Ejecutar pruebas de stress
- [ ] Ejecutar pruebas de resistencia

### Fase 3: Análisis (1 día)
- [ ] Analizar resultados
- [ ] Identificar cuellos de botella
- [ ] Crear reporte y recomendaciones

## Definición de Completado

- [ ] Todas las pruebas ejecutadas exitosamente
- [ ] Métricas recolectadas y analizadas
- [ ] Reporte de rendimiento completado
- [ ] Recomendaciones de optimización documentadas
- [ ] Resultados validados por equipo técnico