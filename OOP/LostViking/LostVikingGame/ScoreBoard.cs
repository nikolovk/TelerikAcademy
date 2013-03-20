using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    class ScoreBoard:IDrawable
    {
        private List<Score> playerScores;
        private string filePath = @"";//must add file path
        public ScoreBoard()
        {
            this.playerScores = new List<Score>();
            this.LoadScoresFromFile();
        }

        private Score ParseScoreFromString(string scoreString)
        {
            string[] playerData = scoreString.Split(' ');
            string playerName = playerData[0];
            int playerScore = int.Parse(playerData[1]);
            return new Score(playerName, playerScore);
        }

        private void LoadScoresFromFile()
        {
            try
            {
                if (this.FilePath == null || string.Compare(this.FilePath, "") == 0)
                {
                    throw new ArgumentNullException("File path of score board file cannot be empty or null");
                }
                if (!File.Exists(this.FilePath))
                {
                    throw new ArgumentException("File path {0} was incorrect or such file doesn't exist in the given directory.", this.FilePath);
                }
                using (StreamReader reader = new StreamReader(this.FilePath))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        Score playerScore = this.ParseScoreFromString(line);
                        this.PlayerScores.Add(playerScore);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SaveScoresToFile()
        {
            try
            {
                if (this.FilePath == null || string.Compare(this.FilePath, "") == 0)
                {
                    throw new ArgumentNullException("File path of score board file cannot be empty or null");
                }
                if (!File.Exists(this.FilePath))
                {
                    throw new ArgumentException("File path {0} was incorrect.", this.FilePath);
                }
                using (StreamWriter writer = new StreamWriter(this.FilePath))
                {
                    foreach (Score player in this.PlayerScores)
                    {
                        writer.WriteLine(player.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Score> PlayerScores
        {
            get
            {
                return this.playerScores;
            }
        }

        public string FilePath
        {
            get
            {
                return this.filePath;
            }
        }

        public void Draw()
        {
            //Only a base implementation.
            //To be implemented further with setCursorPosition 
            Console.WriteLine("Player scores:");
            foreach (Score score in this.PlayerScores)
            {
                Console.WriteLine("{0}: {1}",score.PlayerName,score.ScoreResult);
            }
        }
    }
}
