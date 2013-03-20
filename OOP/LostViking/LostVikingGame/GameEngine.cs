using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LostVikingGame
{
    class GameEngine
    {
        // general objects used in the game. Will be specified in different lists with development
        private List<GameObject> objects;
        private ConsoleRenderer renderer;
        private Viking viking;
        private KeyboardInerface keyboard;
        private int refreshRate;
        private bool noEnemies;
        private Random random;
        private int Score { get; set; }
        public int FieldRows { get; private set; }
        public int FieldCols { get; private set; }
        public bool InMenu { get; set; }
        private char[,] rockTexture;
        private char[,] enemyShpTexture;

        public GameEngine(KeyboardInerface keyboard, int refreshRate, int fieldRows, int fieldCols)
        {
            this.FieldRows = fieldRows;
            this.FieldCols = fieldCols;
            this.refreshRate = refreshRate;
            this.viking = new Viking(new Position(this.FieldCols / 2, this.FieldRows - 3));
            this.keyboard = keyboard;
            this.noEnemies = false;
            this.random = new Random();
            this.Score = 0;
            this.rockTexture = new char[,] { { '#', '#' }, { '#', '#' } };
            this.enemyShpTexture = new char[,] { { '%', '%', '%' }, { ' ', '%', ' ' } };
        }

        public void Initialise()
        {
            //Add renderer that should be used for print
            this.renderer = new ConsoleRenderer(this.FieldRows, this.FieldCols);

            //allocate memory and create all objects needed in game
            this.objects = new List<GameObject>();

            //Add viking to game object, should be change, just want to test Krasi :)
            this.objects.Add(this.viking);

            //Add some enemy ship
            this.objects.Add(new EnemyShip(new Position(-1, 8), this.enemyShpTexture, Direction.DownLeft));
            this.objects.Add(new EnemyShip(new Position(-1, 42), this.enemyShpTexture, Direction.DownRight));
            //add one rock 
            this.objects.Add(new Rock(new Position(10, 10), this.rockTexture));

            this.objects.Add(new Rock(new Position(15, 35), this.rockTexture));
        }

        public void Run()
        {
            bool endGame = false;
            while (!endGame)
            {
                //main game loop
                //game logic goes here

                //Run all objects Update()
                List<GameObject> produced = new List<GameObject>();
                foreach (var obj in this.objects)
                {
                    produced.AddRange(obj.Update());
                }
                this.Objects.AddRange(produced);

                //Generate enemies
                this.noEnemies = !objects.Any(x => x is EnemyShip);
                if (this.noEnemies)
                {
                    this.Score += 10;
                    GenerateEnemy();
                }

                // Read Input from keyboard
                this.keyboard.ProcessInput();

                // Check for collision
                Collision.Check(objects);

                // Clear destroyed objects from list
                this.objects.RemoveAll(obj => obj.IsDestroyed);

                //Here I print on console with renderer
                this.renderer.ClearField();
                this.renderer.AddToField(this.objects);
                this.renderer.PrintField();
                //Print Score
                this.renderer.PrintScore(this.Score);

                //if player dies or chooses to get out of the game 
                //endGame variable is set to True and enters if statement
                endGame = !objects.Any(x => x is Viking);
                if (endGame)
                {
                    this.End();
                }
                Thread.Sleep(this.refreshRate);
            }
        }

        private void GenerateEnemy()
        {
            int randCol = random.Next(5, 35);
            Direction enemyDirection;
            if (randCol % 2 == 0)
            {
                enemyDirection = Direction.DownRight;
            }
            else
            {
                enemyDirection = Direction.DownLeft;
            }
            this.objects.Add(new EnemyShip(new Position(-1, randCol), this.enemyShpTexture, enemyDirection));
        }
        private void End()
        {
            GameMenu.EndMenu();
            GameMenu.CheckInput();
        }
        //Properties
        public List<GameObject> Objects
        {
            get
            {
                return this.objects;
            }
        }

        // Receive shoot order from main and make viking shoot
        public void VikingShoot()
        {
            objects.AddRange(this.viking.Shoot(Direction.Top));
        }


        // Receive moving orders from main and transmit move to viking

        //ch
        public void MoveViking(Direction direction)
        {
            switch (direction)
            {
                case Direction.Top:
                    //changed moving area of viking yoan
                    if (this.viking.TopLeft.Row - 1 >= 4)
                    {
                        this.viking.ChangePosition(-1, 0);
                    }
                    break;
                case Direction.TopRight:
                    break;
                case Direction.Right:
                    //changed moving area of viking yoan
                    if (this.viking.TopLeft.Col + 1 <= FieldCols - 5)
                    {
                        this.viking.ChangePosition(0, 1);
                    }
                    break;
                case Direction.DownRight:
                    break;
                case Direction.Down:
                    //changed moving area of viking yoan
                    if (this.viking.TopLeft.Row + 1 < FieldRows - 2)
                    {
                        this.viking.ChangePosition(1, 0);
                    }
                    break;
                case Direction.DownLeft:
                    break;
                case Direction.Left:
                    if (this.viking.TopLeft.Col - 1 >= 0)
                    {
                        this.viking.ChangePosition(0, -1);
                    }
                    break;
                case Direction.TopLeft:
                    break;
                default:
                    break;
            }
        }
    }
}
