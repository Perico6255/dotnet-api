using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.services;

class SecurityService (PermisoRepository permisoRepository, UserRepository userRepository)
{
    
    
    private readonly IPermisoRepository _permisoRepository = permisoRepository;
    private readonly IUserRepository _userRepository = userRepository;



    public  async Task<bool> hasPermissionAsync(int userId, string permission)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        return false; 
    }

}