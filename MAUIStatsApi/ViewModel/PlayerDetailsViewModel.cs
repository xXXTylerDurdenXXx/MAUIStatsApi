using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUIStatsApi.DTO;

namespace MAUIStatsApi.ViewModel
{
    public class PlayerDetailsViewModel : BaseViewModel
    {
        private PlayerDto _player;
        public PlayerDto Player
        {
            get => _player;
            set => SetProperty(ref _player, value);
        }

        public PlayerDetailsViewModel()
        {
            
        }

        public void LoadPlayer(PlayerDto player)
        {
            Player = player;
        }
    }
}
