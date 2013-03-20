using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    interface IChangeable
    {
        List<GameObject> Update();
    }
}
