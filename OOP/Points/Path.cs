using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    class Path
    {
        private List<Point3D> points = new List<Point3D>();
        public void AddPoint(Point3D point)
        {
            this.points.Add(point);
        }
        public List<Point3D> Points
        {
            get { return this.points; }
        }
    }
}
