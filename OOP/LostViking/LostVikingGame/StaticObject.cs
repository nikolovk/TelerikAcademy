using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    //added class for rocks and stars - yoan
    abstract class StaticObject : GameObject
    {
        public StaticObject(Position topLeft, char[,] texture)
            : base(topLeft, texture)
        {

        }
    }
}
