# Configuración de Autenticación con Entra ID External Identities

## Descripción

Este documento describe cómo configurar la autenticación de doble factor utilizando Microsoft Entra ID External Identities (Azure AD B2C) en la aplicación Magero Store.

## Prerequisitos

1. Suscripción de Azure activa
2. Permisos para crear recursos en Azure
3. .NET 8.0 SDK instalado

## Configuración de Azure AD B2C

### 1. Crear un Tenant de Azure AD B2C

1. Inicia sesión en el [Portal de Azure](https://portal.azure.com)
2. Busca "Azure AD B2C" en el buscador
3. Haz clic en "Crear un recurso" > "Identidad" > "Azure Active Directory B2C"
4. Selecciona "Crear un nuevo tenant de Azure AD B2C"
5. Completa los campos:
   - **Nombre de organización**: `magero-store`
   - **Nombre de dominio inicial**: `magero-store` (resultado: `magero-store.onmicrosoft.com`)
   - **País/región**: Selecciona tu región
6. Haz clic en "Revisar y crear"

### 2. Registrar la aplicación

1. En el portal de Azure AD B2C, ve a "Registros de aplicaciones"
2. Haz clic en "Nuevo registro"
3. Completa los campos:
   - **Nombre**: `MageroStore-WebApp`
   - **Tipos de cuenta admitidos**: "Cuentas en cualquier proveedor de identidades o directorio organizacional"
   - **URI de redirección**: 
     - Tipo: Web
     - URI: `https://localhost:7000/signin-oidc` (para desarrollo)
     - URI: `https://yourdomain.com/signin-oidc` (para producción)
4. Haz clic en "Registrar"
5. Anota el **ID de aplicación (cliente)** que aparece en la página de información general

### 3. Configurar secretos de cliente

1. En tu aplicación registrada, ve a "Certificados y secretos"
2. Haz clic en "Nuevo secreto de cliente"
3. Añade una descripción: `MageroStore-ClientSecret`
4. Selecciona expiración: `24 meses`
5. Haz clic en "Agregar"
6. **IMPORTANTE**: Copia el valor del secreto inmediatamente, no podrás verlo después

### 4. Crear User Flows

#### Sign Up/Sign In Flow
1. Ve a "Flujos de usuario" en el menú de Azure AD B2C
2. Haz clic en "Nuevo flujo de usuario"
3. Selecciona "Registrarse e iniciar sesión"
4. Configuración:
   - **Nombre**: `B2C_1_signupsignin`
   - **Proveedores de identidades**: Marca "Registro por correo electrónico"
   - **Autenticación multifactor**: Selecciona "Activado" y "Aplicación de autenticador"
   - **Atributos del usuario**: Selecciona "Nombre para mostrar", "Nombre", "Apellido"
   - **Notificaciones de aplicación**: Selecciona todos los atributos anteriores más "ID de objeto"
5. Haz clic en "Crear"

#### Password Reset Flow
1. Haz clic en "Nuevo flujo de usuario"
2. Selecciona "Restablecimiento de contraseña"
3. Configuración:
   - **Nombre**: `B2C_1_passwordreset`
   - **Proveedores de identidades**: "Restablecer contraseña mediante dirección de correo electrónico"
4. Haz clic en "Crear"

#### Profile Edit Flow
1. Haz clic en "Nuevo flujo de usuario"
2. Selecciona "Edición de perfiles"
3. Configuración:
   - **Nombre**: `B2C_1_profileedit`
   - **Proveedores de identidades**: "Cuenta local"
   - **Atributos del usuario**: Selecciona "Nombre para mostrar", "Nombre", "Apellido"
4. Haz clic en "Crear"

## Configuración de la aplicación

### 1. Actualizar appsettings.json

Reemplaza los valores de placeholder en `appsettings.json`:

```json
{
  "AzureAdB2C": {
    "Instance": "https://magero-store.b2clogin.com/",
    "Domain": "magero-store.onmicrosoft.com",
    "TenantId": "magero-store.onmicrosoft.com",
    "ClientId": "[TU-CLIENT-ID-AQUI]",
    "ClientSecret": "[TU-CLIENT-SECRET-AQUI]",
    "CallbackPath": "/signin-oidc",
    "SignUpSignInPolicyId": "B2C_1_signupsignin",
    "ResetPasswordPolicyId": "B2C_1_passwordreset",
    "EditProfilePolicyId": "B2C_1_profileedit"
  }
}
```

### 2. Variables de entorno (Recomendado para producción)

En lugar de poner los secretos directamente en appsettings.json, usa variables de entorno:

```bash
export AzureAdB2C__ClientSecret="[TU-CLIENT-SECRET-AQUI]"
export AzureAdB2C__ClientId="[TU-CLIENT-ID-AQUI]"
```

### 3. Configuración en Azure App Service (Producción)

En el portal de Azure, ve a tu App Service > Configuración > Configuración de la aplicación:

- `AzureAdB2C__Instance`: `https://magero-store.b2clogin.com/`
- `AzureAdB2C__Domain`: `magero-store.onmicrosoft.com`
- `AzureAdB2C__TenantId`: `magero-store.onmicrosoft.com`
- `AzureAdB2C__ClientId`: `[TU-CLIENT-ID]`
- `AzureAdB2C__ClientSecret`: `[TU-CLIENT-SECRET]`
- `AzureAdB2C__SignUpSignInPolicyId`: `B2C_1_signupsignin`
- `AzureAdB2C__ResetPasswordPolicyId`: `B2C_1_passwordreset`
- `AzureAdB2C__EditProfilePolicyId`: `B2C_1_profileedit`

## Testing y Verificación

### 1. Probar localmente

```bash
cd magero-store
dotnet run
```

Navega a `https://localhost:7000` y prueba:
1. Hacer clic en "Registrarse"
2. Completar el registro con 2FA
3. Iniciar sesión
4. Acceder a una ruta protegida (ej: Checkout)

### 2. Configurar aplicación autenticadora

Durante el registro, el usuario debe:
1. Descargar una aplicación autenticadora (Microsoft Authenticator, Google Authenticator)
2. Escanear el código QR presentado por Azure AD B2C
3. Introducir el código de 6 dígitos para verificar

## Funcionalidades implementadas

✅ **Registro e inicio de sesión** con Entra ID External Identities
✅ **Autenticación de doble factor obligatoria** usando aplicaciones autenticadoras
✅ **Protección de rutas sensibles** (ej: Checkout)
✅ **Gestión de perfiles** y restablecimiento de contraseñas
✅ **Integración con base de datos local** para información adicional del usuario
✅ **Interfaz de usuario responsive** con Bootstrap

## Seguridad

- **2FA obligatorio**: Los usuarios deben configurar 2FA durante el registro
- **Tokens seguros**: Manejo de tokens JWT por Microsoft Identity Web
- **Sesiones seguras**: Configuración apropiada de cookies y sesiones
- **Redirect URI validation**: Solo URIs autorizados pueden recibir tokens

## Solución de problemas

### Error: "Invalid redirect URI"
- Verifica que el redirect URI en Azure AD B2C coincida exactamente con tu configuración local/producción

### Error: "Policy not found"
- Asegúrate de que los nombres de los flujos de usuario en appsettings.json coincidan con los creados en Azure AD B2C

### Error: "Invalid client secret"
- Regenera el secreto de cliente en Azure AD B2C y actualiza la configuración

### 2FA no funciona
- Verifica que la autenticación multifactor esté habilitada en el flujo de usuario
- Asegúrate de que el usuario haya configurado correctamente su aplicación autenticadora

## Recursos adicionales

- [Documentación oficial de Azure AD B2C](https://docs.microsoft.com/en-us/azure/active-directory-b2c/)
- [Microsoft.Identity.Web Documentation](https://docs.microsoft.com/en-us/azure/active-directory/develop/microsoft-identity-web)
- [ASP.NET Core Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/)