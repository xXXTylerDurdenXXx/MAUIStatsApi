using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUIStatsApi.DTO;

namespace MAUIStatsApi.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);

        Task LogoutAsync();
        Task<bool> IsAuthenticatedAsync();

        Task<string?> GetTokenAsync();
    }
}
