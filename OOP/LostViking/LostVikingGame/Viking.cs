using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    class Viking :Ship
    {
        // The Viking
        //changed viking outlook yoan 
        public Viking(Position topLeft)
            : base(topLeft, new char[,] { {' ',' ','^',' ',' '}, {'-','[','*',']','-'}},0,Direction.Right,5)
        {
        }

        public override List<GameObject> Update()
        {
            List<GameObject> produced = new List<GameObject>();
            return produced;
        }

    }
}
