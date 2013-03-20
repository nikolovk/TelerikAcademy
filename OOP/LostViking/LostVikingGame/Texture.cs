using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    class Texture
    {
       // private Position insertPoint;
        private char[,] body;

        public Texture(char[,] body)
        {
            this.body = body;
          //  this.insertPoint = new Position(body.GetLength(0), body.GetLength(1));
        }


        //// Properties of Texture
        //public Position InsertPoint
        //{
        //    get { return this.insertPoint; }

        //}
        public int Width
        {
            get { return this.body.GetLength(1); }
        }
        public int Height
        {
            get { return this.body.GetLength(0); }
        }
    }
}
