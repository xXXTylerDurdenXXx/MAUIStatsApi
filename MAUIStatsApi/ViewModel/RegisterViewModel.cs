using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUIStatsApi.DTO;
using MAUIStatsApi.Services;

namespace MAUIStatsApi.ViewModel
{
    public class RegisterViewModel: BaseViewModel
    {
        private readonly IAuthService _authService;

        public RegisterViewModel(IAuthService authService)
        {
            _authService = authService;
            RegisterCommand = new Command(async () => await Register());
        }

        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Command RegisterCommand { get; }

        private async Task Register()
        {
            var result = await _authService.RegisterAsync(new RegisterRequestDto
            {
                Login = Login,
                Email = Email,
                Password = Password
            });

            if (!result.Success)
            {
                await Shell.Current.DisplayAlert("Ошибка", result.ErrorMessage, "OK");
                return;
            }

            // сохранить токен
            await SecureStorage.SetAsync("token", result.Token);

            // перейти дальше
            await Shell.Current.GoToAsync("//PlayersPage");
        }
    }
}
