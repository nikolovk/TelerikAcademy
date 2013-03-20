using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    //adding Rock objects - yoan
    class Rock : StaticObject
    {
        public int Lifetime { get; private set; }

        public Rock(Position topLeft, char[,] body)
            : base(topLeft, body)
        {
            this.Lifetime = 100;
        }
     

        // different collisions :
        // collision with bullet - bullet dies
        // collision with EnemyShip - EnemyShip dies
        // collision with Viking - Viking Life-- , or Viking dies
        // Rock specification :
        // Rock dies after several turns - Lifetime
        // Should be several on gamefield
        // after one dies, another is "born"
    }
}
