using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    public abstract class GameObject:IChangeable
    {
        public Position TopLeft { get; protected set; }
        public bool IsDestroyed { get; set; }
        public char[,] Texture { get; private set; }

        
        // Main abstract class for all objects
        public GameObject(Position topLeft, char[,] texture)
        {
            this.TopLeft = topLeft;
            this.Texture = texture;
            this.IsDestroyed = false;
        }

        // Add update method that should be used to update object on every turn
        public virtual List<GameObject> Update()
        {
            List<GameObject> produced = new List<GameObject>();
            return produced;
        }


        public int Width
        {
            get { return this.Texture.GetLength(1); }
        }
        public int Height
        {
            get { return this.Texture.GetLength(0); }
        }
    }
}
