namespace TodoApi.Seguridad;

public interface ISecurityService
{

    Task<bool> HasPermissionAsync(int userId, string permissionNeeded);
}