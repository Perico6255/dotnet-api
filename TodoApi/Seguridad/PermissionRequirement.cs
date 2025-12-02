using Microsoft.AspNetCore.Authorization;

namespace TodoApi.Seguridad;
public class PermissionRequirement : IAuthorizationRequirement
{
    public string PermissionKey { get; }

    public PermissionRequirement(string permissionKey)
    {
        PermissionKey = permissionKey;  // ej: "add_ent_user"
    }
}
