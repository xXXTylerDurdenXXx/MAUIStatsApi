using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MAUIStatsApi.DTO
{
    public class AuthResponseDto
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string ErrorMessage { get; set; }
        public UserDto? User { get; set; }
    }
}
