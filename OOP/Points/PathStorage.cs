using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    static class PathStorage
    {

        public static void SavePath(Path path)
        {
            StreamWriter writer = new StreamWriter("..\\..\\paths.txt");
            using (writer)
            {
                foreach (var point in path.Points)
                {
                    writer.WriteLine(point.ToString());
                }
            }
        }
        public static Path LoadPath()
        {
            Path path = new Path();
            StreamReader reader = new StreamReader("..\\..\\paths.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Point3D point = new Point3D();
                    string[] pointsArray = line.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    point.X = int.Parse(pointsArray[0]);
                    point.Y = int.Parse(pointsArray[1]);
                    point.Z = int.Parse(pointsArray[2]);
                    path.AddPoint(point);
                    line = reader.ReadLine();
                }
            }
            return path;
        }
    }
}
