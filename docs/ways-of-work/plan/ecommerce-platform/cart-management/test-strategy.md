# Estrategia de Pruebas: Gestión de Carrito de Compras

## Resumen de la Estrategia de Pruebas

### Alcance de las Pruebas
- **Componentes a probar**: CartController, modelo CartItem, vistas de carrito, funcionalidad de checkout
- **Objetivos de calidad**: Validación completa de operaciones de carrito, persistencia de sesión, flujo de checkout
- **Evaluación de riesgos**: Pérdida de datos de carrito, problemas de concurrencia, errores en cálculos de totales
- **Enfoque de pruebas**: Metodología basada en estados siguiendo marcos ISTQB e ISO 25010

### Riesgos Identificados y Estrategias de Mitigación
- **Alto Riesgo**: Pérdida de datos de carrito al cambiar de sesión o inactividad
- **Medio Riesgo**: Inconsistencias en cálculos de totales y manejo de cantidades
- **Bajo Riesgo**: Problemas de experiencia de usuario en flujo de checkout

## Implementación del Marco ISTQB

### Técnicas de Diseño de Pruebas - Transición de Estados

#### Estados del Carrito de Compras
- **Estado Vacío**: Sin productos añadidos
- **Estado Con Productos**: Uno o más productos en carrito
- **Estado En Checkout**: Proceso de finalización iniciado
- **Estado Finalizado**: Compra completada o carrito limpiado

#### Transiciones Válidas
- Vacío → Con Productos (AddToCart)
- Con Productos → Con Productos (AddToCart, modificar cantidad)
- Con Productos → Vacío (RemoveFromCart todos los productos)
- Con Productos → En Checkout (iniciar checkout)
- En Checkout → Finalizado (completar compra)
- En Checkout → Con Productos (cancelar checkout)

### Partición de Equivalencia para Operaciones de Carrito

#### Operaciones de Adición
- **Productos válidos**: IDs existentes en SampleData
- **Productos inválidos**: IDs no existentes, IDs negativos, IDs nulos
- **Cantidades válidas**: 1-999 unidades
- **Cantidades inválidas**: 0, números negativos, valores no numéricos

#### Operaciones de Eliminación  
- **Productos existentes en carrito**: Eliminación exitosa
- **Productos no existentes en carrito**: Manejo adecuado de error
- **Carrito vacío**: Comportamiento cuando no hay productos que eliminar

### Análisis de Valores Límite

#### Gestión de Cantidades
- **Valores límite**: 0, 1, 999, 1000 unidades por producto
- **Límites de carrito**: 0, 1, 50, 51 productos únicos
- **Cálculos de precio**: $0.01, $999.99, $10000.00

#### Gestión de Sesión
- **Timeout de sesión**: 29 min, 30 min, 31 min
- **Tamaño de datos**: Carritos con 1, 10, 100 productos

## Evaluación de Características de Calidad ISO 25010

### Fiabilidad - **CRÍTICA**
- **Tolerancia a fallos**: Recuperación ante pérdida de conexión durante checkout
- **Capacidad de recuperación**: Restauración de carrito tras timeout de sesión
- **Disponibilidad**: Operaciones de carrito disponibles 24/7

### Usabilidad - **CRÍTICA**
- **Reconocibilidad**: Iconos y botones de carrito claramente identificables
- **Capacidad de aprendizaje**: Flujo intuitivo para usuarios nuevos
- **Operabilidad**: Funciones accesibles en todos los dispositivos
- **Protección contra errores**: Confirmaciones para acciones destructivas

### Eficiencia de Rendimiento - **ALTA**
- **Comportamiento temporal**: Operaciones de carrito < 200ms
- **Utilización de recursos**: Gestión eficiente de memoria de sesión
- **Capacidad**: Soporte para carritos con hasta 100 productos

### Seguridad - **ALTA**
- **Integridad**: Prevención de manipulación de precios en carrito
- **Autorización**: Validación de propiedad de carrito por sesión
- **Confidencialidad**: Protección de datos de carrito entre sesiones

## Estrategia de Entorno y Datos de Prueba

### Datos de Prueba Específicos
- **Productos de diferentes precios**: $0.99, $19.99, $999.99
- **Productos con caracteres especiales**: Nombres con acentos, símbolos
- **Carritos pre-poblados**: Para pruebas de estado inicial
- **Sesiones múltiples**: Para pruebas de concurrencia

### Simulación de Escenarios Reales
- **Abandono de carrito**: Simulación de usuarios que no completan compra
- **Navegación entre páginas**: Mantenimiento de carrito durante browsing
- **Múltiples pestañas**: Comportamiento con múltiples ventanas abiertas

## Matriz de Cobertura de Pruebas

### Pruebas Funcionales por Método
- ✅ **CartController.Index()**: Visualización correcta de productos en carrito
- ✅ **CartController.AddToCart()**: Adición de productos y manejo de duplicados
- ✅ **CartController.RemoveFromCart()**: Eliminación individual y validaciones
- ✅ **CartController.Checkout()**: Inicialización de proceso de compra
- ✅ **Helper methods**: GetCartItems(), SaveCartItems(), session management

### Pruebas de Integración Específicas
- ✅ **Carrito-Productos**: Integración con SampleData para información de productos
- ✅ **Carrito-Sesión**: Persistencia correcta en SessionExtensions
- ✅ **Carrito-Base de Datos**: Interacción con ApplicationDbContext
- ✅ **Carrito-Vistas**: Renderizado correcto de datos en vistas

### Pruebas End-to-End por Flujo
- ✅ **Flujo de compra completo**: Navegación → Agregar → Ver carrito → Checkout
- ✅ **Modificación de carrito**: Cambiar cantidades, eliminar productos
- ✅ **Carrito persistente**: Mantenimiento entre navegación de páginas
- ✅ **Abandono y recuperación**: Comportamiento ante interrupciones

## Criterios de Entrada y Salida Específicos

### Criterios de Entrada Específicos para Carrito
- ✅ CartController implementado con todos los métodos
- ✅ SessionExtensions configurado y funcional
- ✅ Vistas de carrito y checkout creadas
- ✅ ApplicationDbContext configurado para persistencia

### Criterios de Salida Específicos para Carrito
- ✅ 100% de operaciones CRUD de carrito funcionales
- ✅ Persistencia de sesión validada en múltiples escenarios
- ✅ Cálculos de totales correctos en todos los casos de prueba
- ✅ Flujo de checkout completo sin errores críticos
- ✅ Manejo de concurrencia validado

## Casos de Prueba Específicos Críticos

### Casos de Prueba de Alto Riesgo
1. **Pérdida de carrito en timeout**: Validar comportamiento al expirar sesión
2. **Concurrencia de sesiones**: Múltiples pestañas modificando mismo carrito
3. **Productos eliminados**: Comportamiento cuando producto en carrito ya no existe
4. **Cálculos con decimales**: Precisión en sumas con precios con centavos
5. **Límites de carrito**: Comportamiento con carritos muy grandes

### Casos de Prueba de Regresión
1. **Navegación POST-carrito**: Mantener carrito después de agregar productos
2. **Refresh de página**: Persistencia de carrito tras F5
3. **Navegación back/forward**: Comportamiento con botones de navegador
4. **Enlaces directos**: Acceso directo a páginas con carrito poblado