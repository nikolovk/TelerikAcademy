using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    abstract class Ship : DynamicObject, IShootable
    {
        public int Life { get; private set; }
        //yoan
        protected Position ObjectPosition;
        //Constructor
        public Ship(Position topLeft, char[,] texture, int speed, Direction direction, int life)
            : base(topLeft, texture,speed,direction)
        {
            this.Life = life;
        }

        // Ship can shoot
        public List<GameObject> Shoot(Direction direction)
        {
            List<GameObject> shoots = new List<GameObject>();
            Position bulletPosition = new Position(0, 0);
            char bulletTexture = '|';
            switch (direction)
            {
                case Direction.Top:
                    bulletPosition.Row = this.TopLeft.Row - 1;
                    bulletPosition.Col = (2 * this.TopLeft.Col + this.Width) / 2;
                    bulletTexture = '|';
                    break;
                case Direction.TopRight:
                    bulletPosition.Row = this.TopLeft.Row - 1;
                    bulletPosition.Col = this.TopLeft.Col + 1;
                    bulletTexture = '/';
                    break;
                case Direction.Right:
                    bulletPosition.Row = (2 * this.TopLeft.Row + this.Width) / 2;
                    bulletPosition.Col = this.TopLeft.Col + 1;
                    bulletTexture = '-';
                    break;
                case Direction.DownRight:
                    bulletPosition.Row = this.TopLeft.Row + 2;
                    bulletPosition.Col = this.TopLeft.Col + 1;
                    bulletTexture = '\\';
                    break;
                case Direction.Down:
                    bulletPosition.Row = this.TopLeft.Row + 2;
                    bulletPosition.Col = (2 * this.TopLeft.Col + this.Width) / 2;
                    bulletTexture = '|';
                    break;
                case Direction.DownLeft:
                    bulletPosition.Row = this.TopLeft.Row + 2;
                    bulletPosition.Col = this.TopLeft.Col - 1;
                    bulletTexture = '/';
                    break;
                case Direction.Left:
                    bulletPosition.Row = (2 * this.TopLeft.Row + this.Width) / 2;
                    bulletPosition.Col = this.TopLeft.Col + 1;
                    bulletTexture = '-';
                    break;
                case Direction.TopLeft:
                    bulletPosition.Row = this.TopLeft.Row - 1;
                    bulletPosition.Col = this.TopLeft.Col - 1;
                    bulletTexture = '\\';
                    break;
                default:
                    break;
            }
            shoots.Add(new Bullet(bulletPosition,new char[,] { { bulletTexture } }, direction));
            return shoots;
        }
        // Manipulate Life
        public void LifeDecrease()
        {
            this.Life--;
            if (this.Life <=0)
            {
                this.IsDestroyed = true;
            }
        }

    }
}
