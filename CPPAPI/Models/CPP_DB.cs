using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPAPI.Models
{
    class CPP_DB : DbContext
    {
        public CPP_DB() : base("DefaultConnection")
        {

        }

        public DbSet<GameOverview> GameOverviews { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
