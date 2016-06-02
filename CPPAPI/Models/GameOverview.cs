using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPAPI.Models
{
    public class GameOverview
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivePlayerId { get; set; }
        public int CurrentScore { get; set; }
        public bool Active { get; set; }
        public List<Player> Players { get; set; }

    }
}
