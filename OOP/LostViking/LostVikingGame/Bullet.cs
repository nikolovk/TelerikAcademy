using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    class Bullet : DynamicObject
    {

        public Bullet(Position topLeft, char[,] texture, Direction bulletDirection)
            : base(topLeft, texture,0,bulletDirection)
        {
            this.ObjDirection = bulletDirection;
        }
        
    }
}
