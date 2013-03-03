using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    static class CalculateDistance
    {
        public static double Calculate(Point3D a,Point3D b)
        {
            double distance = 0;
            distance = Math.Sqrt((a.X - b.X) * (a.Y - b.Y) + (a.Y - b.Y) * (a.Y - b.Y) + (a.Z - b.Z) * (a.Z - b.Z)); 
            return distance;
        }
    }
}
