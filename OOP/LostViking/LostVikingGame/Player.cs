using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    class Player
    {
        public int Score { get; set; }
        public string Name { get; set; }

        public Player(string Name, int Score)
        {
            this.Score = Score;
            this.Name = Name;
        }
    }
}
