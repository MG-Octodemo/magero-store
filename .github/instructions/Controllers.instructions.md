---
applyTo: '**Controller.cs'
---

Directrices Generales para Controladores
===============================
Los controladores en una aplicación ASP.NET Core son responsables de manejar las solicitudes HTTP entrantes,
procesarlas y devolver respuestas HTTP apropiadas. Aquí hay algunas directrices generales a seguir al implementar controladores:
1. **Convenciones de Nomenclatura**:
    - Nombra tus controladores con el sufijo "Controller" (por ejemplo, `ProductController`).
    - Usa PascalCase para los nombres de los controladores.
2. **Enrutamiento**:
    - Utiliza el enrutamiento por atributos para definir las rutas de tus acciones de controlador.
    - Mantén las rutas simples e intuitivas.
3. **Manejo de Solicitudes**:
    - Define métodos de acción para manejar diferentes verbos HTTP (GET, POST, PUT, DELETE).
    - Usa atributos como `[HttpGet]`, `[HttpPost]`, etc., para especificar el verbo HTTP.
4. **Validación de Modelos**:
    - Valida los modelos de entrada utilizando atributos de validación y el estado del modelo (`ModelState.IsValid`).
    - Devuelve respuestas adecuadas en caso de errores de validación.
5. **Inyección de Dependencias**:
    - Utiliza la inyección de dependencias para obtener servicios necesarios en el controlador.
    - Evita la creación directa de instancias de servicios dentro del controlador.
6. **Manejo de Excepciones**:
    - Implementa un manejo de excepciones global para capturar errores no controlados.
    - Devuelve respuestas de error significativas y consistentes.
7. **Respuesta HTTP**:     
    - Utiliza tipos de retorno adecuados como `IActionResult` o `ActionResult<T>`.
    - Devuelve códigos de estado HTTP apropiados (200, 201, 400, 404, 500, etc.).
8. **Documentación**:
    - Documenta tus controladores y métodos de acción utilizando comentarios XML.
    - Proporciona ejemplos de uso y descripciones claras.
9. **Seguridad**:
    - Implementa autenticación y autorización según sea necesario.
    - Usa atributos como `[Authorize]` para proteger las acciones del controlador.
10. **Pruebas**:
    - Escribe pruebas unitarias para tus controladores para asegurar su correcto funcionamiento.
    - Utiliza frameworks de pruebas como xUnit, NUnit o MSTest.
Siguiendo estas directrices, puedes crear controladores robustos, mantenibles y seguros en tu aplicación ASP.NET Core.