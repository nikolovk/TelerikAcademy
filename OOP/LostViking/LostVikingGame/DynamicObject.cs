using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    abstract class DynamicObject:GameObject,IMovable
    {
        /// Speed is connected with update, 
        /// when speed is 0, object update on every turn
        protected virtual int Speed {get;set;}
        private int state;
        protected Direction ObjDirection { get; set; }


        public DynamicObject(Position topLeft, char[,] texture, int speed, Direction direction)
            : base(topLeft, texture)
        {
            this.Speed = speed;
            this.state = this.Speed;
            this.ObjDirection = direction;
        }


        //Method for mooving - Krasi
        public virtual void ChangePosition(int rowChange, int colChange)
        {
            this.TopLeft = new Position(this.TopLeft.Row + rowChange, this.TopLeft.Col + colChange);
        }


        //Change position on direction of move, on every turn
        public override List<GameObject> Update()
        {
         //moving battle ships yoan , can't get field col
           
            if (this.state == 0)
            {
                this.state = this.Speed;
                switch (ObjDirection)
                {
                    case Direction.Top:
                        this.ChangePosition(-1, 0);
                        break;
                    case Direction.TopRight:
                        this.ChangePosition(-1, 1);
                        break;
                    case Direction.Right:
                        this.ChangePosition(0, 1);
                        break;
                    case Direction.DownRight:
                        this.ChangePosition(1, 1);
                        break;
                    case Direction.Down:
                        this.ChangePosition(1, 0);
                        break;
                    case Direction.DownLeft:
                        this.ChangePosition(1, -1);
                        break;
                    case Direction.Left:
                        this.ChangePosition(0, -1);
                        break;
                    case Direction.TopLeft:
                        this.ChangePosition(-1, -1);
                        break;
                    default:
                        break;
                }
                
            }
            else
            {
                this.state--;
            }
            List<GameObject> produced = new List<GameObject>();
            return produced;
        }

    }
}
