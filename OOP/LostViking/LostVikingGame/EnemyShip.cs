using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    class EnemyShip : Ship
    {
        private int shootInterval = 10;

        //Constructor
        public EnemyShip(Position center, char[,] texture,Direction direction)
            : base(center, texture,5,direction,2)
        {
            this.ObjectPosition = center;
        }
        private int TimesOfUpdate = 0;

        public override List<GameObject> Update()
        {
            if (this.TopLeft.Col == 44)
            {
                TimesOfUpdate++;
                if (TimesOfUpdate > 8)
                {
                    this.ObjDirection = Direction.Left;
                    TimesOfUpdate = 0;
                }
                else
                {
                    this.ObjDirection = Direction.Down;
                }
            }
            if (this.TopLeft.Col == 0)
            {
                TimesOfUpdate++;
                if (TimesOfUpdate > 8)
                {
                    this.ObjDirection = Direction.Right;
                    TimesOfUpdate = 0;
                }
                else
                {
                    this.ObjDirection = Direction.Down;
                }
                
            }
            
            List<GameObject> produced = new List<GameObject>();
            if (this.shootInterval == 0)
            {
                this.shootInterval = 15;
                produced.AddRange(this.Shoot(Direction.Down));
            }
            else
            {
                this.shootInterval--;
            }

            base.Update();

            return produced;

        }
    }
}
