using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    class Score
    {
        private string playerName;
        private int scoreResult;
        public Score(string name, int score)
        {
            this.playerName = name;
            this.scoreResult = score;
        }
        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
        }
        public int ScoreResult
        {
            get
            {
                return this.scoreResult;
            }
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", this.PlayerName, this.ScoreResult);
        }
    }
}
