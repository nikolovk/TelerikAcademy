using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    public class LostViking
    {
        private const int RefreshRate = 60;
        private const int FieldRows = 27;
        private const int FieldCols = 50;
       //removed string args of Main yoan
        public static void Main()
        {
            
            GameMenu.StartMenu();
            GameMenu.CheckInput();
        }
        // adding GetHighScore option from menu
        public static void GetHighScore()
        {

            GameMenu.HighScore();
            GameMenu.CheckInput();
        }

        public static void GetTutorial()
        {
            GameMenu.Tutorial();
            GameMenu.CheckInput();
        }

        //this is the old Main()
        public static void Game()
        {
            KeyboardInerface keyboard = new KeyboardInerface();
            GameEngine engine = new GameEngine(keyboard, RefreshRate, FieldRows, FieldCols);

            keyboard.OnUpPressed += (sender, eventInfo) =>
            {
                engine.MoveViking(Direction.Top);

            };
            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                engine.MoveViking(Direction.Right);
            };
            keyboard.OnDownPressed += (sender, eventInfo) =>
            {
                engine.MoveViking(Direction.Down);
            };
            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                engine.MoveViking(Direction.Left);
            };
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                engine.VikingShoot();
            };
            engine.Initialise();
            engine.Run();
         
        }
    }
}
