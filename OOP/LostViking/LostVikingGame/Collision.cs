using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    public static class Collision
    {

        // Makes pair of object to be checked
        public static void Check(List<GameObject> objects)
        {
            for (int i = 0; i < objects.Count - 1; i++)
            {
                for (int j = i + 1; j < objects.Count; j++)
                {
                    PairCheck(objects[i], objects[j]);
                }
            }
        }


        // Checks pair of objects for collision
        private static void PairCheck(GameObject first, GameObject second)
        {
            if (!((first.TopLeft.Col >= second.TopLeft.Col+second.Width) || 
            (second.TopLeft.Col >= first.TopLeft.Col + first.Width) ||
            (first.TopLeft.Row >= second.TopLeft.Row+second.Height) || 
            (second.TopLeft.Row >= first.TopLeft.Row + first.Height)))
            {
                if ((first is Ship) && (second is Bullet))
                {
                    second.IsDestroyed = true;
                    (first as Ship).LifeDecrease();
                }
                if ((second is Ship) && (first is Bullet))
                {
                    first.IsDestroyed = true;
                    (second as Ship).LifeDecrease();
                }
                if (first is StaticObject)
                {
                    second.IsDestroyed = true;
                }
                if (second is StaticObject)
                {
                    first.IsDestroyed = true;
                }
            }
        }
    }
}
