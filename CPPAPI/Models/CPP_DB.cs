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
            Configuration.ProxyCreationEnabled = false;
          //  Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Player>()
            //            .HasMany<Game>(s => s.Games)
            //            .WithMany(c => c.Players)
            //            .Map(cs =>
            //            {
            //                cs.MapLeftKey("PlayerId");
            //                cs.MapRightKey("GameId");
            //                cs.ToTable("PlayersToGames");
            //            });

        }


        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerDetail> PlayerDetails { get; set; }
        public DbSet<PlayerToGame> PlayerToGames { get; set; }


    }
}
