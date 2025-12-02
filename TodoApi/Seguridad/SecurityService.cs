using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Seguridad;

namespace TodoApi.services;

public class SecurityService ( IUserRepository userRepository) : ISecurityService
{
    
    
    private readonly IUserRepository _userRepository = userRepository;



    public  async Task<bool> HasPermissionAsync(int userId, string permissionNeeded)
    {
        var user = await _userRepository.GetByIdWithRolesAndPermisosAsync(userId) ?? throw new Exception("not foun user");

        return HasPermission(user.Roles, permissionNeeded); 
    }
     public static bool HasPermission(IEnumerable<Role> roles, string permissionNeeded)
    {

        // Combinar permisos de todos los roles en un único HashSet
        var permissionNames = new HashSet<string>(
            roles
                .SelectMany(r => r.Permisos)
                .Select(p => p.Name),
            StringComparer.OrdinalIgnoreCase
        );

        //  All Http (admin)
        if (permissionNames.Contains("all_http"))
            return true;

        // Permiso tal cual
        if (permissionNames.Contains(permissionNeeded))
            return true;

        // Permisos all
        var parts = permissionNeeded.Split('_', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length >= 4 && parts[1].Equals("ent", StringComparison.OrdinalIgnoreCase))
        {
            var entity = parts[2];
            var module = parts[3];

            //  all_ent_entidad_modulo
            var allEntityPermission = $"all_ent_{entity}_{module}";
            if (permissionNames.Contains(allEntityPermission))
                return true;

            //  all_mod_modulo
            var allModulePermission = $"all_mod_{module}";
            if (permissionNames.Contains(allModulePermission))
                return true;
        }

        return false;
    }

}