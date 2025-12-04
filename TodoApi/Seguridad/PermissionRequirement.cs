using Microsoft.AspNetCore.Authorization;

namespace TodoApi.Seguridad;
public class PermissionRequirement(string permissionKey) : IAuthorizationRequirement
{
    public string PermissionKey { get; } = permissionKey;  // ej: "add_ent_user"
}
