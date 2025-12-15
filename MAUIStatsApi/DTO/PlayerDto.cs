using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIStatsApi.DTO
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Number { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string TeamName { get; set; }
        public string PositionName { get; set; }
    }
}
