using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using MAUIStatsApi.DTO;

namespace MAUIStatsApi.Services
{
    public class AuthService: IAuthService
    {
        private readonly HttpClient _httpClient;
        private const string TokenKey = "jwt_token";

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/Login", request);

            if (!response.IsSuccessStatusCode)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    ErrorMessage = "Ошибка авторизации"
                };
            }

            var result = await response.Content.ReadFromJsonAsync<AuthResponseDto>();

            if (result != null && result.Success)
            {
                await SecureStorage.SetAsync(TokenKey, result.Token);
            }

            return result!;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/Register", request);
            return await response.Content.ReadFromJsonAsync<AuthResponseDto>()!;
        }

        public async Task LogoutAsync()
        {
            SecureStorage.Remove(TokenKey);
            await Task.CompletedTask;
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await GetTokenAsync();
            return !string.IsNullOrEmpty(token);
        }

        public async Task<string?> GetTokenAsync()
        {
            return await SecureStorage.GetAsync(TokenKey);
        }
    }
}

