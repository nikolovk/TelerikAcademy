using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    class PointsProgram
    {
        static void Main(string[] args)
        {
            Point3D a = new Point3D(5, 5, 5);
            Point3D b = new Point3D(0, 7, 11);
            Console.WriteLine("Distance between a and b is {0}",CalculateDistance.Calculate(a,b));
            Path path = new Path();
            path.AddPoint(a);
            path.AddPoint(b);
            PathStorage.SavePath(path);
            Path loadedPath = PathStorage.LoadPath();
            foreach (Point3D point in loadedPath.Points)
            {
                Console.WriteLine("Point 1 - {0}",point);
            }
        }
    }
}
