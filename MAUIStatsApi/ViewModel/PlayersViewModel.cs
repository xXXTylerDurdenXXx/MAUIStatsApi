using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUIStatsApi.Services;
using MAUIStatsApi.DTO;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace MAUIStatsApi.ViewModel
{
    public class PlayersViewModel: INotifyPropertyChanged
    {
        private readonly PlayerService _playerService;

        public ObservableCollection<PlayerDto> Players { get; set; }
            = new ObservableCollection<PlayerDto>();

        public PlayersViewModel(PlayerService playerService)
        {
            _playerService = playerService;
            LoadPlayers();
        }

        private async void LoadPlayers()
        {
            try
            {
                var players = await _playerService.GetPlayersAsync();
                Players.Clear();
                foreach (var p in players)
                    Players.Add(p);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Ошибка", ex.Message, "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
