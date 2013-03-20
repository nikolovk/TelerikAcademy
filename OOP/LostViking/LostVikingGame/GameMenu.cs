using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    public class GameMenu
    {
        public bool Start { get; set; }
        public GameMenu()
        {
        }

        public static void StartMenu()
        {
            Console.WriteLine(@"
     _               _    __      ___ _    _             
    | |             | |   \ \    / (_) |  (_)            
    | |     ___  ___| |_   \ \  / / _| | ___ _ __   __ _ 
    | |    / _ \/ __| __|   \ \/ / | | |/ / | '_ \ / _` |
    | |___| (_) \__ \ |_     \  /  | |   <| | | | | (_| |
    |______\___/|___/\__|     \/   |_|_|\_\_|_| |_|\__, |
                                                    __/ |
                                                  |____/ 

                    ""Lost Viking"" Game

                        New Game (1)
                    View high score (2)
                      View tutorial (3)
                             ");
          
        }

        public static void EndMenu()
        {
            Console.Clear();
            Console.WriteLine(@"
     _               _    __      ___ _    _             
    | |             | |   \ \    / (_) |  (_)            
    | |     ___  ___| |_   \ \  / / _| | ___ _ __   __ _ 
    | |    / _ \/ __| __|   \ \/ / | | |/ / | '_ \ / _` |
    | |___| (_) \__ \ |_     \  /  | |   <| | | | | (_| |
    |______\___/|___/\__|     \/   |_|_|\_\_|_| |_|\__, |
                                                    __/ |
                                                  |____/ 

                         Game Over :(

                        Try again (1)
                    View high score (2)
                     View tutorial (3)
                             ");
        }

        public static void CheckInput()
        {
            try
            {
                Console.Write("Your option : ");
                int Input = int.Parse(Console.ReadLine());
                switch (Input)
                {
                    case 1:
                        Console.Clear();
                        LostViking.Game();
                        break;
                    case 2:
                        Console.Clear();
                        LostViking.GetHighScore();
                        break;
                    case 3:
                        Console.Clear();
                        LostViking.GetTutorial();
                        break;
                    default:
                        Console.WriteLine("You have entered bad value, please try again");
                        GameMenu.CheckInput();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("You have entered bad value, please try again");
                GameMenu.CheckInput();
            }
        }
        public static void Tutorial()
        {
            Console.WriteLine("-TUTORIAL-");
            StreamReader Tutorial = new StreamReader(@"../../txt/tutorial.txt");
            using (Tutorial)
            {
                string line = Tutorial.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = Tutorial.ReadLine();
                }
            }

            Console.WriteLine("New game (1)");
            Console.WriteLine("View highscores (2)");
            Console.WriteLine("View again(3)");
        }
        public static void HighScore()
        {
            Console.WriteLine("-HIGHSCORES-");
            StreamReader ScoreBoard = new StreamReader(@"../../txt/score.txt");
            using (ScoreBoard)
            {
                string line = ScoreBoard.ReadLine();
                List<Player> Players = new List<Player>();
                string[] ScoreData = new string[2];
                while (line != null)
                {
                    ScoreData = line.Split(' ');

                    Players.Add(new Player(ScoreData[0], int.Parse(ScoreData[1])));
                    
                    line = ScoreBoard.ReadLine();
                }
                Players.OrderBy(player => player.Score);
                for (int i = 0; i < Players.Count; i++)
                {
                    Console.WriteLine("{0}. {1,5} {2,50}",i+1,Players[i].Name,Players[i].Score);
                }
            }
            Console.WriteLine("New game (1)"); 
            Console.WriteLine("View again (2)");
            Console.WriteLine("View tutorial(3)");
            GameMenu.CheckInput();
        }
         
    }
}
