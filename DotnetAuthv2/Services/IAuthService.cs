using DotnetAuthv2.Entities.Models;
using DotnetAuthv2.Entities;

namespace DotnetAuthv2.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDTO request);
        Task<TokenResponseDTO> LoginAsync(UserDTO request);
        Task<TokenResponseDTO?> RefreshTokensAsync(RefreshTokenRequestDTO refreshTokenRequestDTO);
    }
}
