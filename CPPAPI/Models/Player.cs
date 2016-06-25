using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPAPI.Models
{
    public class Player
    {
        private CPP_DB db = new CPP_DB();


        public int Id { get; set; }
        public string Name { get; set; }
        public int Avatar { get; set; }

     //   [JsonIgnore]
       // public List<Game> Games { get; set; }

        [JsonIgnore]
        public List<PlayerDetail> PlayerDetails { get; set; }

        protected string GetPlayerAttributeValue(string attributeName)
        {
            var player = this.db.Players.Find(this.Id);
            db.Entry(player).Collection(x => x.PlayerDetails).Load();
            var value = player.PlayerDetails.Where(x => x.AttributeName == attributeName).Select(y => y.AttributeValue).ToString();

            return value;
        }
    }
}
