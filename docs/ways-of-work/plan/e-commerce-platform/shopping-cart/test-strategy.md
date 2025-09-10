# Estrategia de Pruebas - Funcionalidad del Carrito de Compras

## Resumen de la Estrategia de Pruebas

Esta estrategia define el enfoque comprehensivo para probar la funcionalidad del carrito de compras del sistema magero-store, aplicando técnicas ISTQB y validando características de calidad ISO 25010.

## Aplicación del Marco ISTQB

### Técnicas de Diseño de Pruebas Utilizadas

#### Partición de Equivalencia
**Clases de Equivalencia Identificadas:**
- **IDs de Producto**: Válidos (1-20), Inválidos (≤0, >20, no numéricos)
- **Cantidades**: Válidas (1-999), Inválidas (≤0, >999, no numéricas)
- **Estados de Sesión**: Activa, Expirada, Nueva
- **Estados del Carrito**: Vacío, Con productos, Lleno (límite)

#### Análisis de Valores Límite
**Valores Límite Identificados:**
- **Cantidad de Productos**: 0, 1, 999, 1000
- **ID de Producto**: 0, 1, 20, 21
- **Precio Total**: 0.00, 0.01, 99999.99
- **Duración de Sesión**: 0 min, 30 min, 31 min

#### Pruebas de Tabla de Decisión
**Reglas de Negocio del Carrito:**

| Condición | Regla 1 | Regla 2 | Regla 3 | Regla 4 |
|-----------|---------|---------|---------|---------|
| Producto existe | Sí | Sí | No | Sí |
| Cantidad válida | Sí | No | Sí | Sí |
| Sesión activa | Sí | Sí | Sí | No |
| **Acción** | Agregar | Error | Error | Redirigir |

#### Pruebas de Transición de Estado
**Estados del Carrito:**
- **Vacío** → **Con Productos** (agregar primer producto)
- **Con Productos** → **Con Productos** (agregar más productos)
- **Con Productos** → **Vacío** (remover todos los productos)
- **Con Productos** → **Checkout** (proceder al pago)

### Cobertura de Tipos de Pruebas

#### Pruebas Funcionales ✅
- Agregar productos al carrito
- Remover productos del carrito
- Actualizar cantidades
- Calcular totales
- Persistencia de sesión

#### Pruebas No Funcionales ✅
- Rendimiento bajo carga concurrente
- Usabilidad de la interfaz
- Seguridad de datos de sesión
- Compatibilidad cross-browser

#### Pruebas Estructurales ✅
- Cobertura de código del CartController
- Pruebas unitarias de SessionExtensions
- Validación de integración con base de datos

#### Pruebas Relacionadas con Cambios ✅
- Regresión tras modificaciones
- Confirmación de correcciones de bugs

## Características de Calidad ISO 25010

### Evaluación de Prioridades

#### Idoneidad Funcional: **CRÍTICA**
- **Completitud**: Todas las operaciones de carrito implementadas
- **Corrección**: Cálculos precisos de totales y cantidades
- **Apropiación**: Interfaz intuitiva para gestión de carrito

#### Eficiencia de Rendimiento: **ALTA**
- **Comportamiento Temporal**: Operaciones de carrito < 1 segundo
- **Utilización de Recursos**: Gestión eficiente de memoria de sesión
- **Capacidad**: Soporte para 100+ usuarios con carritos activos

#### Usabilidad: **ALTA**
- **Capacidad de Aprendizaje**: Operaciones intuitivas
- **Operabilidad**: Controles fáciles de usar
- **Accesibilidad**: Compatible con lectores de pantalla

#### Fiabilidad: **ALTA**
- **Tolerancia a Fallos**: Manejo elegante de errores de sesión
- **Recuperación**: Restauración de carrito tras reconexión
- **Disponibilidad**: Funcionalidad siempre disponible

#### Seguridad: **MEDIA**
- **Confidencialidad**: Datos de carrito protegidos por sesión
- **Integridad**: Precios no manipulables por usuario
- **Autenticación**: Validación de sesión apropiada

#### Compatibilidad: **MEDIA**
- **Co-existencia**: No interfiere con otras funcionalidades
- **Interoperabilidad**: Integración con sistema de productos

#### Mantenibilidad: **MEDIA**
- **Modularidad**: Código del carrito bien estructurado
- **Capacidad de Prueba**: Componentes fáciles de probar
- **Reutilización**: Lógica reutilizable en otros módulos

#### Portabilidad: **BAJA**
- **Adaptabilidad**: Funciona en diferentes navegadores
- **Instalabilidad**: No aplica directamente

## Puertas de Calidad

### Criterios de Entrada
- [ ] Funcionalidad de productos completamente implementada
- [ ] SessionExtensions configuradas y probadas
- [ ] Entorno de desarrollo con datos de prueba
- [ ] Framework de pruebas xUnit configurado

### Criterios de Salida
- [ ] Cobertura de código ≥ 85% para CartController
- [ ] Todas las pruebas unitarias pasando (100%)
- [ ] Pruebas E2E del flujo de carrito exitosas
- [ ] Tiempo de respuesta < 1 segundo para operaciones
- [ ] Sin defectos críticos o altos

### Umbrales de Calidad
- **Funcional**: 100% criterios de aceptación validados
- **Rendimiento**: ≤ 1 segundo por operación de carrito
- **Usabilidad**: Completar flujo de carrito en ≤ 3 clics
- **Seguridad**: Validación de sesión en todas las operaciones

## Plan de Pruebas Detallado

### Pruebas Unitarias (8 puntos de historia)

#### CartController Tests (4 puntos)
- **Index()**: Retorna vista con elementos del carrito
- **AddToCart()**: Agrega productos correctamente
- **RemoveFromCart()**: Remueve productos apropiadamente
- **Checkout()**: Valida carrito y redirige

#### SessionExtensions Tests (2 puntos)
- **Set<T>()**: Serialización correcta de objetos
- **Get<T>()**: Deserialización correcta de objetos
- **Manejo de valores null y errores**

#### CartItem Model Tests (2 puntos)
- **Propiedades**: Validación de propiedades
- **Cálculos**: Subtotales y totales correctos

### Pruebas de Integración (4 puntos de historia)

#### Integración Carrito-Sesión (2 puntos)
- Persistencia de carrito entre requests
- Expiración de sesión y limpieza de carrito
- Múltiples productos en sesión

#### Integración Carrito-Productos (2 puntos)
- Validación de productos existentes
- Manejo de productos inexistentes
- Actualización de información de productos

### Pruebas E2E con Playwright (6 puntos de historia)

#### Flujo Completo de Carrito (3 puntos)
- Agregar múltiples productos
- Modificar cantidades
- Remover productos
- Proceder a checkout

#### Escenarios de Error (2 puntos)
- Productos inexistentes
- Cantidades inválidas
- Sesión expirada

#### Compatibilidad Cross-Browser (1 punto)
- Chrome, Firefox, Safari
- Responsividad móvil

### Pruebas de Rendimiento (3 puntos de historia)

#### Carga Concurrente de Carritos (2 puntos)
- 50 usuarios concurrentes modificando carritos
- Medición de tiempo de respuesta
- Utilización de memoria de sesión

#### Pruebas de Stress de Sesión (1 punto)
- Múltiples operaciones de carrito por sesión
- Gestión de memoria bajo carga
- Límites de almacenamiento de sesión

### Pruebas de Seguridad (2 puntos de historia)

#### Validación de Sesión (1 punto)
- Manipulación de IDs de sesión
- Acceso a carritos de otros usuarios
- Validación de datos de carrito

#### Integridad de Datos (1 punto)
- Manipulación de precios en cliente
- Validación de cantidades en servidor
- Protección contra manipulación de URLs

## Cronograma de Ejecución

### Sprint 1: Fundamentos
- **Semana 1**: Configuración de framework y pruebas unitarias
- **Semana 2**: Pruebas de integración básicas

### Sprint 2: Automatización
- **Semana 3**: Implementación de pruebas Playwright
- **Semana 4**: Pruebas de rendimiento y optimización

### Sprint 3: Calidad Avanzada
- **Semana 5**: Pruebas de seguridad y validación ISO 25010
- **Semana 6**: Suite de regresión y documentación

## Métricas de Éxito

### Métricas Cuantitativas
- **Cobertura de Código**: ≥ 85% CartController, ≥ 90% lógica crítica
- **Tiempo de Respuesta**: ≤ 1 segundo promedio para operaciones
- **Capacidad**: 100 usuarios concurrentes sin degradación
- **Estabilidad**: ≤ 1% tasa de fallas de pruebas automatizadas

### Métricas Cualitativas
- **Usabilidad**: Usuarios completan flujo sin ayuda
- **Mantenibilidad**: Nuevas pruebas agregadas fácilmente
- **Trazabilidad**: 100% requisitos cubiertos por pruebas

## Riesgos y Mitigaciones

### Riesgos Identificados
1. **Gestión de Sesión Compleja**: Múltiples estados de sesión difíciles de probar
2. **Rendimiento de Sesión**: Almacenamiento en memoria puede limitar escalabilidad
3. **Sincronización**: Operaciones concurrentes pueden causar inconsistencias

### Estrategias de Mitigación
1. **Mocking de Sesiones**: Usar mocks para simplificar pruebas unitarias
2. **Pruebas de Carga**: Validar límites de escalabilidad tempranamente
3. **Pruebas de Concurrencia**: Implementar pruebas específicas para race conditions

## Conclusión

Esta estrategia proporciona una cobertura comprehensiva de la funcionalidad del carrito de compras, aplicando principios ISTQB e ISO 25010 para asegurar calidad desde múltiples perspectivas. La implementación gradual permitirá validación temprana y continua de la calidad del sistema.