using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TodoApi.services;
namespace TodoApi.Seguridad;

public class PermissionHandler(ISecurityService securityService) : AuthorizationHandler<PermissionRequirement>
{
    private readonly ISecurityService _securityService =securityService;


    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        // Sacar userId del sub del JWT
        var userIdClaim = context.User.FindFirst(JwtRegisteredClaimNames.Sub)
                        ?? throw new Exception("User not found in jwt");

        if (userIdClaim == null)
            return;

        if (!int.TryParse(userIdClaim.Value, out var userId))
            return;

        // Preguntamos a BD (o caché) si el usuario tiene "efectivamente" ese permiso
        var hasPermission = await _securityService.HasPermissionAsync(userId, requirement.PermissionKey);


        if (hasPermission)
        {
            context.Succeed(requirement);
        }
    }
}
