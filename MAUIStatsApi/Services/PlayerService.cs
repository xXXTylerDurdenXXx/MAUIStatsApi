using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUIStatsApi.DTO;

namespace MAUIStatsApi.Services
{
    public class PlayerService
    {
        private readonly ApiClient _api;

        public PlayerService(ApiClient api)
        {
            _api = api;
        }

        public Task<List<PlayerDto>> GetPlayersAsync()
        {
            return _api.GetAsync<List<PlayerDto>>("api/player");
        }
    }
}
