using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUIStatsApi.Services;
using MAUIStatsApi.DTO;
using System.Windows.Input;

namespace MAUIStatsApi.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;

        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;

            LoginCommand = new Command(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            IsBusy = true;

            var result = await _authService.LoginAsync(new LoginRequestDto
            {
                LoginOrEmail = Login,
                Password = Password
            });

            IsBusy = false;

            if (!result.Success)
            {
                await Shell.Current.DisplayAlert(
                    "Ошибка",
                    result.ErrorMessage,
                    "OK");
                return;
            }

            
            await Shell.Current.GoToAsync("//players");
        }
    }
}