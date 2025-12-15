using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUIStatsApi.DTO;

namespace MAUIStatsApi.Services
{
    public class AuthService
    {
        private readonly ApiClient _api;

        public AuthService(ApiClient api)
        {
            _api = api;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
        {
            var response = await _api.PostAsync<LoginRequestDto, AuthResponseDto>(
                "api/auth/login", dto);

            if (response.Success)
            {
                _api.SetToken(response.Token);
                Preferences.Set("jwt_token", response.Token);
            }

            return response;
        }
    }
}
